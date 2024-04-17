using BoltViewSystem.Dao;
using BoltViewSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoltViewSystem.Service
{
    public class ModelDataService : IModelDataService
    {

        private ModelDataDao ModelDataDao = new ModelDataDao();
        public List<ModelData> SelectAllModelData()
        {
            return ModelDataDao.SelectAllModelData();
        }

        public List<ModelData> SelectAllModelData(int index, int pageCount)
        {
            return ModelDataDao.SelectAllModelData(index,pageCount);
        }

      

        public int SelectCountModelData()
        {
            return ModelDataDao.SelectCountModelData();
        }


        /// <summary>
        ///  根据前端传递过来的参数查询模型数据
        /// </summary>
        /// <param name="boltModel"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public List<ModelData> SelectAllModelDataByBoltModel(BoltModel boltModel)
        {
            return ModelDataDao.SelectAllModelDataByBoltModel(boltModel);
        }

    }
}
