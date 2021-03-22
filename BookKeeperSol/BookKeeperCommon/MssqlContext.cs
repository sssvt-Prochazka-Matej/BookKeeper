using System;

using System.Data.Entity;
using BookKeeperCommon.BO;

namespace BookKeeperCommon
{
    public class MssqlContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public MssqlContext() : base("name=connectToDbString")
        {
            Database.SetInitializer<MssqlContext>(null);
        }
    }
}
