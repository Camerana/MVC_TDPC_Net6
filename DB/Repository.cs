using MVC_TDPC_Net6.DB.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_TDPC_Net6.DB
{
    public class Repository
    {
        private DBContext DBContext;
        public Repository(DBContext DBContext)
        {
            this.DBContext = DBContext;
        }
        public List<User> GetUsers()
        {
            //select * from users
            List<User> result = this.DBContext.Users.ToList();
            return result;
        }
        public User GetUserByID(string id)
        {
            //select * from user where id = "id"
            User result = this.DBContext.Users.Where(p => p.ID.ToString() == id).FirstOrDefault();
            return result;
        }
        public List<User> GetUsersWithFilter(string filter)
        {
            //select * from users where nome like "%filter%"
            //or cognome like "%filter%"
            List<User> result = this.DBContext.Users
                .Where(p => p.Nome.Contains(filter)
                || p.Cognome.Contains(filter)).ToList();
            return result;
        }
        public void InsertUser(User user)
        {
            this.DBContext.Users.Add(user);
            this.DBContext.SaveChanges();
        }
        public void UpdateUser(User user)
        {
            this.DBContext.Users.Update(user);
            this.DBContext.SaveChanges();
        }
        public void DeleteUser(string ID)
        {
            User toDelete = this.DBContext.Users
                    //.Where(p => p.ID != null && p.ID.Value.ToString() == ID) nel caso fosse nullable
                    .Where(p => p.ID.ToString() == ID)
                    .FirstOrDefault();
            this.DBContext.Users.Remove(toDelete);
            this.DBContext.SaveChanges();
        }
    }
}
