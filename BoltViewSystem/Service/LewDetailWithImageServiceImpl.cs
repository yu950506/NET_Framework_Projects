using BoltViewSystem.Dao;
using BoltViewSystem.Model;
using System.Collections.Generic;

namespace BoltViewSystem.Service
{
    public class LewDetailWithImageServiceImpl : ILewDetailWithImageService
    {
        private readonly AreaModelDao areaModelDao = new AreaModelDao();

        public BoltDetailWithImageModel SelectBoltDetailWithImageModelByLewModel(LewModelDetail lewModelDetail, int areaNum)
        {
            BoltDetailWithImageModel boltDetailWithImageModel = new BoltDetailWithImageModel();

            if (areaNum == 1)
            {
                // //D:\20240202\Cam1\00 template\Inspect_Cam1_90_template.png

                // 调用数据的查询区域1的信息
                Area1Model area1Model = areaModelDao.SelectArea1ModelByLewModel(lewModelDetail);

                BoltDetailModel boltDetailModel1 = new BoltDetailModel() { BoltNum = 1, Ang = area1Model.Bolt1Ang.ToString(), Quality = area1Model.Bolt1Res,Time = area1Model.Time };
                BoltDetailModel boltDetailModel2 = new BoltDetailModel() { BoltNum = 2, Ang = area1Model.Bolt2Ang.ToString(), Quality = area1Model.Bolt2Res,Time = area1Model.Time };
                BoltDetailModel boltDetailModel3 = new BoltDetailModel() { BoltNum = 3, Ang = area1Model.Bolt3Ang.ToString(), Quality = area1Model.Bolt3Res,Time = area1Model.Time };
                BoltDetailModel boltDetailModel4 = new BoltDetailModel() { BoltNum = 4, Ang = area1Model.Bolt4Ang.ToString(), Quality = area1Model.Bolt4Res, Time = area1Model.Time };

                List<BoltDetailModel> boltDetailModels = new List<BoltDetailModel>();
                boltDetailModels.Add(boltDetailModel1);
                boltDetailModels.Add(boltDetailModel2);
                boltDetailModels.Add(boltDetailModel3);
                boltDetailModels.Add(boltDetailModel4);

                boltDetailWithImageModel.ImageTemplateUrl = $"D:\\20240202\\Cam{areaNum}\\00 template\\Inspect_Cam{areaNum}_{lewModelDetail.LewNum}_template.png"; // 设置模版照片
                boltDetailWithImageModel.ImageRealityUrl = area1Model.ImagePath.Replace("\"", ""); // 这里因为数据库存储的首位带有"字符串，需要去掉; // 设置当前时间拍摄的真实照片
                boltDetailWithImageModel.BoltotDetailModelList = boltDetailModels;
            }
            else if (areaNum == 2)
            {
                // 调用数据的查询区域1的信息
                Area2Model area2Model = areaModelDao.SelectArea2ModelByLewModel(lewModelDetail);

                BoltDetailModel boltDetailModel1 = new BoltDetailModel() { BoltNum = 1, Ang = area2Model.Bolt1Ang.ToString(), Quality = area2Model.Bolt1Res,Time = area2Model.Time };
                BoltDetailModel boltDetailModel2 = new BoltDetailModel() { BoltNum = 2, Ang = area2Model.Bolt2Ang.ToString(), Quality = area2Model.Bolt2Res, Time = area2Model.Time };

                List<BoltDetailModel> boltDetailModels = new List<BoltDetailModel>();
                boltDetailModels.Add(boltDetailModel1);
                boltDetailModels.Add(boltDetailModel2);

                boltDetailWithImageModel.ImageTemplateUrl = $"D:\\20240202\\Cam{areaNum}\\00 template\\Inspect_Cam{areaNum}_{lewModelDetail.LewNum}_template.png"; // 设置模版照片
                boltDetailWithImageModel.ImageRealityUrl = area2Model.ImagePath.Replace("\"", ""); // 设置当前时间拍摄的真实照片
                boltDetailWithImageModel.BoltotDetailModelList = boltDetailModels;
            }
            else if (areaNum == 3)
            {
                // 调用数据的查询区域1的信息
                Area3Model area3Model = areaModelDao.SelectArea3ModelByLewModel(lewModelDetail);

                BoltDetailModel boltDetailModel1 = new BoltDetailModel() { BoltNum = 1, Ang = area3Model.Bolt1Ang.ToString(), Quality = area3Model.Bolt1Res,Time = area3Model.Time };
                BoltDetailModel boltDetailModel2 = new BoltDetailModel() { BoltNum = 2, Ang = area3Model.Bolt2Ang.ToString(), Quality = area3Model.Bolt2Res,Time = area3Model.Time };
                BoltDetailModel boltDetailModel3 = new BoltDetailModel() { BoltNum = 3, Ang = area3Model.Bolt3Ang.ToString(), Quality = area3Model.Bolt3Res,Time = area3Model.Time };
                BoltDetailModel boltDetailModel4 = new BoltDetailModel() { BoltNum = 4, Ang = area3Model.Bolt4Ang.ToString(), Quality = area3Model.Bolt4Res,Time = area3Model.Time };

                List<BoltDetailModel> boltDetailModels = new List<BoltDetailModel>();
                boltDetailModels.Add(boltDetailModel1);
                boltDetailModels.Add(boltDetailModel2);
                boltDetailModels.Add(boltDetailModel3);
                boltDetailModels.Add(boltDetailModel4);
                boltDetailWithImageModel.ImageTemplateUrl = $"D:\\20240202\\Cam{areaNum}\\00 template\\Inspect_Cam{areaNum}_{lewModelDetail.LewNum}_template.png"; // 设置模版照片
                boltDetailWithImageModel.ImageRealityUrl = area3Model.ImagePath.Replace("\"", ""); // 设置当前时间拍摄的真实照片
                boltDetailWithImageModel.BoltotDetailModelList = boltDetailModels;
            }

            return boltDetailWithImageModel;
        }
    }

    //    -- 区域1 的模板照片
    //D:\20240202\Cam1\00 template\Inspect_Cam1_90_template.png
    //D:\20240202\Cam1\00 template\Inspect_Cam1_91_template.png
    //D:\20240202\Cam1\00 template\Inspect_Cam1_92_template.png
    //D:\20240202\Cam1\00 template\Inspect_Cam1_93_template.png
    //D:\20240202\Cam1\00 template\Inspect_Cam1_94_template.png
    //D:\20240202\Cam1\00 template\Inspect_Cam1_95_template.png
    //D:\20240202\Cam1\00 template\Inspect_Cam1_96_template.png
    //D:\20240202\Cam1\00 template\Inspect_Cam1_97_template.png
    //D:\20240202\Cam1\00 template\Inspect_Cam1_98_template.png
    //D:\20240202\Cam1\00 template\Inspect_Cam1_99_template.png

    //-- 区域2 的模板照片

    //D:\20240202\Cam2\00 template\Inspect_Cam2_90_template.png
    //D:\20240202\Cam2\00 template\Inspect_Cam2_91_template.png
    //D:\20240202\Cam2\00 template\Inspect_Cam2_92_template.png
    //D:\20240202\Cam2\00 template\Inspect_Cam2_93_template.png
    //D:\20240202\Cam2\00 template\Inspect_Cam2_94_template.png
    //D:\20240202\Cam2\00 template\Inspect_Cam2_95_template.png
    //D:\20240202\Cam2\00 template\Inspect_Cam2_96_template.png
    //D:\20240202\Cam2\00 template\Inspect_Cam2_97_template.png
    //D:\20240202\Cam2\00 template\Inspect_Cam2_98_template.png
    //D:\20240202\Cam2\00 template\Inspect_Cam2_99_template.png
    //D:\20240202\Cam2\00 template\Inspect_Cam2_9_template.png

    //D:\20240202\Cam3\00 template\
}