using EntityFrameWork.Extend;
using ShiWuAi.Model.Banner;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ShiWuAi.Business.Interfaces
{
    public interface IBanner_Category
    {
        Result<Banner_Category> Add(Banner_Category model);

        Result<Banner_Category> Delete(Banner_Category model);

        Result<int> GroupDelete(List<int> ids);

        Result<Banner_Category> Update(Banner_Category model);

        Result<Banner_Category> QuerySinge(object ID);

        Result<IEnumerable<Banner_Category>> Query();

        Result<IEnumerable<Banner_Category>> Query(Expression<Func<Banner_Category, bool>> where);

        Result<IEnumerable<Banner_Category>> Query<TKey>(Expression<Func<Banner_Category, bool>> where, Expression<Func<Banner_Category, TKey>> order, bool isDesc);

        Result<IEnumerable<Banner_Category>> Query(int pageIndex, int pageSize, Expression<Func<Banner_Category, bool>> where, List<EntityFrameWork.Extend.Param> orderParamList, out int totalCount);

        Result<IEnumerable<Banner_Category>> Query<TKey>(int pageIndex, int pageSize, Expression<Func<Banner_Category, bool>> where, Expression<Func<Banner_Category, TKey>> order, bool isDesc, out int totalCount);
    }
}
