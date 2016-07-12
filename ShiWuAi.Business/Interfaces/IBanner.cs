using EntityFrameWork.Extend;
using ShiWuAi.Model.Banner;
using ShiWuAi.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ShiWuAi.Business.Interfaces
{
    public interface IBanner
    {
        Result<Banner> Add(Banner model);

        Result<Banner> Delete(Banner model);

        Result<int> GroupDelete(List<int> ids);

        Result<Banner> Update(Banner model);

        Result<Banner> QuerySinge(object ID);

        Result<IEnumerable<Banner>> Query();

        Result<IEnumerable<Banner>> Query(Expression<Func<Banner, bool>> where);

        Result<IEnumerable<Banner>> Query<TKey>(Expression<Func<Banner, bool>> where, Expression<Func<Banner, TKey>> order, bool isDesc);

        Result<IEnumerable<Banner>> Query(int pageIndex, int pageSize, Expression<Func<Banner, bool>> where, List<EntityFrameWork.Extend.Param> orderParamList, out int totalCount);

        Result<IEnumerable<Banner>> Query<TKey>(int pageIndex, int pageSize, Expression<Func<Banner, bool>> where, Expression<Func<Banner, TKey>> order, bool isDesc, out int totalCount);
    }
}
