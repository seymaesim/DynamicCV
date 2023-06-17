using BusinessLayer.Concrete;
using DataAccesLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Core_Proje.ViewComponents.Fature
{
	public class FeatureList : ViewComponent
	{
		FeatureManager featureManager = new FeatureManager(new EfFeatureDAL());
		public IViewComponentResult Invoke()
		{
			var varlues = featureManager.T_GetList().Where(x => x.Status == true).ToList();
			return View(varlues);
		}
	}
}
