using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer.Concrete
{
    public class Context : DbContext
    {
       protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=?;database = ?;integrated security = true;");
        }
        public DbSet<About> Abouts { get; set; } //Abouts tablo ismi
        public DbSet<Contact> Contacts { get; set; } //Contacts tablo ismi
        public DbSet<Experience>  Experiences { get; set; }  //Experiences tablo ismi
        public DbSet<Feature>  Features { get; set; } //Features tablo ismi
        public DbSet<Message>  Messages { get; set; } //Messages tablo ismi
        public DbSet<Portfolio>  Portfolios { get; set; } //Portfolios tablo ismi
        public DbSet<Service>  Services { get; set; } //Sevices tablo ismi
        public DbSet<Skill>  Skills { get; set; } //Skills tablo ismi
        public DbSet<SocialMedia>  SocialMedias { get; set; } //SocialMedias tablo ismi
        public DbSet<Testimonial>  Testimonials { get; set; } //Testimonials tablo ismi

    }
}
