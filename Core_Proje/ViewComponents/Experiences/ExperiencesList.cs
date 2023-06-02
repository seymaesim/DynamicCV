
using BusinessLayer.Concrete;
using DataAccesLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Core_Proje.ViewComponents.Experiences
{
    public class ExperiencesList : ViewComponent
    {
        ExperienceManager experienceManager = new ExperienceManager(new EfExperienceDAL());
        public IViewComponentResult Invoke()
        {
            var values = experienceManager.T_GetList();
            return View(values);
        }
    }
}
