using DataAccesLayer.EF;
using DataAccesLayer.EF.Models;
using DataAccesLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer.Repos
{
    public class UserRepo : IRepo<User, string, bool>, IAuth<User>
    {
        private readonly DataContext db;
        public UserRepo(DataContext db)
        {
            this.db = db;
        }

        public User Authorization(string userName, string password)
        {
            var user = (from u in db.Users.ToList()
                       where u.UserName.Equals(userName) && u.Password.Equals(password)
                       select u).FirstOrDefault();
            return user;
        }

        public bool Create(User cLass)
        {
            throw new NotImplementedException();
        }

        public bool Delete(string id)
        {
            throw new NotImplementedException();
        }

        public User Get(string id)
        {
            throw new NotImplementedException();
        }

        public List<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public bool Update(User cLass)
        {
            throw new NotImplementedException();
        }
    }
}
