using AutoMapper;
using BusinessLogisLayer.DTOs;
using BusinessLogisLayer.IServices;
using DataAccesLayer.EF.Models;
using DataAccesLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogisLayer.Services
{
    public class AuthService : IAuthService
    {
        private readonly IAuth<User> _auth;
        private readonly IRepo<Token, int, Token> _repo;
        public AuthService(IAuth<User> auth, IRepo<Token, int, Token> repo)
        {
            this._auth = auth;
            this._repo = repo;
        }
        public bool IsTokenValid(string token)
        {
            var data = from tk in _repo.GetAll()
                       where tk.TokenKey.Equals(token) && tk.ExpiredAt == null
                       select tk;
            return data.Any();
        }

        public TokenDTO LogIn(string userName, string password)
        {
            var data = _auth.Authorization(userName, password);

            if(data != null)
            {
                var token = new Token();
                token.TokenKey = Guid.NewGuid().ToString();
                token.CreatedAt = DateTime.Now;
                token.ExpiredAt = null;
                token.UserName = userName;

                var tk = _repo.Create(token);

                var config = new MapperConfiguration(cfg => {
                    cfg.CreateMap<Token, TokenDTO>();
                });
                var mapper = new Mapper(config);
                var ret = mapper.Map<TokenDTO>(tk);

                return ret;
            }
            return null;
        }
    }
}
