using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Modeling_Agency.Data;
using Modeling_Agency.Models.DbModels;
using Modeling_Agency.Utility;

namespace Modeling_Agency.Controllers
{
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public AdminController(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Dashboard()
        {
            return View();
        }

        public IActionResult ManageModels()
        {
            var modelList = (from m in _context.Models
                             where m.IsActive == true
                             select m).ToList();
            return View(modelList);
        }

        public IActionResult AddModel()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddModel(Model model, IFormFile imageFile)
        {
            if (model != null && (imageFile != null || imageFile.Length != 0))
            {
                string wwwRootPath = _webHostEnvironment.WebRootPath;
                string fileName = Guid.NewGuid().ToString().Substring(12) + Path.GetExtension(imageFile.FileName);
                string path = Path.Combine(wwwRootPath, @"uploads\model");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                using (var fileStream = new FileStream(Path.Combine(path, fileName), FileMode.Create))
                {
                    imageFile.CopyTo(fileStream);
                }
                model.ImgUrl = @"\uploads\model\" + fileName;
                model.Availability = true;
                model.IsActive = true;

                _context.Models.Add(model);
                _context.SaveChanges();
            }
            else
            {
                ModelState.AddModelError("", "Please fill all the fields");
                return View();
            }
            return RedirectToAction("ManageModels");
        }

        public IActionResult EditModel(int id)
        {
            var model = _context.Models.Find(id);
            if (model == null)
            {
                return NotFound();
            }
            return View(model);
        }

        [HttpPost]
        public IActionResult EditModel(Model model, IFormFile? imageFile)
        {
            if (model != null)
            {
                if (imageFile != null)
                {
                    string wwwRootPath = _webHostEnvironment.WebRootPath;
                    string filePath = Path.Combine(wwwRootPath, @"uploads\model");
                    string fileName = Guid.NewGuid().ToString().Substring(12) + Path.GetExtension(imageFile.FileName);
                    if (!Directory.Exists(filePath))
                    {
                        Directory.CreateDirectory(filePath);
                    }

                    if (!string.IsNullOrEmpty(model.ImgUrl))
                    {
                        string oldImage = Path.Combine(wwwRootPath, model.ImgUrl.TrimStart('\\'));
                        if (System.IO.File.Exists(oldImage))
                        {
                            System.IO.File.Delete(oldImage);
                        }
                    }

                    using (var fileStream = new FileStream(Path.Combine(filePath, fileName), FileMode.Create))
                    {
                        imageFile.CopyTo(fileStream);
                    }
                    model.ImgUrl = @"\uploads\model\" + fileName;


                }

                try
                {
                    _context.Update(model);
                    _context.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                    ModelState.AddModelError("", ex.Message);
                    return View(model);
                }
            }
            else
            {
                ModelState.AddModelError("", "Please fill all the fields");
                return View();
            }
            return RedirectToAction("ManageModels");
        }

        [HttpDelete]
        public IActionResult DeleteModel(int id)
        {
            var model = _context.Models.Where(m => m.Id == id).FirstOrDefault();
            if (model != null)
            {
                _context.Models.Remove(model);
                _context.SaveChanges();
            }
            return RedirectToAction("ManageModels");
        }


        public IActionResult ModelRequests()
        {
            var modelApplications = (from ma in _context.ModelApplications
                                     where ma.ApplicationStatus == StatusSD.PENDING
                                     select ma).ToList();
            return View(modelApplications);
        }

        [HttpPost]
        public IActionResult AcceptModel(int id)
        {
            ModelApplication modelAppli = _context.ModelApplications.Where(m => m.Id == id).FirstOrDefault();
            if(modelAppli != null)
            {
                Model model = new()
                {
                    FirstName = modelAppli.FirstName,
                    LastName = modelAppli.LastName,
                    Email = modelAppli.Email,
                    Dob = modelAppli.Dob,
                    Location = modelAppli.Location,
                    Description = modelAppli.Description,
                    Rate = modelAppli.Rate,
                    ImgUrl = modelAppli.ImgUrl,
                    Gender = modelAppli.Gender,
                    Phone = modelAppli.Phone,
                    Weight = modelAppli.Weight,
                    Height = modelAppli.Height,
                    Category = modelAppli.Category
                };

                model.IsActive = true;
                model.Availability = true;

                modelAppli.ApplicationStatus = StatusSD.ACCEPT;

                _context.Models.Add(model);
                _context.SaveChanges();

            }
            return RedirectToAction("ModelRequests");
        }

        [HttpPost]
        public IActionResult RejectModel(int id)
        {
            var modelApplication = _context.ModelApplications.Where(ma => ma.Id == id).First();
            if (modelApplication != null) {
                modelApplication.ApplicationStatus = StatusSD.REJECT;
                _context.SaveChanges();
            }
            return RedirectToAction("ModelRequests");
        }

        public IActionResult Notifications()
        {
            return View();
        }
    }
}
