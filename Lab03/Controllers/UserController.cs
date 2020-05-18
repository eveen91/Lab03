using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lab03.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        //post
        public void AddUser()
        {
        }

        //get id
        public string GetUserById()
        {
            string user = "";
            return user;
        }

        //get
        [HttpGet]
        public List<string> GetAllUsers()
        {
            return new List<string> { "User1", "User2" };
        }

        //post
        public void UpdateUserById()
        {

        }

        //?post
        public void DeleteUserById()
        {

        }
    }
}