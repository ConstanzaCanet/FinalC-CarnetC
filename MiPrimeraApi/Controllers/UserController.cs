using Microsoft.AspNetCore.Mvc;
using MiPrimeraApi.Controllers.DTOS;
using MiPrimeraApi.Models;
using MiPrimeraApi2.Repository;

namespace MiPrimeraApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
      /*  [HttpGet(Name = "GetAllUsers")]

        public List<User> GetUsers()
        {
            return UserHandler.GetUsers();
        }
      */

        [HttpGet(Name = "GetUser")]

        public List<User> GetUser([FromBody] int id)
        {
            return UserHandler.GetUser(id);
        }



        [HttpPost]
        public bool CreateNewUser([FromBody] PostUser user)
        {
            return UserHandler.CreateNewUser(new User
            {
                Lastname = user.LastName,
                Password = user.Password,
                Email = user.Email,
                Name = user.Name,
                UserName = user.UserName,
            });

        }


        [HttpPut]
        public bool ModifideUser([FromBody] PutUser user)
        {
            return UserHandler.ChangeNameUser(new User
            {
                Id = user.Id,
                Name = user.Name,
            });
        }



        [HttpDelete]
        public bool DeleteUser([FromBody] int id)
        {
            return UserHandler.DeleteUser(id); 
        }
    }
}
