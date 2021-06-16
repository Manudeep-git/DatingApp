using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        //usercontroller needs to communicate with the database
        private readonly DataContext _context;

        //DataContext is added because we need access to database
        public UsersController(DataContext context)
        {
            _context = context;
        }

        //api/users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers(){
            var users =  await _context.Users.ToListAsync();

            return users;
        }

        //api/users/3 - here 3 is id
        [HttpGet("{id}")]
        public async Task<ActionResult<AppUser>> GetUser(int id){
            var user = await _context.Users.FindAsync(id);
            return user;
        }

    }
}