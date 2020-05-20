using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab03.Models;
using Lab03.Set;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lab03.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        Users UserList = new Users();

        /* METHOD: POST
           URI:https://localhost:44326/api/Users
           BODY:
           {
           "ID":5,
            "Name":"asd",
            "Surname":"jlk",
            "EMail":"aaa@3123"
            }*/
        [HttpPost]
        public IActionResult AddUser([FromBody] User GivenUser)
        {
            //not null
            if (GivenUser.EMail != "" && GivenUser.ID != 0 && GivenUser.Name != "" && GivenUser.Surname != "")
            {
                if (UserList.users.Find(x => x.ID == GivenUser.ID) == null)
                {
                    try
                    {
                        UserList.AddUser(GivenUser);
                        return StatusCode(200, "Ok");
                    }
                    catch
                    {
                        return StatusCode(400, "Bad Request");
                    }
                }
                else
                {
                    return StatusCode(409, "Conflict, user with this id exist");
                }
            }
            else
            {
                return StatusCode(400, "Bad Request");
            }
        }

        //Method:GET
        //URI:https://localhost:44326/api/Users/3
        [HttpGet("{Id}")]
        public User GetUserById(string Id)
        {
            var query = from user in UserList.users where user.ID.Equals(int.Parse(Id)) select user;
            return query.First();
        }

        //Method:GET
        //URI:https://localhost:44326/api/Users/
        [HttpGet]
        public List<User> GetAllUsers()
        {
            return UserList.users;
        }

        /* METHOD: PUT
           URI:https://localhost:44326/api/Users/5
           BODY:
           {
           "ID":5,
           "Name":"asd",
           "Surname":"jlk",
           "EMail":"aaa@3123"
            }*/
        [HttpPut("{Id}")]
        public IActionResult UpdateUserById(string Id,[FromBody] User GivenUser)
        {
            var user = UserList.users.Find(x => x.ID == int.Parse(Id));
            if (user == null)
            {
                return StatusCode(400, "User not found");
            }
            else
            {
                UserList.UpdateUser(Id, GivenUser);
                return StatusCode(200, "ok");
            }
        }
        //Method:DELETE
        //URI:https://localhost:44326/api/Users/5
        [HttpDelete("{Id}")]
        public IActionResult DeleteUserById(string Id)
        {
            var user = UserList.users.Find(x => x.ID == int.Parse(Id));
            if (user == null)
            {
                return StatusCode(400, "User not found");
            }
            else
            {
                UserList.RemoveUser(Id);
                return StatusCode(200, "ok");
            }
        }
    }
}