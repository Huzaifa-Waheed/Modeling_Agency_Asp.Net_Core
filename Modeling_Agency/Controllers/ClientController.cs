using Microsoft.AspNetCore.Mvc;
using Modeling_Agency.Data;
using Modeling_Agency.Models.DbModels;
using Modeling_Agency.Utility;

namespace Modeling_Agency.Controllers
{
    public class ClientController : Controller
    {
        private readonly ApplicationDbContext _context;
        public ClientController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Explore()
        {
            var models = _context.Models.Where(m => m.IsActive == true);

            return View(models);
        }

        public IActionResult DetailsPage(int id)
        {
            var model = _context.Models.FirstOrDefault(m => m.Id == id);
            return View(model);
        }

        [HttpPost]
        public JsonResult CreateBooking([FromBody]HireRecord hireRecord)
        {
            if(hireRecord != null)
            {
                hireRecord.ClientId = HttpContext.Session.GetString("UserId");
                hireRecord.State = StatusSD.PENDING;
                hireRecord.StateDate = DateTime.Now;
                hireRecord.IsActive = true;

                _context.HireRecords.Add(hireRecord);
                _context.SaveChanges();
                return Json(new { message = "Your booking has been successfully submitted." });
            }
            return Json(new { message = "An error occurred while processing your booking." });
        }
    }
}
