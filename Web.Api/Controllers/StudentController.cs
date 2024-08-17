using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Web.Api.Data;
using Web.Api.Module;

namespace Web.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public StudentController (ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Get()  
        {
            var student=_dbContext.Students.ToList();
            return Ok(student);
        }
        [HttpGet("{id}")]
       
        public IActionResult GetById(int id)
        {
            var student = _dbContext.Students.FirstOrDefault(x => x.Id == id);
           
          
          
            return Ok();
        }
        [HttpPost]
        public IActionResult Create([FromBody] Student student)
        {
            _dbContext.Students.Add(student);
            _dbContext.SaveChanges();
            return Ok();
        }
        [HttpPut]
        public IActionResult Update([FromBody] Student student)
        {
            _dbContext.Students.Update(student);
            _dbContext.SaveChanges();
            return Ok(); 
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _dbContext.Students.FirstOrDefault(x => x.Id == id);
            if(result == null)
            {
                return NotFound();

            }
            _dbContext.Remove(result);
            _dbContext.SaveChanges();
            return Ok();
        }
    
    

        
    }
}
