using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer.Interfaces
{
    public interface IRepo<CLASS, RTN>
    {
        RTN Create(CLASS cLass);
        CLASS Get(int id);
        RTN Update(CLASS cLass);
        CLASS Delete(int id);
        List<CLASS> GetAll();
    }
}
