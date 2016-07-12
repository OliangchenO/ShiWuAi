using EntityFrameWork.Extend;
using ShiWuAi.Model.Common;
using ShiWuAi.Model.Tbk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ShiWuAi.Business.Interfaces
{
    public interface ITbkItem
    {
        Result<TbkItem> Add(TbkItem model);

        Result<TbkItem> Delete(TbkItem model);

        Result<int> GroupDelete(List<int> ids);

        Result<TbkItem> Update(TbkItem model);

        Result<TbkItem> QuerySinge(object ID);

        Result<IEnumerable<TbkItem>> Query();

        Result<IEnumerable<TbkItem>> Query(Expression<Func<TbkItem, bool>> where);

        Result<IEnumerable<TbkItem>> Query<TKey>(Expression<Func<TbkItem, bool>> where, Expression<Func<TbkItem, TKey>> order, bool isDesc);

        Result<IEnumerable<TbkItem>> Query(int pageIndex, int pageSize, Expression<Func<TbkItem, bool>> where, List<EntityFrameWork.Extend.Param> orderParamList, out int totalCount);

        Result<IEnumerable<TbkItem>> Query<TKey>(int pageIndex, int pageSize, Expression<Func<TbkItem, bool>> where, Expression<Func<TbkItem, TKey>> order, bool isDesc, out int totalCount);
    }
}
