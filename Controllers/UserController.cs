using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MY_API.Data;
using MY_API.Models;
using MY_API.Models.Entities;

namespace MY_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ApplicationDbContext dbcontext;

        public UserController(ApplicationDbContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }

        [HttpGet]
        public IActionResult GetAllUsers()
        {
            var user = dbcontext.Users.ToList();
            return Ok(user);
        }

        [HttpPost]

        public IActionResult AddUser(AddUserDto newUser)
        {
            var userEntity = new User()
            {
                Name = newUser.Name,
                Email = newUser.Email,
                Password = newUser.Password,
                Phone_no = newUser.Phone_no
            };
            dbcontext.Users.Add(userEntity);
            dbcontext.SaveChanges();

            return Ok(newUser);
        }

        [HttpGet]
        [Route("{id:int}")]

        public IActionResult GetUserByid(int id)
        {
            var user = dbcontext.Users.Find(id);
            if (user == null)
            {
                return BadRequest("Error \n invalid Id");
            }

            return Ok(user);
        }

        [HttpPut]
        [Route("{id:int}")]

        public IActionResult ReplaceUser(int id, ReplaceUserDto replaceUser)
        {
            var user = dbcontext.Users.Find(id);
            if (user == null)
            {
                return BadRequest("Error \n invalid Id");
            }

            user.Name = replaceUser.Name;
            user.Email = replaceUser.Email;
            user.Password = replaceUser.Password;
            user.Phone_no = replaceUser.Phone_no;

            dbcontext.SaveChanges();
            return Ok(user);
        }

        [HttpDelete]
        [Route("{id:int}")]

        public IActionResult DeleteUser(int id)
        {
            var user = dbcontext.Users.Find(id);
            if (user == null)
            {
                return BadRequest("Error \n invalid Id");
            }
            dbcontext.Users.Remove(user);
            dbcontext.SaveChanges();

            return Ok(user);
        }
    }
}