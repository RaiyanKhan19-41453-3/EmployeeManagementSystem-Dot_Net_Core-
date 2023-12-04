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
    public class EmployeeRepo : IRepo<tblEmployee, int, bool>
    {
        private readonly DataContext db;
        public EmployeeRepo(DataContext db)
        {
            this.db = db;
        }

        public bool Create(tblEmployee cLass)
        {
            db.tblEmployees.Add(cLass);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            db.tblEmployees.Remove(Get(id));
            return db.SaveChanges() > 0;
        }

        public tblEmployee Get(int id)
        {
            return db.tblEmployees.Find(id);
        }

        public bool Update(tblEmployee cLass)
        {
            db.Entry(Get(cLass.employeeId)).CurrentValues.SetValues(cLass);
            return db.SaveChanges() > 0;
        }

        public List<tblEmployee> GetAll()
        {
            return db.tblEmployees.Include(i => i.employeeAttendances).ToList();
        }
    }
}
