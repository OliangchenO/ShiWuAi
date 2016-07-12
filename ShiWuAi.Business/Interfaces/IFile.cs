using EntityFrameWork.Extend;
using ShiWuAi.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ShiWuAi.Business.Interfaces
{
    public interface IFile
    {
        Result<File> Add(File model);

        Result<File> Delete(File model);

        Result<int> GroupDelete(List<int> ids);

        Result<File> Update(File model);

        Result<File> QuerySinge(object ID);

        Result<IEnumerable<File>> Query();

        Result<IEnumerable<File>> Query(Expression<Func<File, bool>> where);

        Result<IEnumerable<File>> Query<TKey>(Expression<Func<File, bool>> where, Expression<Func<File, TKey>> order, bool isDesc);

        Result<IEnumerable<File>> Query(int pageIndex, int pageSize, Expression<Func<File, bool>> where, List<EntityFrameWork.Extend.Param> orderParamList, out int totalCount);

        Result<IEnumerable<File>> Query<TKey>(int pageIndex, int pageSize, Expression<Func<File, bool>> where, Expression<Func<File, TKey>> order, bool isDesc, out int totalCount);
    }
}
