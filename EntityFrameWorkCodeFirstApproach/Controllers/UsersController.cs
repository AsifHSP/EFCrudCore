using EntityFrameWorkCodeFirstApproach.Models;
using Microsoft.AspNetCore.Mvc;

namespace EntityFrameWorkCodeFirstApproach.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly CurdDbContext crudDbContext;

        public UsersController(CurdDbContext crudDbContext)
        {
            this.crudDbContext = crudDbContext;
        }


        //Get All Users
        [HttpGet]

        [Route("GetUsers")]
        public List<Users> GetUsers()
        {
            return crudDbContext.Users.ToList();
        }

        //Get single user data via id
        [HttpGet]

        [Route("GetUser")]
        public Users GetUser(int id)
        {
            return crudDbContext.Users.Where(x => x.ID == id).FirstOrDefault();
        }

        //Insert data of Users in Users Table.
        [HttpPost]

        [Route("AddUsers")]
        public string AddUser(Users users)
        {
            //string response = string.empty;
            crudDbContext.Users.Add(users);
            crudDbContext.SaveChanges();
            return "User Added";
        }

        //Update the User Data

        [HttpPut]
        [Route("UpdateUser")]

        public string UpdateUser(Users users)
        {
            crudDbContext.Entry(users).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            crudDbContext.SaveChanges();
            return "User Updated.";
        }

        // Delete User from Users Table

        [HttpDelete]
        [Route("DeleteUser")]

        public string DeleteUser(int id)
        {
            Users user = crudDbContext.Users.Where(x => x.ID == id).FirstOrDefault();
            if (user != null)
            {
                crudDbContext.Users.Remove(user);
                crudDbContext.SaveChanges();
                return "User Delelted";
            }
            else
            {
                return "No user found.";
            }
        }
    }

}
