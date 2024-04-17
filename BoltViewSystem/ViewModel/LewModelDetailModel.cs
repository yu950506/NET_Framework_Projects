using BoltViewSystem.Model;
using BoltViewSystem.Service;
using BoltViewSystem.View;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows.Documents;

namespace BoltViewSystem.ViewModel
{
    public class LewModelDetailModel : ObservableCollection<LewModelDetail>
    {
        private ObservableCollection<LewModelDetail> lewModelDetailObservableCollection;

        // 前端表格数据集合
        public ObservableCollection<LewModelDetail> LewModelDetailObservableCollection
        {
            get { return lewModelDetailObservableCollection; }
            set { lewModelDetailObservableCollection = value; }
        }

        public DelegateCommand SelectDetailDelegateCommand { get; set; }

        private readonly ILewModelDetailService lewModelDetailService = new LewModelDetailServiceImpl();

        // 在构造函数中为其初始化表格数据
        public LewModelDetailModel(LewModel lewModel)
        {
            SelectDetailDelegateCommand = new DelegateCommand(SelectDetailDelegateCommandImpl);

            List<LewModelDetail> lewModelDetails = lewModelDetailService.GetDetailList(lewModel);
            if (lewModelDetails.Count > 0)
            {
                LewModelDetailObservableCollection = new ObservableCollection<LewModelDetail>(lewModelDetails);
            }
        }

        // 表格双击查看明细的功能
        public void SelectDetailDelegateCommandImpl(object parameter)
        {
            if (parameter != null)
            {
                LewModelDetail lewModelDetail = parameter as LewModelDetail;
                Trace.WriteLine(lewModelDetail.ToString());
                LewDetailWithImageView lewDetailWithImageView = new LewDetailWithImageView(lewModelDetail);
                lewDetailWithImageView.ShowDialog();
            }
        }
    }
}