using BoltViewSystem.Model;
using BoltViewSystem.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoltViewSystem.ViewModel
{
    public class BoltDetailViewModel : ObservableObject
    {
        private ObservableCollection<ModelData> modelDataObservableCollection = new ObservableCollection<ModelData>();

        public ObservableCollection<ModelData> ModelDataObservableCollection
        {
            get { return modelDataObservableCollection; }
            set { modelDataObservableCollection = value; OnPropertyChanged(); }
        }


        private IModelDataService iModelDataService = new ModelDataService();

        public BoltDetailViewModel()
        { }

        public BoltDetailViewModel(BoltModel boltModel)
        {
            Trace.WriteLine($"BoltDetailViewModel 构造函数中：BoltModel = {boltModel}");
            // 为前端表格数据赋值
            List<ModelData> modelDatas = iModelDataService.SelectAllModelDataByBoltModel(boltModel);
            ModelDataObservableCollection = new ObservableCollection<ModelData>(modelDatas);
            
        }
    }
}