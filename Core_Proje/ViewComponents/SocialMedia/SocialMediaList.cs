using BusinessLayer.Concrete;
using DataAccesLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Core_Proje.ViewComponents.SocialMedia
{
    public class SocialMediaList : ViewComponent
    {
        SocialMediaManager socialmediaManager = new SocialMediaManager(new EfSocialMediaDAL());
        public IViewComponentResult Invoke()
        {
            var values = socialmediaManager.T_GetList();
            return View(values);
        }
    }
}
