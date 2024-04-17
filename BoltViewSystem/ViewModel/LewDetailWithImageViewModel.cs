using BoltViewSystem.Model;
using BoltViewSystem.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoltViewSystem.ViewModel
{
    public class LewDetailWithImageViewModel : ObservableObject
    {
        private BoltDetailWithImageModel boltDetailWithImageModelArea1;

        /// <summary>
        /// 区域1的模型
        /// </summary>
        public BoltDetailWithImageModel BoltDetailWithImageModelArea1
        {
            get { return boltDetailWithImageModelArea1; }
            set { boltDetailWithImageModelArea1 = value; OnPropertyChanged(); }
        }

        private BoltDetailWithImageModel boltDetailWithImageModelArea2;

        /// <summary>
        /// 区域2的模型
        /// </summary>
        public BoltDetailWithImageModel BoltDetailWithImageModelArea2
        {
            get { return boltDetailWithImageModelArea2; }
            set { boltDetailWithImageModelArea2 = value; OnPropertyChanged(); }
        }

        private BoltDetailWithImageModel boltDetailWithImageModelArea3;

        /// <summary>
        /// 区域3的模型
        /// </summary>
        public BoltDetailWithImageModel BoltDetailWithImageModelArea3
        {
            get { return boltDetailWithImageModelArea3; }
            set { boltDetailWithImageModelArea3 = value; OnPropertyChanged(); }
        }

        private readonly ILewDetailWithImageService lewDetailWithImageService = new LewDetailWithImageServiceImpl();

        /// <summary>
        ///
        /// </summary>
        /// <param name="lewModelDetail"> 从上一个页面传入过来的</param>
        public LewDetailWithImageViewModel(LewModelDetail lewModelDetail)
        {
            if (lewModelDetail != null)
            {
                // 根据传入的吊具号及时间，查询详细的区域及螺栓信息
                BoltDetailWithImageModelArea1 = lewDetailWithImageService.SelectBoltDetailWithImageModelByLewModel(lewModelDetail, 1);
                BoltDetailWithImageModelArea2 = lewDetailWithImageService.SelectBoltDetailWithImageModelByLewModel(lewModelDetail, 2);
                BoltDetailWithImageModelArea3 = lewDetailWithImageService.SelectBoltDetailWithImageModelByLewModel(lewModelDetail, 3);

                //   MockData();
            }
        }

        //public void MockData()
        //{
        //    // 模拟区域1的数据
        //    //
        //    BoltDetailWithImageModel boltDetailWithImageModel = new BoltDetailWithImageModel();
        //    boltDetailWithImageModel.ImageTemplateUrl = "";
        //    boltDetailWithImageModel.ImageRealityUrl = "";

        //    List<BoltDetailModel> boltDetailModels = new List<BoltDetailModel>();
        //    boltDetailModels.Add(new BoltDetailModel() { Ang = "0.999", BoltNum = 1, Quality = "True" });
        //    boltDetailModels.Add(new BoltDetailModel() { Ang = "-0.888", BoltNum = 2, Quality = "True" });
        //    boltDetailModels.Add(new BoltDetailModel() { Ang = "0.777", BoltNum = 3, Quality = "True" });
        //    boltDetailModels.Add(new BoltDetailModel() { Ang = "-0.666", BoltNum = 4, Quality = "True" });
        //    boltDetailWithImageModel.BoltotDetailModelList = boltDetailModels;
        //    BoltDetailWithImageModelArea1 = boltDetailWithImageModel;
        //}
    }
}