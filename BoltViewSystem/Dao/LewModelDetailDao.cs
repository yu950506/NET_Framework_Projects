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
    public class LewModelDetailDao
    {
        /// <summary>
        /// 根据吊具号，开始时间，结束时间查询吊具在当前时间段内的具体明细
        /// </summary>
        /// <param name="lewModel"></param>
        /// <returns></returns>
        public List<LewModelDetail> SelectAllByLewModel(LewModel lewModel)
        {
            List<LewModelDetail> list = new List<LewModelDetail>();

            if (lewModel != null)
            {
                // 根据吊具号，开始时间，结束时间查询吊具在当前时间段内的具体明细
                string sql = String.Empty;
                string startDt = lewModel.StartDt.ToString("yyyyMMdd");
                string endDt = lewModel.EndDt.ToString("yyyyMMdd");

                //sql = "select LewNum ,Time from v_bolt_model_data " +
                //    $" where Quality = 'True' and time >= '{startDt}' and time <= '{endDt}' and LewNum = {lewModel.LewNum} " +
                //    "group by LewNum ,Time order by Time desc";


                sql = "select t.LewNum as LewNum,STR_TO_DATE(t.time, '%Y-%m-%d %H:00:00') AS Time from ( select LewNum, DATE_FORMAT(time, '%Y-%m-%d %H:00:00') as Time " +
                    $"from v_bolt_model_data as t where time >= '{startDt}' and time < '{endDt}' " +
                   $"and LewNum = '{lewModel.LewNum}' and t.Quality = 'True' group by LewNum, DATE_FORMAT(time,  '%Y-%m-%d %H:00:00') ) as t";

                Trace.WriteLine(sql);

                list = MySqlUtils.ExecuteQueryToList<LewModelDetail>(sql);
            }

            return list;
        }
    }
}