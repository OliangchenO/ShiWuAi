using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EntityFrameWork.Extend;
using System.IO;
using System.Text;
using ShiWuAi.Business.TaoBaoUtil;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ShiWuAi.Model.Tbk;
using ShiWuAi.Business.Interfaces;
using ShiWuAi.Business;
using APICloud.Rest;

namespace ShiWuAi.Admin.Ui.Controllers
{
    public class TbkFavoritesController : Controller
    {
        // GET: TbkFavorites
        public PartialViewResult Manage()
        {
            return PartialView();
        }




        [HttpPost]
        public string Query(int page, int rows, string sort, string order)
        {
            var bs = BsProvider.CreateBusiness<ITbkFavorites>();
            int totalCount = 0;
            List<Param> paramList = new List<Param>() { new Param() { IsDesc = order == "desc" ? true : false, Name = sort } };
            var data = bs.Query(page, rows, o => 1 == 1, paramList, out totalCount);
            var returnObj = "";
            if (data.Status == 0)
            {
                returnObj = Newtonsoft.Json.JsonConvert.SerializeObject(new { total = totalCount, rows = data.Obj });
            }
            return returnObj;
        }

        [HttpPost]
        public string Save(TbkFavorites model)
        {

            var bs = BsProvider.CreateBusiness<ITbkFavorites>();
            TbkFavorites findModel = getTbkFavoriteByFavoritesId(model.favorites_id);
            var returnObj = "";
            //新增
            if (findModel != null)
            {
                findModel.UpdateDate = DateTime.Now;
                returnObj = Newtonsoft.Json.JsonConvert.SerializeObject(bs.Update(findModel));
            }
            else
            {
                if (model.Id == 0)
                {
                    model.CreateDate = DateTime.Now;

                    returnObj = Newtonsoft.Json.JsonConvert.SerializeObject(bs.Add(model));
                }
                //编辑
                else
                {
                    model.UpdateDate = DateTime.Now;

                    returnObj = Newtonsoft.Json.JsonConvert.SerializeObject(bs.Update(model));
                }
            }
            return returnObj;

        }


        [HttpPost]
        public string Delete(List<int> ids)
        {

            var bs = BsProvider.CreateBusiness<ITbkFavorites>();
            var returnObj = "";
            //新增



            returnObj = Newtonsoft.Json.JsonConvert.SerializeObject(bs.GroupDelete(ids));

            return returnObj;

        }

        [HttpPost]
        public string Sync_data(int id, string category)
        {
            var favoritesProduct = TaobaoSDK.getTbkFavoritesProduct(id);
            JObject productJObject = JObject.Parse(favoritesProduct);
            JToken products = productJObject["tbk_uatm_favorites_item_get_response"]["results"]["uatm_tbk_item"];
            var resource = new Resource("A6904928073012", "C0DF9412-536D-7A7B-05CF-56813C7AD0EF");
            var tbk_product = resource.Factory("tbk_product");
            var list = new List<Object>();
            foreach (JToken product in products)
            {
                product["category"] = category;
                tbk_product.Create(JsonConvert.SerializeObject(product));
                //list.Add(new
                //{

                //    method = "POST",
                //    path = "https://d.apicloud.com/mcm/api/tbk_product",
                //    data = JsonConvert.SerializeObject(product)
                //});
                //tbk_product.Create(JsonConvert.SerializeObject(product));
            }
            //var ret = resource.Batch(list);
            return favoritesProduct;
        }

        [HttpPost]
        public string GetTbkFavorites(int id)
        {
            var bs = BsProvider.CreateCommon<TbkFavorites>();
            var returnObj = "";
            returnObj = Newtonsoft.Json.JsonConvert.SerializeObject(bs.Query(o => o.Id == id));
            return returnObj;
        }

        public TbkFavorites getTbkFavoriteByFavoritesId(string favoritesId)
        {
            var bs = BsProvider.CreateCommon<TbkFavorites>();
            TbkFavorites tbkFavorite = null;
            IEnumerable<TbkFavorites> tbkFavorites = bs.Query(o => o.favorites_id == favoritesId).Obj;
            if (tbkFavorites.Count() != 0)
            {
                tbkFavorite = tbkFavorites.First<TbkFavorites>();
            }
            return tbkFavorite;
        }

        [HttpPost]
        public string GetAllTbkFavorites()
        {
            var bs = BsProvider.CreateCommon<TbkFavorites>();
            var returnObj = "";
            returnObj = Newtonsoft.Json.JsonConvert.SerializeObject(bs.Query());
            SaveErrorToLog("path:" + Request.Url);
            SaveErrorToLog("returnObj:" + returnObj);
            return returnObj;
        }

        [HttpGet]
        public void getTbkFavoritesFromTaobao(long pageNo, long pageSize, long type)
        {
            var TbkFavoritesJson = TaobaoSDK.getTbkFavorites(pageNo, pageSize, type);
            JObject TbkFavorites = JObject.Parse(TbkFavoritesJson);
            JToken tbk_favorites = TbkFavorites["tbk_uatm_favorites_get_response"]["results"]["tbk_favorites"];
            foreach (JToken item in tbk_favorites)
            {
                TbkFavorites i = new TbkFavorites();
                i.Status = "1";
                i.type = item["type"].ToString();
                i.favorites_id = item["favorites_id"].ToString();
                i.favorites_title = item["favorites_title"].ToString();
                Save(i);
            }
        }

        private static void SaveErrorToLog(string infos)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + @"\NewOrderLog.txt";

            try
            {
                StreamWriter writer = new StreamWriter(path, true, Encoding.GetEncoding("UTF-8"));
                writer.WriteLine(infos);
                writer.WriteLine();
                writer.Close();
            }
            catch (Exception exception)
            {
                string message = exception.Message;
            }
        }
    }
}