using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Application.Database;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Application.Database.Models;
using Microsoft.AspNetCore.Mvc.NewtonsoftJson;

namespace Application.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DataController : ControllerBase
    {
        private readonly TourAgencyContext _context;

        public DataController(TourAgencyContext context)
        {
            _context = context;
        }

        [HttpGet(Name = "GetTours")]
        public ActionResult GetTour()
        {
            return Ok(_context.Tours.ToList());
        }
        [HttpGet("{id}", Name = "GetTour")]
        public ActionResult GetTourId(int id)
        {
            var tour = _context.Tours.FirstOrDefault(t => t.TourId == id);
            if (tour == null)
            {
                return NotFound();
            }
            return Ok(tour);
        }

        [HttpPost(Name = "CreateTour")]
        public ActionResult CreateTour([FromBody] Tour tour)
        {
            if (tour == null)
            {
                return NotFound();
            }
            _context.Tours.Add(tour);
            _context.SaveChanges();
            return CreatedAtRoute("GetTour", new { id = tour.TourId }, tour);
        }

        [HttpDelete("{id}", Name = "DeleteTour")]
        public ActionResult DeleteTour(int id)
        {
            var tour = _context.Tours.FirstOrDefault(t => t.TourId == id);
            if (tour == null)
            {
                return NotFound();
            }
            _context.Tours.Remove(tour);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpPut("{id}", Name = "UpdateTour")]
        public ActionResult UpdateTour(int id, [FromBody] Tour tour)
        {
            var existingTour = _context.Tours.FirstOrDefault(t => t.TourId == id);
            if (existingTour == null)
            {
                return NotFound();
            }
            existingTour.TourName = tour.TourName;
            existingTour.Description = tour.Description;
            existingTour.Price = tour.Price;
            _context.SaveChanges();
            return NoContent();
        }
    }
}
