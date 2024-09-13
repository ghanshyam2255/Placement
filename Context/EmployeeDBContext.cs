using Microsoft.EntityFrameworkCore;

namespace PLACEMENT_2.Models

{
    public class EmployeeDBContext : DbContext
    {
        public EmployeeDBContext(DbContextOptions <EmployeeDBContext> options) : base(options)
        {            
        }
        public DbSet<Employee> Employee { get; set;    } 
    }
    
}



