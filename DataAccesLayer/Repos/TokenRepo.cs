using DataAccesLayer.EF;
using DataAccesLayer.EF.Models;
using DataAccesLayer.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer.Repos
{
    public class TokenRepo : IRepo<Token, int, Token>
    {
        private readonly DataContext db;
        public TokenRepo(DataContext db)
        {
            this.db = db;
        }

        public Token Create(Token cLass)
        {
            db.Tokens.Add(cLass);
            db.SaveChanges();
            return cLass;
        }

        public bool Delete(int id)
        {
            db.Tokens.Remove(Get(id));
            return db.SaveChanges() > 0;
        }

        public Token Get(int id)
        {
            return db.Tokens.Find(id);
        }

        public List<Token> GetAll()
        {
            return db.Tokens.Include(i => i.User).ToList();
        }

        public Token Update(Token cLass)
        {
            db.Entry(Get(cLass.Id)).CurrentValues.SetValues(cLass);
            db.SaveChanges();
            return Get(cLass.Id);
        }
    }
}
