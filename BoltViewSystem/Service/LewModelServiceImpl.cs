using BoltViewSystem.Dao;
using BoltViewSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoltViewSystem.Service
{
    public class LewModelServiceImpl : ILewModelService
    {

        private LewModelDao lewModelDao = new LewModelDao();

        public List<LewModel> SelectAllByLewModel(LewModel lewmodel)
        {
            return lewModelDao.SelectAllLewModelsByLewModel(lewmodel);
        }
    }
}
