using BoltViewSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoltViewSystem.ViewModel
{
    public class BoltPositionDetailViewModel : ObservableObject
    {



        private BoltPositionModel boltPositionModel;

        public BoltPositionModel BoltPositionModel
        {
            get { return boltPositionModel; }
            set { boltPositionModel = value; OnPropertyChanged(); }
        }


        private string imageTemplate;
        /// <summary>
        /// 模板照片
        /// </summary>
        public string ImageTemplate
        {
            get { return imageTemplate; }
            set { imageTemplate = value;OnPropertyChanged(); }
        }

        private string imageReality;
        /// <summary>
        /// 实时查询照片
        /// </summary>
        public string ImageReality
        {
            get { return imageReality; }
            set { imageReality = value; OnPropertyChanged(); }
        }

        // 初始化的时候显示详情数据
        public BoltPositionDetailViewModel(BoltPositionModel boltPositionModel1)
        {
            if(boltPositionModel1 != null)
            {
                this.BoltPositionModel = boltPositionModel1;
                int lewNum = boltPositionModel1.LewNum;
                ImageTemplate = "D:\\20240202\\Cam4\\00 template\\Repair_Cam_" + lewNum + "_template.png";
                ImageReality = boltPositionModel1.ImageUrl.Replace("\"",""); // 这里因为数据库存储的首位带有"字符串，需要去掉
            }
           
        }
    }   
}