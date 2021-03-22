using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookKeeperCommon.BO
{
    [Table("BK_User")]
    public class User
    {
        
        [Key]
        [Column("ID")]
        public int ID { get; set; }

        [Column("Name")]
        public string Name { get; set; }

        [Column("Password")]
        public string Password { get; set; }

        public User( string name, string password)
        {
            
            this.Name = name;
            this.Password = password;
        }
        public User() { }

        public User(int id, string name, string password)
        {
            this.ID = id;
            this.Name = name;
            this.Password = password;
        }
    }


}
