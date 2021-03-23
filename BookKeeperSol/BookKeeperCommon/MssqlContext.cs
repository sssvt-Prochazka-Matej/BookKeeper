using System;

using System.Data.Entity;
using BookKeeperCommon.BO;

namespace BookKeeperCommon
{
    public class MssqlContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<InvoiceItem> InvoiceItems { get; set; }
        public DbSet<Invoice> Invoices { get; set; }


        public MssqlContext() : base("name=connectToDbString")
        {
            Database.SetInitializer<MssqlContext>(null);
        }
    }
}
