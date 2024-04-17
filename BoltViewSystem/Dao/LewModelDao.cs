using BoltViewSystem.Model;
using BoltViewSystem.Utils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoltViewSystem.Dao
{
    public class LewModelDao
    {
        public List<LewModel> SelectAllLewModelsByLewModel(LewModel lewModel)
        {
            List<LewModel> lewModels = new List<LewModel>();

            String sql = String.Empty;
            if (lewModel != null)
            {
                string startDt = lewModel.StartDt.ToString("yyyyMMdd");
                string endDt = lewModel.EndDt.ToString("yyyyMMdd");

                //sql = $"select LewNum ,count(1) as Sum ,cast('{startDt}' as datetime ) as StartDt, cast('{endDt}' as datetime ) as EndDt  from (" +
                //    "select LewNum ,Time from v_bolt_model_data " +
                //    $"where Quality = 'True' and time >= '{startDt}' and time <= '{endDt}'" +
                //    "group by LewNum ,Time " +
                //    ") as t1 group by LewNum order by LewNum";



                sql = $"select LewNum ,count(1) as Sum,cast('{startDt}' as datetime ) as StartDt, cast('{endDt}' as datetime ) as EndDt   from ( " +
                    "select LewNum, DATE_FORMAT(time, '%Y-%m-%d %H:00:00'),sum(case when t.Quality = 'True' then 1 else 0 end) as NoQualitySum " +
                    $"from v_bolt_model_data as t where time >= '{startDt}' and time < '{endDt}' " +
                  //  "-- and LewNum = '64' " +
                    "group by LewNum, DATE_FORMAT(time,  '%Y-%m-%d %H:00:00') " +
                    ") as t where t.NoQualitySum >=1 group by lewNum order by lewNum ";




                if (lewModel.LewNum > 0)
                { // 加入螺栓号的查询条件
                    //sql = $"select LewNum ,count(1) as Sum ,cast('{startDt}' as datetime ) as StartDt, cast('{endDt}' as datetime ) as EndDt  from (" +
                    //                   "select LewNum ,Time from v_bolt_model_data " +
                    //                   $"where Quality = 'True' and time >= '{startDt}' and time <= '{endDt}' and LewNum = {lewModel.LewNum} " +
                    //                   "group by LewNum ,Time " +
                    //                   ") as t1 group by LewNum order by LewNum";

                    sql = $"select LewNum ,count(1) as Sum,cast('{startDt}' as datetime ) as StartDt, cast('{endDt}' as datetime ) as EndDt   from ( " +
                    "select LewNum, DATE_FORMAT(time, '%Y-%m-%d %H:00:00'),sum(case when t.Quality = 'True' then 1 else 0 end) as NoQualitySum " +
                    $"from v_bolt_model_data as t where time >= '{startDt}' and time < '{endDt}' " +
                    $" and LewNum ={lewModel.LewNum} " +
                    "group by LewNum, DATE_FORMAT(time,  '%Y-%m-%d %H:00:00') " +
                    ") as t where t.NoQualitySum >=1 group by lewNum ";

                }
            }
            Trace.WriteLine(sql);
            lewModels = MySqlUtils.ExecuteQueryToList<LewModel>(sql);

            return lewModels;
        }
    }
}