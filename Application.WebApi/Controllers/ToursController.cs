using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Application.Database;
using Microsoft.EntityFrameworkCore;

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
        // GET: ToursController
        public ActionResult Index()
        {
            return Ok(_context.Tours.ToList());
        }
    }
}
