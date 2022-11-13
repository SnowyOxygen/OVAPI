using Microsoft.AspNetCore.Mvc;
using OVAPI.Business;
using OVAPI.Services;

namespace OVAPI.Controllers
{
    public class UserController : Controller
    {
        private readonly DataContext _dataContext;

        public UserController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpGet("/user/get")]
        public ActionResult<List<User>> Get()
        {
            List<User> users = new UserService(_dataContext).Get();

            return Ok(users);
        }

        [HttpGet("/user/get/{id}")]
        public ActionResult<User> Get(int id)
        {
            User? user = new UserService(_dataContext).Get(id);

            if(user != null)
            {
                return Ok(user);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost("/user/post")]
        public ActionResult Add(User user)
        {
            try
            {
                new UserService(_dataContext).Add(user);
                return Created($"/user/{user.Id}", user);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("/user/put")]
        public ActionResult Update(User user)
        {
            bool updated = new UserService(_dataContext).Update(user);

            return updated ? Ok() : NotFound();
        }

        [HttpDelete("/user/delete/{id}")]
        public ActionResult Delete(int id)
        {
            bool deleted = new UserService(_dataContext).Delete(id);

            return deleted ? Ok() : NotFound();
        }
    }
}
