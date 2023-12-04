using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer.Interfaces
{
    public interface IRepo<CLASS, ID, RTN>
    {
        RTN Create(CLASS cLass);
        CLASS Get(ID id);
        RTN Update(CLASS cLass);
        bool Delete(ID id);
        List<CLASS> GetAll();
    }
}
