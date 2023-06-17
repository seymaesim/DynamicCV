using BusinessLayer.Concrete;
using DataAccesLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Core_Proje.ViewComponents.Dashboard
{
    public class CarouselCardSkill : ViewComponent
    {
        PortfolioManager portfolioManager = new PortfolioManager(new EfPortfolioDAL());
        public IViewComponentResult Invoke()
        {
            var values = portfolioManager.T_GetList();
            return View(values);
        }

    }
}
