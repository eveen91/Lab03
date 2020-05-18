using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab03.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lab03.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        Users UserList = new Users();

        //post
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
                        UserList.users.Add(GivenUser);
                        UserList.SaveData();
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

        //get id
        [HttpGet("{Id}")]
        public User GetUserById(string Id)
        {
            var query = from user in UserList.users where user.ID.Equals(int.Parse(Id)) select user;
            return query.First();
        }

        //get
        [HttpGet]
        public List<User> GetAllUsers()
        {
            return UserList.users;
        }


        [HttpPut]
        public IActionResult UpdateUserById([FromBody] User GivenUser)
        {
            var user = UserList.users.Find(x => x.ID == GivenUser.ID);
            if (user == null)
            {
                return StatusCode(400, "Bad Request");
            }
            else
            {
                UserList.users[UserList.users.FindIndex(x => x.ID == GivenUser.ID)] = GivenUser;
                UserList.SaveData();
                return StatusCode(200, "ok");
            }
        }

        //?delete
        [HttpDelete("{Id}")]
        public IActionResult DeleteUserById(string id)
        {
            var user = UserList.users.Find(x => x.ID == int.Parse(id));
            if (user == null)
            {
                return StatusCode(400, "nope");
            }
            else
            {
                UserList.users.Remove(user);
                UserList.SaveData();
                return StatusCode(200, "ok");
            }
        }
    }
}