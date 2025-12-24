using CodeFirstApproachWithAsnyc.Models;
using Microsoft.EntityFrameworkCore;

namespace CodeFirstApproachWithAsnyc.Repository
{
    public interface IDeptRepositiory
    {
        //Task---- void
        //Task<int>/Task<string>/Task<List<Dept>>/ Task<Emp>

        Task<IEnumerable<Department>> GetAllDepts();
        Task<Department> FindByDeptId(int id);
        Task AddDept(Department department);

        Task UpdateDept(int id,Department department);
        Task DeleteDept(int id);    
    }


    public class DeptRepository : IDeptRepositiory
    {
        private readonly HRSecondContext _context;
        public DeptRepository(HRSecondContext context)
        {
            _context = context;
        }
        public async Task AddDept(Department department)
        {
            _context.Departments.Add(department);
         await  _context.SaveChangesAsync();
        }

        public async Task DeleteDept(int id)
        {
            var  d= await _context.Departments.FindAsync(id);
            if (d != null)
            {
                _context.Departments.Remove(d);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Department?> FindByDeptId(int id)
        {
            return await _context.Departments.FindAsync(id);

          
        }

        public async Task<IEnumerable<Department>> GetAllDepts()
        {
            return await _context.Departments.ToListAsync();
        }

        public async Task UpdateDept(int id, Department department)
        {
        _context.Departments.Update(department);    

            
            await _context.SaveChangesAsync();
        }
    }



}
