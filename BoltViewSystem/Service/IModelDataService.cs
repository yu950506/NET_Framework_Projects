using BoltViewSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoltViewSystem.Service
{
    public interface IModelDataService
    {
        List<ModelData> SelectAllModelData();

        List<ModelData> SelectAllModelData(int index, int pageCount);

        List<ModelData> SelectAllModelDataByBoltModel(BoltModel boltModel);

        int SelectCountModelData();
    }
}