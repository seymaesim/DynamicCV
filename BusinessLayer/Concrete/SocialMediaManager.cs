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
    public class SocialMediaManager : ISocialMediaService
    {
        ISocialMediaDAL _socialMediaDAL;

        public SocialMediaManager(ISocialMediaDAL socialMediaDAL)
        {
            _socialMediaDAL = socialMediaDAL;
        }

        public void T_Add(SocialMedia t)
        {
            _socialMediaDAL.Insert(t);
        }

        public void T_Delete(SocialMedia t)
        {
            _socialMediaDAL.Delete(t);
        }

        public SocialMedia T_GetByID(int id)
        {
            return _socialMediaDAL.GetByID(id);
        }

        public List<SocialMedia> T_GetList()
        {
            return _socialMediaDAL.GetList();
        }

        public void T_Update(SocialMedia t)
        {
            _socialMediaDAL.Update(t);
        }
    }
}
