using BusinessLayer.Concrete;
using DataAccesLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Core_Proje.ViewComponents.Service
{
    public class ServiceList : ViewComponent
    {
        ServiceManager serviceManager = new ServiceManager(new EfServiceDAL());
        public IViewComponentResult Invoke()
        {
            var varlues = serviceManager.T_GetList();
            return View(varlues);
        }
    }


}
