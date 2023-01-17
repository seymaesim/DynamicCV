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
    public class FeatureManager : IFeatureService
    {
        IFeatureDAL _featureDal;

        public FeatureManager(IFeatureDAL featureDal)
        {
            _featureDal = featureDal;
        }

        public void T_Add(Feature t)
        {
            _featureDal.Insert(t);
        }

        public void T_Delete(Feature t)
        {
            _featureDal.Delete(t);
        }

        public Feature T_GetByID(int id)
        {
            return _featureDal.GetByID(id);
        }

        public List<Feature> T_GetList()
        {
            return _featureDal.GetList();
        }

        public void T_Update(Feature t)
        {
            _featureDal.Update(t);
        }
    }
}
