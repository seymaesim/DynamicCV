using BusinessLayer.Concrete;
using Core_Proje.ViewComponents.SkillList;
using DataAccesLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting.Internal;
using Newtonsoft.Json.Linq;
using System;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Core_Proje.Controllers
{
    public class SkillController : Controller
    {
        private readonly IWebHostEnvironment _iweb;

        SkillManager skillManager = new SkillManager(new EfSkillDAL());

        public SkillController(IWebHostEnvironment iweb)
        {
            _iweb = iweb;
        }

        public IActionResult Index()
        {
            ViewBag.v1 = "Listeleme";
            ViewBag.v2 = "Yetenek";
            ViewBag.v3 = "Yetenek Listesi";
            var skillList = skillManager.T_GetList();
            return View(skillList);
        }
        [HttpGet]
        public IActionResult AddSkill()
        {
            ViewBag.v1 = "Ekleme";
            ViewBag.v2 = "Yetenek";
            ViewBag.v3 = "Yetenek Ekleme";

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddSkill(Skill skill, IFormFile Icon)
        {
            if (Icon != null && Icon.Length > 0)
            {
                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(Icon.FileName);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/ultra_profile/icons", fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await Icon.CopyToAsync(stream);
                    skill.Icon = "/ultra_profile/icons/" + fileName.ToString();
                }
            }
            // Resim başarıyla yüklendi, işleme devam edebilirsiniz.

            skillManager.T_Add(skill);
            return RedirectToAction("Index");
        }
        public IActionResult DeleteSkill(int ID)
        {
            var values = skillManager.T_GetByID(ID);
            skillManager.T_Delete(values);

            //datadan veri silindiğindedosya yolundanda resmi sileriz
            var fileName = values.Icon.Split("/ultra_profile/icons/")[1];
            var filePath = Path.Combine(_iweb.WebRootPath, "ultra_profile/icons", fileName.ToString());
            FileInfo fi = new FileInfo(filePath);
            if (fi != null)
            {
                System.IO.File.Delete(filePath);
                fi.Delete();
            }

            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult UpdateSkill(int ID)
        {
            ViewBag.v1 = "Düzenleme";
            ViewBag.v2 = "Yetenek";
            ViewBag.v3 = "Yetenek Güncelleme";

            var values = skillManager.T_GetByID(ID);
            return View(values);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateSkill(Skill skill, IFormFile Icon)
        {
            var fileName = skill.Icon.Split("/ultra_profile/icons/")[1];
            var filePath = Path.Combine(_iweb.WebRootPath, "ultra_profile/icons", fileName.ToString());
            FileInfo fi = new FileInfo(filePath);
            if (fi != null)
            {
                System.IO.File.Delete(filePath);
                fi.Delete();
            }
            if (Icon != null && Icon.Length > 0)
            {
                if (Icon.FileName == fileName)
                {
                    if (fi != null)
                    {
                        System.IO.File.Delete(filePath);
                        fi.Delete();
                    }

                }
                var fileName2 = Guid.NewGuid().ToString() + Path.GetExtension(Icon.FileName);
                var filePath2 = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/ultra_profile/icons", fileName2);

                using (var stream = new FileStream(filePath2, FileMode.Create))
                {
                    await Icon.CopyToAsync(stream);
                    skill.Icon = "/ultra_profile/icons/" + fileName2.ToString();
                }
            }
            skillManager.T_Update(skill);
            return RedirectToAction("Index");
        }
    }
}
