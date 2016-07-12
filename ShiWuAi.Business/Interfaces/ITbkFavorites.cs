using EntityFrameWork.Extend;
using ShiWuAi.Model.Tbk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ShiWuAi.Business.Interfaces
{
    public interface ITbkFavorites
    {
        Result<TbkFavorites> Add(TbkFavorites model);

        Result<TbkFavorites> Delete(TbkFavorites model);

        Result<int> GroupDelete(List<int> ids);

        Result<TbkFavorites> Update(TbkFavorites model);

        Result<TbkFavorites> QuerySinge(object ID);

        Result<IEnumerable<TbkFavorites>> Query();

        Result<IEnumerable<TbkFavorites>> Query(Expression<Func<TbkFavorites, bool>> where);

        Result<IEnumerable<TbkFavorites>> Query<TKey>(Expression<Func<TbkFavorites, bool>> where, Expression<Func<TbkFavorites, TKey>> order, bool isDesc);

        Result<IEnumerable<TbkFavorites>> Query(int pageIndex, int pageSize, Expression<Func<TbkFavorites, bool>> where, List<EntityFrameWork.Extend.Param> orderParamList, out int totalCount);

        Result<IEnumerable<TbkFavorites>> Query<TKey>(int pageIndex, int pageSize, Expression<Func<TbkFavorites, bool>> where, Expression<Func<TbkFavorites, TKey>> order, bool isDesc, out int totalCount);
        
    }
}
