using BusinessLayer.Concrete;
using DataAccesLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Core_Proje.ViewComponents.SkillList
{
    public class SkillList : ViewComponent
    {
        SkillManager skillManager = new SkillManager(new EfSkillDAL());
        public IViewComponentResult Invoke()
        {
            var varlues = skillManager.T_GetList();
            return View(varlues);
        }

    }
   
}
