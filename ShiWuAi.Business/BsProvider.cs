using ShiWuAi.Business.Impl;
using ShiWuAi.Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShiWuAi.Business
{
    public class BsProvider
    {
        public static IT CreateBusiness<IT>() where IT : class
        {
            Type type = Type.GetType(typeof(BsProvider).Assembly.GetName().Name + ".Impl." + typeof(IT).Name.Substring(1) + "Impl");
            return (IT)Activator.CreateInstance(type);
        }

        public static ICommon<T> CreateCommon<T>() where T : class
        {

            return new CommonImpl<T>();
        }
    }
}
