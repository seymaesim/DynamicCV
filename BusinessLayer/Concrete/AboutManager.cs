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
    public class AboutManager : IAboutService
    {
        IAboutDAL _aboutDal;

        public AboutManager(IAboutDAL aboutDal)
        {
            _aboutDal = aboutDal;
        }

        public void T_Add(About t)
        {
            _aboutDal.Insert(t);
        }

        public void T_Delete(About t)
        {
            _aboutDal.Delete(t);
        }

        public About T_GetByID(int id)
        {
            return _aboutDal.GetByID(id);
             
        }

        public List<About> T_GetList()
        {
            return _aboutDal.GetList();
        }

        public void T_Update(About t)
        {
            _aboutDal.Update(t);
        }
    }
}
