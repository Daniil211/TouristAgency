using Application.Database;
using Application.Database.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Application.WebApi.Controllers
{
    [EnableCors("AllowAllOrigins")]
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly TourAgencyContext _context;

        public UserController(TourAgencyContext context)
        {
            _context = context;
        }

        [HttpGet(Name = "GetUsers")]
        public ActionResult GetTour()
        {
            return Ok(_context.Users.ToList());
        }
        [HttpGet("{id}", Name = "GetUser")]
        public ActionResult GetTourId(int id)
        {
            var user = _context.Users.FirstOrDefault(t => t.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPost(Name = "CreateUser")]
        public ActionResult CreateTour([FromBody] User user)
        {
            if (user == null)
            {
                return NotFound();
            }
            _context.Users.Add(user);
            _context.SaveChanges();
            return CreatedAtRoute("GetUser", new { id = user.Id }, user);
        }

        [HttpDelete("{id}", Name = "DeleteUser")]
        public ActionResult DeleteTour(int id)
        {
            var tour = _context.Users.FirstOrDefault(t => t.Id == id);
            if (tour == null)
            {
                return NotFound();
            }
            _context.Users.Remove(tour);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpPut("{id}", Name = "UpdateUser")]
        public ActionResult UpdateTour(int id, [FromBody] User user)
        {
            var existingTour = _context.Users.FirstOrDefault(t => t.Id == id);
            if (existingTour == null)
            {
                return NotFound();
            }
            existingTour.Username = user.Username;
            existingTour.Password = user.Password;
            existingTour.Age = user.Age;
            existingTour.IsPremiumMember = user.IsPremiumMember;
            existingTour.Role = user.Role;
            existingTour.DateCreated = user.DateCreated;
            existingTour.Fio = user.Fio;
            existingTour.DateOfBirth = user.DateOfBirth;
            existingTour.Phone = user.Phone;
            _context.SaveChanges();
            return NoContent();
        }
    }
}
