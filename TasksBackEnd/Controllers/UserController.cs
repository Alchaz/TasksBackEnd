using Dtos;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using Swashbuckle.AspNetCore.Annotations;

namespace ClienteBakEnd.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }


        [HttpGet]
        public ActionResult<IEnumerable<UserReadDto>> GetAll( )
        {
            try
            {
                var tasks = _userService.ListUsers();
                return Ok(tasks);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while processing your request. "+ ex.Message );
            }
        }

 


      
        [HttpPost]
        public ActionResult Create([FromBody] UserCreateDto dto)
        {
            try
            {
                _userService.CreateUser(dto);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while processing your request. " + ex.Message);
            }
        }

   
        [HttpPut("{id}")]
        public ActionResult  Update(int id, [FromBody] UserUpdateDto dto)
        {
            try
            {
                _userService.UpdateUser(id, dto);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while processing your request. " + ex.Message);
            }
            
        }

  

    }
}
