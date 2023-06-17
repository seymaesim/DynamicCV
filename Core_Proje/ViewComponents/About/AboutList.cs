using BusinessLayer.Concrete;
using DataAccesLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Core_Proje.ViewComponents.About
{
    public class AboutList : ViewComponent
    {
        AboutManager aboutManager = new AboutManager(new EfAboutDAL());
        public IViewComponentResult Invoke()
        {
            var varlues = aboutManager.T_GetList().Where(x => x.Status == true).ToList();
            return View(varlues);
        }
    }
}
