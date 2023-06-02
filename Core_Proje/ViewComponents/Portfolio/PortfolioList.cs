using BusinessLayer.Concrete;
using DataAccesLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Core_Proje.ViewComponents.PortfolioList
{
    public class PortfolioList : ViewComponent
    {
        PortfolioManager portfolioManager = new PortfolioManager(new EfPortfolioDAL());
        public IViewComponentResult Invoke()
        {
            var varlues = portfolioManager.T_GetList();
            return View(varlues);
        }
    }
}
