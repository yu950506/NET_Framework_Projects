using PaintDefectDetectionSystem.Model;
using System;
using System.Collections.Generic;

namespace PaintDefectDetectionSystem.Service
{
    internal interface ICarSerivice
    {
        /// <summary>
        /// 根据车身号查询车照片的URI地址
        /// </summary>
        /// <param name="bodyNo">车身号</param>
        /// <returns></returns>
        String SelectCarImgURIByBodyNo(String bodyNo);

        /// <summary>
        /// 根据车身号查询车的详细信息列表信息
        /// </summary>
        /// <param name="bodyNo"></param>
        /// <returns></returns>
        List<Car> SelectCarListByBodyNo(String bodyNo);

        /// <summary>
        /// 根据相机号，车身号查询缺陷矩形集合数据
        /// </summary>
        /// <param name="carameId">相机号</param>
        /// <param name="bodyNo">车身号</param>
        /// <returns></returns>
        List<RectangleModel> SelectRectangleByCarameIdAndBodyNo(string carameId, string bodyNo);
    }
}