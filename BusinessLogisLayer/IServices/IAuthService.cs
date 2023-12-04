using BusinessLogisLayer.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogisLayer.IServices
{
    public interface IAuthService
    {
        TokenDTO LogIn(string userName, string password);
        bool IsTokenValid(string token);
    }
}
