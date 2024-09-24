using Microsoft.EntityFrameworkCore;
using Server.Models;

namespace Server.EFCore
{
    public class EFCoreContext:DbContext
    {
        private string _sqlcon = "Data Source=user.db";

        public EFCoreContext()
        {

        }

        public EFCoreContext(string sqlcon)
        {
            this._sqlcon = sqlcon;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(_sqlcon);
        }

        public DbSet<SysUserInfo> sysUserInfos { get; set; }
    }
}