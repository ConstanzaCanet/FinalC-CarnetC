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
          [HttpGet("/api/[controller]/[action]")]
          public List<User> GetUser(int id)
          {
              return UserHandler.GetUser(id);
          }
          */
        [HttpGet("/api/[controller]/[action]")]
        public List<User> GetUserForName(string userName)
        {
            return UserHandler.GetUserForUserName(userName);
        }


        [HttpPost("/api/[controller]/[action]")]
        public List<User> LogIn(string userName, string password)
        {
            return UserHandler.LogIn(userName, password);

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
            return UserHandler.ChangeUser(new User
            {
                Id = user.Id,
                Lastname = user.LastName,
                Password = user.Password,
                Email = user.Email,
                Name = user.Name,
                UserName = user.UserName,
            });
        }



        [HttpDelete]
        public bool DeleteUser([FromBody] int id)
        {
            return UserHandler.DeleteUser(id); 
        }



    }
}
