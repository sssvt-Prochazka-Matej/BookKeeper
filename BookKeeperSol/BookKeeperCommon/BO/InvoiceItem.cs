using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookKeeperCommon.BO
{
    [Table("BK_INVOICE_ITEM")]
    public class InvoiceItem
    {
        [Key]
        [Column("ID")]
        public int ID { get; set; }
        
        [Column("NAME")]
        public string Name { get; set; }

        public InvoiceItem(string name)
        {

            this.Name = name;
            
        }

        public InvoiceItem()
        {


        }


    }
}
