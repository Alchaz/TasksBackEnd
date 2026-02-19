using Dtos;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using Swashbuckle.AspNetCore.Annotations;

namespace ClienteBakEnd.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _taskService;

        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }


        [HttpGet]
        public ActionResult<IEnumerable<TaskReadDto>> GetAll( )
        {
            try
            {
                var tasks = _taskService.ListTasks();
                return Ok(tasks);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while processing your request. "+ ex.Message );
            }
        }

 


      
        [HttpPost]
        public ActionResult Create([FromBody] TaskCreateDto dto)
        {
            try
            {
                _taskService.CreateTask(dto);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while processing your request. " + ex.Message);
            }
        }

   
        [HttpPut("{id}")]
        public ActionResult  Update(int id, [FromBody] TaskUpdateDto dto)
        {
            try
            {
                _taskService.UpdateTask(id, dto);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while processing your request. " + ex.Message);
            }
            
        }

  

    }
}
