using BusinessLayer.Concrete;
using DataAccesLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Reflection;

namespace Core_Proje.ViewComponents.Contact
{
    public class SendMessage : ViewComponent
    {
        MessageManager messageManager = new MessageManager(new EfMessageDAL());
        [HttpGet]
        public IViewComponentResult Invoke()
        {
            return View();
        }
        [HttpPost]
        public IViewComponentResult InvokePost(Message message)
        {
            message.Date = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            message.Status = true;
            messageManager.T_Add(message);
            return View();
        }
    }
}
