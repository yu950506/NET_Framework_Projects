using BoltViewSystem.Model;
using BoltViewSystem.Utils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BoltViewSystem.Dao
{
    public class ModelDataDao
    {
        /// <summary>
        /// 查询所有螺栓模型数据
        /// </summary>
        /// <returns></returns>
        public List<ModelData> SelectAllModelData()
        {
            string sql = "select * from v_bolt_model_data order by time desc limit 10000";
            //"select * from v_bolt_model_data order by LewNum ,AreaNum ,BoltNum , time desc limit 0,10"; // 0，索引号，10，记录号
            List<ModelData> modelDatas = MySqlUtils.ExecuteQueryToList<ModelData>(sql);
            return modelDatas;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="index">索引号</param>
        /// <param name="pageCount">记录号</param>
        /// <returns></returns>
        public List<ModelData> SelectAllModelData(int index, int pageCount)
        {
            string sql = $"select * from v_bolt_model_data order by LewNum ,AreaNum ,BoltNum , time desc limit {index},{pageCount}";
            //"select * from v_bolt_model_data order by LewNum ,AreaNum ,BoltNum , time desc limit 0,10"; // 0，索引号，10，记录号
            List<ModelData> modelDatas = MySqlUtils.ExecuteQueryToList<ModelData>(sql);
            return modelDatas;
        }

        /// <summary>
        /// 查询总记录数
        /// </summary>
        /// <returns></returns>
        public int SelectCountModelData()
        {
            string sql = $"select count(1) from v_bolt_model_data ";
            return MySqlUtils.ExecuteQueryCount(sql);
        }

        public List<ModelData> SelectAllModelDataByBoltModel(BoltModel boltModel)
        {
            List<ModelData> modelDatas = new List<ModelData>();
            if (boltModel != null)
            {

                string startDt = boltModel.StartDt.ToString("yyyyMMdd");
                string endDt = boltModel.EndDt.ToString("yyyyMMdd");
                string sql = $"select * from v_bolt_model_data where AreaNum = {boltModel.AreaNum} and BoltNum = {boltModel.BoltNum} and Quality = '{boltModel.Quality}'  and time>= {startDt} and time <= {endDt}  order by LewNum ,AreaNum ,BoltNum , time desc ";
               Trace.WriteLine(sql);
                modelDatas = MySqlUtils.ExecuteQueryToList<ModelData>(sql);
            }
            return modelDatas;

        }
    }
}