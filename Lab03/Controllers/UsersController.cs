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
    public class UsersController : ControllerBase
    {
        Users users = new Users();

        //post
        [HttpPost]
        public void AddUser()
        {
        }

        //get id
        [HttpGet("{Id}")]
        public string GetUserById(string Id)
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
        [HttpPost]
        public void UpdateUserById()
        {

        }

        //?post
        public void DeleteUserById()
        {

        }
    }
}