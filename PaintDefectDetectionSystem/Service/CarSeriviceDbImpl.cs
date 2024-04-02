using PaintDefectDetectionSystem.Model;
using System;
using System.Collections.Generic;

namespace PaintDefectDetectionSystem.Service
{
    /// <summary>
    /// 数据库的方式进行实现
    /// </summary>
    public class CarSeriviceDbImpl : ICarSerivice
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="bodyNo">车身号</param>
        /// <returns>如果车身号等于1101，返回地址，其他情况返回空</returns>
        public string SelectCarImgURIByBodyNo(string bodyNo)
        {
            string imgUri = null;
            if (String.IsNullOrEmpty(bodyNo))
            {
                imgUri = string.Empty;
            }
            else if ("1101".Equals(bodyNo))
            {
                imgUri = "pack://application:,,,/PaintDefectDetectionSystem;component/Images/body_no/1101.jpg";
            }
            else
            {
                imgUri = string.Empty;
            }
            return imgUri;
        }

        public List<Car> SelectCarListByBodyNo(string bodyNo)
        {
            throw new NotImplementedException();
        }

        public List<RectangleModel> SelectRectangleByCarameIdAndBodyNo(string carameId, string bodyNo)
        {
            throw new NotImplementedException();
        }
    }
}