using EntityFrameWork.Extend;
using ShiWuAi.Business.Interfaces;
using ShiWuAi.Model;
using ShiWuAi.Model.Banner;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShiWuAi.Business.Impl
{
    class Banner_CategoryImpl: CommonImpl<Banner_Category>, IBanner_Category
    {
        public Result<int> GroupDelete(List<int> ids)
        {
            return ExecuteDelegate.Exe<int>(delegate () {
                using (MyDbContext db = new DbContext())
                {
                    StringBuilder sb = new StringBuilder("delete from Tb_B_Banner where Id in (");
                    List<Param> paramList = new List<Param>();
                    for (int i = 0; i < ids.Count; i++)
                    {
                        sb.Append("@id" + i);
                        paramList.Add(new Param() { Name = "@id" + i, Value = ids[i], ParamType = 20 });
                        sb.Append(",");
                    }
                    sb.Length--;
                    sb.Append(")");
                    var result = SqlProvider.ExecuteSql(sb.ToString(), paramList, db);
                    return result;
                }
            });
        }
    }
}
