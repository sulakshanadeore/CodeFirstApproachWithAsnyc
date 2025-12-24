using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeFirstApproachWithAsnyc.Models
{
    public class Department
    {
        [Key]
        public int DeptID { get; set; }
        public string Dname { get; set; }
    }

    public class Employee
    {
        [Key]
        public int EmpId { get; set; }

        public string EmpName { get; set; }

        public int DeptID { get; set; }

        [ForeignKey("DeptID")]
        public Department Department { get; set; }

    }


    public class HRSecondContext : DbContext
    {
        public HRSecondContext(DbContextOptions<HRSecondContext> options):base(options)
        {
                
        }


        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
    }
}
