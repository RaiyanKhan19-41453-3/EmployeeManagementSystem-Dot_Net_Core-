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
    public class EmployeeAttendanceRepo : IRepo<tblEmployeeAttendance, int,  bool>
    {
        private readonly DataContext db;
        public EmployeeAttendanceRepo(DataContext db)
        { 
            this.db = db; 
        }

        public bool Create(tblEmployeeAttendance cLass)
        {
            db.tblEmpAttendances.Add(cLass);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            db.tblEmpAttendances.Remove(Get(id));
            return db.SaveChanges() > 0;
        }

        public tblEmployeeAttendance Get(int id)
        {
            return db.tblEmpAttendances.Find(id);
        }

        public List<tblEmployeeAttendance> GetAll()
        {
            return db.tblEmpAttendances.Include(e => e.Employee).ToList();
        }

        public bool Update(tblEmployeeAttendance cLass)
        {
            db.Entry(Get(cLass.Id)).CurrentValues.SetValues(cLass);
            return db.SaveChanges() > 0;
        }
    }
}
