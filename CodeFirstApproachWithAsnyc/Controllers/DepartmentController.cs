using CodeFirstApproachWithAsnyc.Models;
using CodeFirstApproachWithAsnyc.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CodeFirstApproachWithAsnyc.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDeptRepositiory _deptrepo;
        public DepartmentController(IDeptRepositiory deptrepo)
        {
                _deptrepo= deptrepo;    
        }
        // GET: api/<DepartmentController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var deptdata=  await _deptrepo.GetAllDepts();
            return Ok(deptdata);
        }

        //public async Task<IEnumerable<Department>> Get()
        //{
        //    return await _deptrepo.GetAllDepts();
            
        //}


        // GET api/<DepartmentController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var dept = await _deptrepo.FindByDeptId(id);
            if (dept != null)
            {
                return Ok(dept);
            }
            return NotFound();
        }


        //public async Task<Department> Get(int id)
        //{
        //    return await _deptrepo.FindByDeptId(id);
           
        //}

        // POST api/<DepartmentController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Department value)
        {
            await _deptrepo.AddDept(value);

            return Ok(value);
        }


        //public async Task Post([FromBody] Department value)
        //{
        //    await _deptrepo.AddDept(value);
       //}


        // PUT api/<DepartmentController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Department value)
        {
            if (id != value.DeptID)
                return BadRequest();
            await _deptrepo.UpdateDept(id, value);
            return NoContent();

        }
        //public async Task Put(int id, [FromBody] Department value)
        //{
        //    await _deptrepo.AddDept(value);
        //}


        // DELETE api/<DepartmentController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _deptrepo.DeleteDept(id);
            return NoContent();
        }

        //public async Task Delete(int id)
        //{
        //    await _deptrepo.DeleteDept(id);
        //}



    }
}
