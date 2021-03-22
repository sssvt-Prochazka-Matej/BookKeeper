using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookKeeperMain.bo;
using BookKeeperMain.Services;
using BookKeeperCommon.BO;
using BookKeeperCommon.Repos;

namespace BookKeeperMain
{
    class Program
    {
        static void Main(string[] args)
        {
            User user = new User("Ahoj", "heslo");
            
            MssqlRepo mssql = new MssqlRepo();

            mssql.Add(user);
            mssql.Remove(4);

            mssql.ShowUsers(mssql.GetList());

            Console.ReadKey(true);
        }
    }
}
