using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookKeeperCommon.BO;
using System.Data.Entity;


namespace BookKeeperCommon.Repos
{
    public class UserRepo
    {
        private MssqlContext context = new MssqlContext();
        
        public void Add(User user)
        {
            context.Users.Attach(user);
            context.Entry(user).State = EntityState.Added;
            context.SaveChanges(); 
        }
            

        public void Remove(int id)
        {
            User user = context.Users.Find(id);
            context.Users.Attach(user);
            context.Entry(user).State = EntityState.Deleted;
            context.SaveChanges(); 
        }

        public void Update(User userToBeUpdated)
        {
            User user = context.Users.Find(userToBeUpdated.ID);
            user.Name = userToBeUpdated.Name;
            user.Password = userToBeUpdated.Password;
            context.Users.Attach(user);
            context.Entry(user).State = EntityState.Modified;
            context.SaveChanges();
        }

        public List<User> GetList()
        {
            List<User> users = context.Users.ToList<User>();
            
            return users;
        }

        public void ShowUsers(List<User> users)
        {
            foreach(User user in users)
            {
                Console.WriteLine($"{user.ID}  {user.Name}  {user.Password}");
            }
           
        }

    }
}
