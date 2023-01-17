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
    public class SkillManager : ISkillService
    {
        ISkillDAL _skillDAL;

        public SkillManager(ISkillDAL skillDAL)
        {
            _skillDAL = skillDAL;
        }

        public void T_Add(Skill t)
        {
            _skillDAL.Insert(t);
        }

        public void T_Delete(Skill t)
        {
            _skillDAL.Delete(t);
        }

        public Skill T_GetByID(int id)
        {
            return _skillDAL.GetByID(id);
        }

        public List<Skill> T_GetList()
        {
            return _skillDAL.GetList();
        }

        public void T_Update(Skill t)
        {
            _skillDAL.Update(t);
        }
    }
}
