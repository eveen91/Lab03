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

        public void AddUser()
        {
        }

        public string GetUserById()
        {
            string user = "";
            return user;
        }

        public List<string> GetAllUsers()
        {
            return new List<string> { "User1", "User2" };
        }

        public void UpdateUserById()
        {

        }

        public void DeleteUserById()
        {

        }
    }
}