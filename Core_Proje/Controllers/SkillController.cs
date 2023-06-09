using BusinessLayer.Concrete;
using Core_Proje.ViewComponents.SkillList;
using DataAccesLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting.Internal;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Core_Proje.Controllers
{
    public class SkillController : Controller
    {
        SkillManager skillManager = new SkillManager(new EfSkillDAL());
        public IActionResult Index()
        {
            ViewBag.v1 = "Yetenek";
            ViewBag.v2 = "Yetenek Listesi";
            ViewBag.v3 = "Yetenek Listesi";
            var skillList = skillManager.T_GetList();
            return View(skillList);
        }
        [HttpGet]
        public IActionResult AddSkill()
        {
            ViewBag.v1 = "Yetenek";
            ViewBag.v2 = "Yetenek Ekleme";
            ViewBag.v3 = "Yetenek Ekleme";

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddSkill(Skill skill,IFormFile Icon)
        {

            if (Icon != null && Icon.Length > 0)
            {
               
                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(Icon.FileName);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/ultra_profile/icons", fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await Icon.CopyToAsync(stream);
                }
                if (skill.Icon == null)
                {
                    skill.Icon = "/ultra_profile/icons/" + fileName.ToString();
                }
                // Resim başarıyla yüklendi, işleme devam edebilirsiniz.
            }
          

            skillManager.T_Add(skill);
            return RedirectToAction("Index");
        }
    }
}
