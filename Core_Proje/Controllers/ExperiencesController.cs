using BusinessLayer.Concrete;
using DataAccesLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Core_Proje.Controllers
{
    public class ExperiencesController : Controller
    {
        ExperienceManager experienceManager = new ExperienceManager(new EfExperienceDAL());
        public IActionResult Index()
        {
            ViewBag.v1 = "Listeleme";
            ViewBag.v2 = "Deneyim";
            ViewBag.v3 = "Deneyim Listesi";
            var experienceList = experienceManager.T_GetList();
            return View(experienceList);
         
        }
    }
}
