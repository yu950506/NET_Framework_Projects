using BoltViewSystem.Dao;
using BoltViewSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoltViewSystem.Service
{
    internal class BoltModelServiceImpl : IBoltModelService
    {
        private BoltModelDao BoltModelDao = new BoltModelDao();

        public List<BoltModel> SelectBoltModels(BoltQueryModel boltQueryModel)
        {
            return BoltModelDao.SelectBoltModels(boltQueryModel);
        }

        public long SelectBoltModelsCount(BoltQueryModel boltQueryModel)
        {
           return BoltModelDao.SelectBoltModelsCounts(boltQueryModel);
        }
    }
}