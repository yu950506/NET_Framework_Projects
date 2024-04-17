using BoltViewSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoltViewSystem.Service
{
    public interface ILewDetailWithImageService
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lewModelDetail">螺栓模型</param>
        /// <param name="areaNum">区域号 1,2,3</param>
        /// <returns></returns>
        BoltDetailWithImageModel SelectBoltDetailWithImageModelByLewModel(LewModelDetail lewModelDetail, int areaNum);
    }
}
