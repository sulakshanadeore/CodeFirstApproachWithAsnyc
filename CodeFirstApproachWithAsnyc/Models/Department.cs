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
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EmpId { get; set; }

        public string EmpName { get; set; }

        public int DeptID { get; set; }

        [ForeignKey("DeptID")]
        public Department Department { get; set; }

        public ICollection<EmpSkills> EmpSkills { get; set; }
    }



    public class Skills
    {
        [Key]
        public int SkillID { get; set; }
        public string SkillName { get; set; }

        public ICollection<EmpSkills> EmpSkills { get; set; }
    }

    public class EmpSkills
    {

        public int Empdid { get; set; }
        public Employee employee { get; set; }

        public int SkillId { get; set; }
        public Skills skills {get; set; }

        public int ExperienceInYears { get; set; }
        public string SkillLevel { get; set; }//Beginner,Intermediate,Master
    }


    public class HRSecondContext : DbContext
    {
        public HRSecondContext(DbContextOptions<HRSecondContext> options):base(options)
        {
                
        }


        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }

        public DbSet<Skills> Skills { get; set; }
        public DbSet<EmpSkills> EmpSkills { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //  base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<EmpSkills>().HasKey(es => new { es.Empdid, es.SkillId });

            modelBuilder.Entity<EmpSkills>()
                .HasOne(es => es.employee)
                .WithMany(es => es.EmpSkills)
                .HasForeignKey(es => es.Empdid);

            modelBuilder.Entity<EmpSkills>().HasOne(es => es.skills)
                .WithMany(es => es.EmpSkills)
                .HasForeignKey(es => es.SkillId);



            modelBuilder.UseIdentityColumns(10, 1);
        }
    }
}
