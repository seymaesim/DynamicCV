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
    public class PortfolioManager : IPortfolioService
    {
        IPortfolioDAL _portfolioDAL;

        public PortfolioManager(IPortfolioDAL portfolioDAL)
        {
            _portfolioDAL = portfolioDAL;
        }

        public void T_Add(Portfolio t)
        {
            _portfolioDAL.Insert(t);
        }

        public void T_Delete(Portfolio t)
        {
            _portfolioDAL.Delete(t);
        }

        public Portfolio T_GetByID(int id)
        {
           return  _portfolioDAL.GetByID(id);
        }

        public List<Portfolio> T_GetList()
        {
            return _portfolioDAL.GetList();
        }

        public void T_Update(Portfolio t)
        {
            _portfolioDAL.Update(t);
        }
    }
}
