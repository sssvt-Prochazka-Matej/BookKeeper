using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookKeeperCommon.BO;
using System.Data.Entity;

namespace BookKeeperCommon.Repos
{
    public class InvoiceRepo
    {
        private MssqlContext context = new MssqlContext();

        public void Add(Invoice invoice)
        {
            context.Invoices.Attach(invoice);
            context.Entry(invoice).State = EntityState.Added;
            context.SaveChanges();
        }


        public void Remove(int id)
        {
            Invoice invoice = context.Invoices.Find(id);
            context.Invoices.Attach(invoice);
            context.Entry(invoice).State = EntityState.Deleted;
            context.SaveChanges();
        }

        public void Update(Invoice invoiceToBeUpdated)
        {
            Invoice invoice = context.Invoices.Find(invoiceToBeUpdated.ID);
            invoice.IDItem = invoiceToBeUpdated.IDItem;
            invoice.Description = invoiceToBeUpdated.Description;
            context.Invoices.Attach(invoice);
            context.Entry(invoice).State = EntityState.Modified;
            context.SaveChanges();

        }
    }
}
