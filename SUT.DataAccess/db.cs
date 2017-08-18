using SUT.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SUT.DataAccess
{
    public class db:DbContext
    {
        public db():base("name=SUT.Database")
        {

        }
        public virtual DbSet<Employee> Employees { get; set; }
    }
}
