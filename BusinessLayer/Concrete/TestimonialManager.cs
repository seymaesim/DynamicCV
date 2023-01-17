using BusinessLayer.Abstract;
using DataAccesLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class TestimonialManager : ITestimonialService
    {
        ITestimonialDAL _testimonialDAL;

        public TestimonialManager(ITestimonialDAL testimonialDAL)
        {
            _testimonialDAL = testimonialDAL;
        }

        public void T_Add(Testimonial t)
        {
            _testimonialDAL.Insert(t);
        }

        public void T_Delete(Testimonial t)
        {
            _testimonialDAL.Delete(t);
        }

        public Testimonial T_GetByID(int id)
        {
            return _testimonialDAL.GetByID(id);
        }

        public List<Testimonial> T_GetList()
        {
            return _testimonialDAL.GetList();
        }

        public void T_Update(Testimonial t)
        {
            _testimonialDAL.Update(t);
        }
    }
}
