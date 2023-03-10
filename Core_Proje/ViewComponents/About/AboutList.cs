using BusinessLayer.Concrete;
using DataAccesLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Core_Proje.ViewComponents.About
{
    public class AboutList : ViewComponent
    {
        AboutManager aboutManager = new AboutManager(new EfAboutDAL());
        public IViewComponentResult Invoke()
        {
            var varlues = aboutManager.T_GetList();
            return View(varlues);
        }
    }
}
