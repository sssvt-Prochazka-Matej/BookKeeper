using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookKeeperCommon.BO
{
    [Table("BK_INVOICE")]
    public class Invoice
    {
        [Key]
        [Column("ID")]
        public int ID { get; set; }

        [Column("ID_ITEM")]
        public int IDItem { get; set; }

        [Column("DESCRIPTION")]
        public string Description { get; set; }

        public Invoice(int id, int idi, string des)
        {
            this.ID = id;
            this.IDItem = idi;
            this.Description = des;
        }

        public Invoice( int idi, string des)
        {
            
            this.IDItem = idi;
            this.Description = des;
        }

        public Invoice()
        {
           
        }
    }
}
