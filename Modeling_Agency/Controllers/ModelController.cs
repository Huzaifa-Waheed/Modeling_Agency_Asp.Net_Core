using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Modeling_Agency.Data;
using Modeling_Agency.Models.ViewModels;

namespace Modeling_Agency.Controllers
{
    public class ModelController : Controller
    {
        private readonly ApplicationDbContext _context;
        public ModelController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ModelInfo(int id)
        {
            ModelVM modelVM = new ModelVM();
            modelVM.model = _context.Models.FirstOrDefault(m => m.Id == 3);
            modelVM.hireRecords = _context.HireRecords.Where(hr => hr.ModelId == 3 && hr.IsActive == true)
                                                              .Include(hr => hr.client).ToList();
            modelVM.messages = _context.messages.Where(m => m.ModelId == 3)
                                                    .Include(m => m.client).ToList();
            return View(modelVM);
        }
    }
}
