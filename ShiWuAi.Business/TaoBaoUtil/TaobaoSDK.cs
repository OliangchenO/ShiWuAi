using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Top.Api;
using Top.Api.Request;
using Top.Api.Response;

namespace ShiWuAi.Business.TaoBaoUtil
{
    public class TaobaoSDK
    {
        public static String url = "http://gw.api.taobao.com/router/rest";

        //创建应用时，TOP颁发的唯一标识，TOP通过App Key来鉴别应用的身份。调用接口时必须传入的参数。  
        public static String appkey = "23403271";

        //App Secret是TOP给应用分配的密钥，开发者需要妥善保存这个密钥，这个密钥用来保证应用来源的可靠性，防止被伪造。  
        public static String secret = "3a1c3d6d7ff0c1b3fa726d84d14215d1";

        public static long adzoneId = 58092959L;
        public static string getTbkItem()
        {
            ITopClient client = new DefaultTopClient(url, appkey, secret, "json");
            TbkItemGetRequest req = new TbkItemGetRequest();
            req.Fields = "num_iid,title,pict_url,small_images,reserve_price,zk_final_price,user_type,provcity,item_url,seller_id,volume,nick";
            req.Q = "女装";
            req.Cat = "16,18";
            //req.Itemloc = "杭州";
            req.Sort = "tk_rate_des";
            //req.IsTmall = false;
            //req.IsOverseas = false;
            //req.StartPrice = 10L;
            //req.EndPrice = 10L;
            //req.StartTkRate = 123L;
            //req.EndTkRate = 123L;
            //req.Platform = 1L;
            //req.PageNo = 123L;
            //req.PageSize = 20L;
            TbkItemGetResponse rsp = client.Execute(req);

            Console.WriteLine(rsp.Body);
            return rsp.Body;
        }

        /**
         * 获取淘宝客选品库
         */
        public static string getTbkFavorites(long pageNo, long pageSize, long type)
        {
            ITopClient client = new DefaultTopClient(url, appkey, secret, "json");
            TbkUatmFavoritesGetRequest req = new TbkUatmFavoritesGetRequest();
            req.PageNo = pageNo == 0L ? 1L : pageNo;
            req.PageSize = pageSize == 0L ? 50L : pageSize;
            req.Fields = "favorites_title,favorites_id,type";
            req.Type = type == 0L ? 2L : type;
            TbkUatmFavoritesGetResponse rsp = client.Execute(req);
            return rsp.Body;
        }

        public static string getTbkFavoritesProduct(int favoritesId)
        {
            ITopClient client = new DefaultTopClient(url, appkey, secret, "json");
            TbkUatmFavoritesItemGetRequest req = new TbkUatmFavoritesItemGetRequest();
            req.Platform = 2L;
            req.AdzoneId = adzoneId;
            req.FavoritesId = favoritesId;
            req.Fields = "num_iid,title,pict_url,small_images,click_url,reserve_price,zk_final_price,user_type,provcity,item_url,seller_id,volume,nick,shop_title,zk_final_price_wap,event_start_time,event_end_time,tk_rate,status,type";
            TbkUatmFavoritesItemGetResponse response = client.Execute(req);
            return response.Body;
        }
    }
}
