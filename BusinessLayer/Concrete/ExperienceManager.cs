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
    public class ExperienceManager : IExperienceService
    {
        IExperienceDAL _experienceDAL;

        public ExperienceManager(IExperienceDAL experienceDAL)
        {
            _experienceDAL = experienceDAL;
        }

        public void T_Add(Experience t)
        {
            _experienceDAL.Insert(t);
        }

        public void T_Delete(Experience t)
        {
            _experienceDAL.Delete(t);
        }

        public Experience T_GetByID(int id)
        {
           return _experienceDAL.GetByID(id);
        }

        public List<Experience> T_GetList()
        {
           return _experienceDAL.GetList();
        }

        public void T_Update(Experience t)
        {
            _experienceDAL.Update(t);
        }
    }
}
