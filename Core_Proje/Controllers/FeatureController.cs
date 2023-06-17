using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccesLayer.Concrete;
using DataAccesLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Core_Proje.Controllers
{
    public class FeatureController : Controller
    {
        FeatureManager featureManager = new FeatureManager(new EfFeatureDAL());
        public IActionResult Index()
        {
            ViewBag.v1 = "Listeleme";
            ViewBag.v2 = "Özellik";
            ViewBag.v3 = "Özellik Listesi";
            ViewBag.FeatureAct = "active";

            var values = featureManager.T_GetList();
            return View(values);
        }
        [HttpGet]
        public IActionResult AddFeature()
        {
            ViewBag.v1 = "Ekleme";
            ViewBag.v2 = "Özellik";
            ViewBag.v3 = "Özellik Ekleme";

            return View();
        }
        [HttpPost]
        public IActionResult AddFeature(Feature feature)
        {
            FeatureValidator validations = new FeatureValidator();
            ValidationResult result = validations.Validate((feature));

            if (result.IsValid)
            {
               
                var cont = new Context();
                var parameterReturn = new SqlParameter
                {
                    ParameterName = "ReturnValue",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Direction = System.Data.ParameterDirection.Output,
                };
                var resultSp = cont.Database.ExecuteSqlRaw("EXEC @returnValue = [dbo].[FeatureAddingBeforeUpdateStatus]", parameterReturn);
                int returnValue = (int)parameterReturn.Value; // 1 ise kayıt vardı pasif edildi, 0 ise kayıt yok baralı ekleme yapılabilir.

                featureManager.T_Add(feature);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();


        }
        public IActionResult DeleteFeature(int ID)
        {
            var values = featureManager.T_GetByID(ID);
            featureManager.T_Delete(values);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult EditFeature(int ID)
        {
            ViewBag.v1 = "Düzenleme";
            ViewBag.v2 = "Özellik";
            ViewBag.v3 = "Özellik Güncelleme";

            var values = featureManager.T_GetByID(ID);
            return View(values);
        }
        [HttpPost]
        public IActionResult EditFeature(Feature feature)
        {
            FeatureValidator validations = new FeatureValidator();
            ValidationResult result = validations.Validate((feature));

            if (result.IsValid)
            {
                var cont = new Context();
                var parameterReturn = new SqlParameter
                {
                    ParameterName = "ReturnValue",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Direction = System.Data.ParameterDirection.Output,
                };
                var resultSp = cont.Database.ExecuteSqlRaw("EXEC @returnValue = [dbo].[FeatureAddingBeforeUpdateStatus]", parameterReturn);
                int returnValue = (int)parameterReturn.Value; // 1 ise kayıt vardı pasif edildi, 0 ise kayıt yok baralı güncelleme yapılabilir.



                featureManager.T_Update(feature);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();

        }
    }
}
