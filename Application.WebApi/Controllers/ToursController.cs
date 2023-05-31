using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Application.Database;

namespace Application.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ToursController : ControllerBase
    {
        private readonly TourAgencyContext _context;
        public ToursController(TourAgencyContext context)
        {
            _context = context;
        }

        [HttpGet(Name = "GetTours")]
        // GET: ToursController
        public ActionResult Index()
        {
            return Ok(_context.Tours.ToList());
        }

        // GET: ToursController/Details/5
        /*public ActionResult Details(int id)
           {
               Tour tour = _tA.Tours.Find(id);
               if (tour == null)
               {
                   return NotFound();
               }

               return Ok(tour);
           }

        /*   // GET: ToursController/Create
           public ActionResult Create()
           {
               return View();
           }

           // POST: ToursController/Create
           [HttpPost]
           [ValidateAntiForgeryToken]
           public ActionResult Create(IFormCollection collection)
           {
               try
               {
                   return RedirectToAction(nameof(Index));
               }
               catch
               {
                   return View();
               }
           }

           // GET: ToursController/Edit/5
           public ActionResult Edit(int id)
           {
               return View();
           }

           // POST: ToursController/Edit/5
           [HttpPost]
           [ValidateAntiForgeryToken]
           public ActionResult Edit(int id, IFormCollection collection)
           {
               try
               {
                   return RedirectToAction(nameof(Index));
               }
               catch
               {
                   return View();
               }
           }

           // GET: ToursController/Delete/5
           public ActionResult Delete(int id)
           {
               return View();
           }

           // POST: ToursController/Delete/5
           [HttpPost]
           [ValidateAntiForgeryToken]
           public ActionResult Delete(int id, IFormCollection collection)
           {
               try
               {
                   return RedirectToAction(nameof(Index));
               }
               catch
               {
                   return View();
               }
           }*/
    }
}
