using CodeFirstApproachWithAsnyc.Models;
using System.Diagnostics.CodeAnalysis;

namespace CodeFirstApproachWithAsnyc.Repository
{
    public interface IEmployeeRepo
    {
        Task AddEmployee(Employee employee);

        Task<List<EmpSkills>> GetSkills(int id);

    }

    public class EmpRepo : IEmployeeRepo
    {
        private readonly HRSecondContext _context;
        public EmpRepo(HRSecondContext context)
        {
            _context = context;
        }
        public async Task AddEmployee(Employee employee)
        {
            _context.Employees.Add(employee);   
         await _context.SaveChangesAsync();
        }

        public async Task<List<EmpSkills>> GetSkills(int id)
        {
            List<EmpSkills> skill_list = new List<EmpSkills>();
            var skills = from e in _context.Employees
                         join es1 in _context.EmpSkills
                         on e.EmpId equals es1.Empdid
                         join s in _context.Skills
                         on es1.SkillId equals s.SkillID
                         where e.EmpId == id
                         select new {s.SkillID,e.EmpId,e.EmpName,s.SkillName,es1.ExperienceInYears, es1.SkillLevel };

           
            foreach (var item in skills)
            {
                skill_list.Add(new EmpSkills {
                    SkillId=item.SkillID,
                    Empdid=item.EmpId,
                    SkillLevel=item.SkillLevel,
                    ExperienceInYears=item.ExperienceInYears,
                   
                    
               } );
            }


            return skill_list;
        }
    }
}
