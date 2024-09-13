using Microsoft.EntityFrameworkCore;

namespace PLACEMENT_2.Models

{
    public class DepartmentDBContext : DbContext
    {
        public DepartmentDBContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<departmentstaaf> Department { get; set; }
    }

}



