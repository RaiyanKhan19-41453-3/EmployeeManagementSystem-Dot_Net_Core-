﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer.Interfaces
{
    public interface IAuth<CLASS>
    {
        CLASS Authorization(string userName,  string password);
    }
}
