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
    public class ServiceManager : IServiceService
    {
        IServiceDAL _serviceDAL;

        public ServiceManager(IServiceDAL serviceDAL)
        {
            _serviceDAL = serviceDAL;
        }

        public void T_Add(Service t)
        {
            _serviceDAL.Insert(t);
        }

        public void T_Delete(Service t)
        {
            _serviceDAL.Delete(t);
        }

        public Service T_GetByID(int id)
        {
            return _serviceDAL.GetByID(id);
        }

        public List<Service> T_GetList()
        {
            return _serviceDAL.GetList();
         
        }

        public void T_Update(Service t)
        {
            _serviceDAL.Update(t);
        }
    }
}
