﻿using BusinessLayer.Concrete;
using DataAccesLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Threading.Tasks;
using System;

namespace Core_Proje.Controllers
{
    public class ExperiencesController : Controller
    {
        ExperienceManager experienceManager = new ExperienceManager(new EfExperienceDAL());
        public IActionResult Index()
        {
            ViewBag.v1 = "Listeleme";
            ViewBag.v2 = "Deneyim";
            ViewBag.v3 = "Deneyim Listesi";
            var experienceList = experienceManager.T_GetList();
            return View(experienceList);
         
        }
        [HttpGet]
        public IActionResult AddExperience()
        {
            ViewBag.v1 = "Ekleme";
            ViewBag.v2 = "Deneyim";
            ViewBag.v3 = "Deneyim Ekleme";

            return View();
        }
        [HttpPost]
        public IActionResult AddExperience(Experience experience)
        {
            experienceManager.T_Add(experience);
            return RedirectToAction("Index");
        }
        public IActionResult DeleteExperience(int ID)
        {
            var values = experienceManager.T_GetByID(ID);
            experienceManager.T_Delete(values);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult EditExperience(int ID)
        {
            ViewBag.v1 = "Düzenleme";
            ViewBag.v2 = "Deneyim";
            ViewBag.v3 = "Deneyim Güncelleme";

            var values = experienceManager.T_GetByID(ID);
            return View(values);
        }
        [HttpPost]
        public IActionResult EditExperience(Experience experience)
        {
            experienceManager.T_Update(experience);
            return RedirectToAction("Index");
        }
    }
}
