using Microsoft.EntityFrameworkCore;

namespace PLACEMENT_2.Models

{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions <DBContext> options) : base(options)
        {            
        }
        public DbSet<Employee> Employee { get; set;    } 
        public DbSet<department> Department { get; set; }
    }
    
}



