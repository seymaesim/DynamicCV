using BusinessLayer.Concrete;
using DataAccesLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Threading.Tasks;
using System;
using Microsoft.AspNetCore.Hosting;
using BusinessLayer.ValidationRules;
using FluentValidation;
using FluentValidation.Results;

namespace Core_Proje.Controllers
{
    public class PortfolioController : Controller
    {
        private readonly IWebHostEnvironment _iweb;
        PortfolioManager portfolioManager = new PortfolioManager(new EfPortfolioDAL());

        public PortfolioController(IWebHostEnvironment iweb)
        {
            _iweb = iweb;
        }

        public IActionResult Index()
        {
            var values = portfolioManager.T_GetList();
            return View(values);
        }
  
        [HttpGet]
        public IActionResult AddPortfolio()
        {
            ViewBag.v1 = "Ekleme";
            ViewBag.v2 = "Portföy";
            ViewBag.v3 = "Portföy Ekleme";
          


            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddPortfolio(Portfolio portfolio, IFormFile ImageUrl)
        {
            PortfolioValidator validations = new PortfolioValidator();
            ValidationResult result = validations.Validate(portfolio);

            if (result.IsValid)
            {
                if (ImageUrl != null && ImageUrl.Length > 0)
                {
                    var fileName = ImageUrl.FileName;
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/ultra_profile/images", fileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await ImageUrl.CopyToAsync(stream);
                        portfolio.ImageUrl = "/ultra_profile/images/" + fileName.ToString();
                    }
                }
                // Resim başarıyla yüklendi, işleme devam edebilirsiniz.

                portfolioManager.T_Add(portfolio);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();

        }
        public IActionResult DeletePortfolio(int ID)
        {
            var values = portfolioManager.T_GetByID(ID);
            portfolioManager.T_Delete(values);

            //datadan veri silindiğindedosya yolundanda resmi sileriz
            var fileName = values.ImageUrl.Split("/ultra_profile/images/")[1];
            var filePath = Path.Combine(_iweb.WebRootPath, "ultra_profile/images", fileName.ToString());
            FileInfo fi = new FileInfo(filePath);
            if (fi != null)
            {
                System.IO.File.Delete(filePath);
                fi.Delete();
            }

            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult EditPortfolio(int ID)
        {
            ViewBag.v1 = "Düzenleme";
            ViewBag.v2 = "Portföy";
            ViewBag.v3 = "Portföy Güncelleme";

            var values = portfolioManager.T_GetByID(ID);
            return View(values);
        }
        [HttpPost]
        public async Task<IActionResult> EditPortfolio(Portfolio portfolio, IFormFile ImageUrl)
        {
            PortfolioValidator validations = new PortfolioValidator();
            ValidationResult result = validations.Validate(portfolio);

            if (result.IsValid)
            {
                var fileName = portfolio.ImageUrl.Split("/ultra_profile/images/")[1];
                var filePath = Path.Combine(_iweb.WebRootPath, "ultra_profile/images", fileName.ToString());
                FileInfo fi = new FileInfo(filePath);
                if (fi != null)
                {
                    System.IO.File.Delete(filePath);
                    fi.Delete();
                }
                if (ImageUrl != null && ImageUrl.Length > 0)
                {
                    if (ImageUrl.FileName == fileName)
                    {
                        if (fi != null)
                        {
                            System.IO.File.Delete(filePath);
                            fi.Delete();
                        }

                    }
                    var fileName2 = ImageUrl.FileName.ToString().Split(Path.GetExtension(ImageUrl.FileName))[0] + Path.GetExtension(ImageUrl.FileName);
                    var filePath2 = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/ultra_profile/images", fileName2);

                    using (var stream = new FileStream(filePath2, FileMode.Create))
                    {
                        await ImageUrl.CopyToAsync(stream);
                        portfolio.ImageUrl = "/ultra_profile/images/" + fileName2.ToString();
                    }
                }
                portfolioManager.T_Update(portfolio);
                return RedirectToAction("Index");

            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();


        }
    }
}
