using EntityFrameWork.Extend;
using ShiWuAi.Model.Banner;
using ShiWuAi.Model.Common;
using ShiWuAi.Model.Tbk;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShiWuAi.Model
{
    public class DbContext : MyDbContext
    {
        public DbContext() : base("name=ShiWuAi_Db") { }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //创建表 
            //Database.SetInitializer(new DropCreateDatabaseAlways<DbContext>());
            //去除表明后缀
            modelBuilder.Conventions.Remove<System.Data.Entity.
            ModelConfiguration.Conventions.PluralizingTableNameConvention>();
        }


        public DbSet<Banner.Banner> Banner { get; set; }
        public DbSet<Banner_Category> Banner_Category { get; set; }
        public DbSet<File> File { get; set; }
        public DbSet<TbkItem> TbkItem { get; set; }
        public DbSet<TbkFavorites> TbkFavorites { get; set; }
    }
}
