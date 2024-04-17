using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoltViewSystem.Model
{
	/// <summary>
	/// 区域明细模型
	/// </summary>
    public class BoltDetailWithImageModel : ObservableObject
    {
		private string iamgeTemplateUrl;
		/// <summary>
		/// 区域模板照片路径
		/// </summary>
		public string ImageTemplateUrl
		{
			get { return iamgeTemplateUrl; }
			set { iamgeTemplateUrl = value;OnPropertyChanged(); }
		}

		private string imageRealityUrl;
		/// <summary>
		/// 拍的真实照片路劲
		/// </summary>
		public string ImageRealityUrl
		{
			get { return imageRealityUrl; }
			set { imageRealityUrl = value;OnPropertyChanged(); }
		}

		private List<BoltDetailModel> boltotDetailModelList;

		public List<BoltDetailModel> BoltotDetailModelList
        {
			get { return boltotDetailModelList; }
			set { boltotDetailModelList = value;OnPropertyChanged(); }
		}


	}
}
