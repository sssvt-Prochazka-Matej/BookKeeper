using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookKeeperCommon.BO;
using System.Data.Entity;

namespace BookKeeperCommon.Repos
{
    public class InvoiceItemRepo
    {
        private MssqlContext context = new MssqlContext();

        public void Add(InvoiceItem item)
        {
            context.InvoiceItems.Attach(item);
            context.Entry(item).State = EntityState.Added;
            context.SaveChanges();
        }


        public void Remove(int id)
        {
            InvoiceItem item = context.InvoiceItems.Find(id);
            context.InvoiceItems.Attach(item);
            context.Entry(item).State = EntityState.Deleted;
            context.SaveChanges();
        }

        public void Update(InvoiceItem invoiceItemToBeUpdated)
        {
            InvoiceItem item = context.InvoiceItems.Find(invoiceItemToBeUpdated.ID);
            item.Name = invoiceItemToBeUpdated.Name;
            context.InvoiceItems.Attach(item);
            context.Entry(item).State = EntityState.Modified;
            context.SaveChanges();
            
        }
    }
}
