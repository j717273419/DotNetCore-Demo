using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aspnet_core_efcore_demo.Models
{
    public class SqliteModel
    {
    }

    public class UserInfor
    {
        public string id { get; set; }
        public string userName { get; set; }
        public string userSex { get; set; }
    }
    public class RoleInfor
    {
        public string id { get; set; }
        public string roleName { get; set; }
        public string roleDescription { get; set; }
    }
    /// <summary>
    /// EF Core上下文
    /// </summary>
    public class YpfDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source=db\YpfDb.db");
            base.OnConfiguring(optionsBuilder);
        }
        public DbSet<UserInfor> UserInfors { get; set; }
        public DbSet<RoleInfor> RoleInfors { get; set; }
    }
}
