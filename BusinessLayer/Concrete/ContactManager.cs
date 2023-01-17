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
    public class ContactManager : IContactService
    {
        IContactDAL _contactDal;

        public ContactManager(IContactDAL contactDal)
        {
            _contactDal = contactDal;
        }

        public void T_Add(Contact t)
        {
            _contactDal.Insert(t);
        }

        public void T_Delete(Contact t)
        {
            _contactDal.Delete(t);
        }

        public Contact T_GetByID(int id)
        {
            return _contactDal.GetByID(id);
        }

        public List<Contact> T_GetList()
        {
            return _contactDal.GetList();
        }

        public void T_Update(Contact t)
        {
            _contactDal.Update(t);
        }
    }
}
