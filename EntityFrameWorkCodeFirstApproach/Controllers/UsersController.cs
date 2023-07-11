using EntityFrameWorkCodeFirstApproach.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EntityFrameWorkCodeFirstApproach.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserContext   userContext;

        public UsersController(UserContext userContext)
        {
            this.userContext = userContext;
        }


        //Get All Users
        [HttpGet]

        [Route("GetUsers")]
        public List<Users> GetUsers()
        {
            return userContext.Users.ToList();
        }

        //Get single user data via id
        [HttpGet]

        [Route("GetUser")]
        public Users GetUser(int id)
        {
            return  userContext.Users.Where(x =>x.ID == id).FirstOrDefault();
        }

        //All data of Users in Users Table.
        [HttpPost]

        [Route("AddUsers")]
        public string AddUser(Users users)
        {
            //string response = string.empty;
            userContext.Users.Add(users);
            userContext.SaveChanges();
            return "User Added";
        }

        //Update the User Data

        [HttpPut]
        [Route("UpdateUser")]

        public string UpdateUser(Users users)
        {
            userContext.Entry(users).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            userContext.SaveChanges();
            return "User Updated.";
        }

        // Delete User from Users Table

        [HttpDelete]
        [Route("DeleteUser")]

        public string DeleteUser(int id)      
        {
            Users user = userContext.Users.Where(x => x.ID == id).FirstOrDefault();
            if(user != null)
            {
            userContext.Users.Remove(user); 
            userContext.SaveChanges();
            return "User Delelted";
            }
            else
            {
                return "No user found.";
            }
        }
    }
    
}
