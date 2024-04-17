using BoltViewSystem.Dao;
using BoltViewSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoltViewSystem.Service
{
    public class BoltPositionModelServiceImpl : IBoltPositionModelService
    {
        private readonly BoltPositionModelDao _boltPositionModelDao = new BoltPositionModelDao();    
        public List<BoltPositionModel> GetPositions(BoltPositionModel boltPositionModel)
        {
            return _boltPositionModelDao.SelectBoltPositionModelByBoltPositionModel(boltPositionModel);
        }
    }
}
