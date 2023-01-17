using BusinessLayer.Concrete;
using DataAccesLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Core_Proje.ViewComponents.Fature
{
	public class FeatureList : ViewComponent
	{
		FeatureManager featureManager = new FeatureManager(new EfFeatureDAL());
		public IViewComponentResult Invoke()
		{
			var varlues = featureManager.T_GetList();
			return View(varlues);
		}
	}
}
