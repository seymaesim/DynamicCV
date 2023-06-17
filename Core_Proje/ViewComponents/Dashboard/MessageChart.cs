using BusinessLayer.Concrete;
using DataAccesLayer.Concrete;
using DataAccesLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System;
using System.Reflection;
using System.Text.Json;

namespace Core_Proje.ViewComponents.Dashboard
{
    public class MessageChart : ViewComponent
    {
    
        MessageManager messageManager = new MessageManager(new EfMessageDAL());

      

        public IViewComponentResult Invoke()
        {
            var _dbContext = new Context();
         
            List<Sample> products = new List<Sample>();
            using (var ctx = new Context())
            {
                using (var conn = ctx.Database.GetDbConnection())
                   
                using (var cmd = conn.CreateCommand())
                {
                    conn.Open();
                    
                    cmd.CommandText = "EXEC [dbo].[AylikToplamMesaj]";
                    using (var reader = cmd.ExecuteReader())
                    {

                        products = DataReaderMapToList<Sample>(reader);
                    }
                    conn.Close();
                }
            }

            return View(products.ToList());
        }
        public static List<T> DataReaderMapToList<T>(IDataReader dr)
        {
            List<T> list = new List<T>();
            T obj = default(T);
            while (dr.Read())
            {
                obj = Activator.CreateInstance<T>();
                foreach (PropertyInfo prop in obj.GetType().GetProperties())
                {
                    if (!object.Equals(dr[prop.Name], DBNull.Value))
                    {
                        prop.SetValue(obj, dr[prop.Name], null);
                    }
                }
                list.Add(obj);
            }
            return list;
        }

        public class Sample
        {
            public string aylar { get; set; }
            public int  toplam { get; set; }
        }


    }
}
