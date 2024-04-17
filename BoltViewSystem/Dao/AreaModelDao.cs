using BoltViewSystem.Model;
using BoltViewSystem.Utils;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoltViewSystem.Dao
{
    public class AreaModelDao
    {
        public Area1Model SelectArea1ModelByLewModel(LewModelDetail lewModelDetail)
        {
            List<Area1Model> area1Models = new List<Area1Model>();

            // 根据吊具号查询区域1的螺栓详细信息
            Trace.WriteLine($"AreaModelDao 的SelectArea1ModelByLewModel 的参数 lewModelDetail ====> {lewModelDetail}");
            DateTime startDt = lewModelDetail.Time; // Time = 2024/4/8 17:00:00
            DateTime endDt = lewModelDetail.Time.AddHours(1);// // Time = 2024/4/8 18:00:00
            string sql = String.Empty;
            sql = "SELECT Id as Id, lew_num as LewNum, `path` as ImagePath, Bolt1_ang as Bolt1Ang, Bolt1_res as Bolt1Res, Bolt2_ang as Bolt2Ang, Bolt2_res as Bolt2Res, Bolt3_ang as Bolt3Ang, Bolt3_res as Bolt3Res, Bolt4_ang as Bolt4Ang, Bolt4_res as Bolt4Res, `time` as Time from bolt_1 " +
             //$"where time >= {startDt} " +
             //$"and time < {endDt} and lew_num = '{lewModelDetail.LewNum}'";
             "where time >= @StartDt and time < @EndDt " +
             $" and lew_num = '{lewModelDetail.LewNum}'";
            Trace.WriteLine(sql);
            area1Models = MySqlUtils.ExecuteQueryToList<Area1Model>(sql, new MySqlParameter[] { new MySqlParameter("@StartDt", startDt), new MySqlParameter("@EndDt", endDt) });

            if (area1Models.Count > 0)
            {
                return area1Models[0];
            }
            else
            {
                return null;
            }
        }

        public Area2Model SelectArea2ModelByLewModel(LewModelDetail lewModelDetail)
        {
            List<Area2Model> area2Models = new List<Area2Model>();

            // 根据吊具号查询区域1的螺栓详细信息
            Trace.WriteLine($"AreaModelDao 的SelectArea1ModelByLewModel 的参数 lewModelDetail ====> {lewModelDetail}");
            DateTime startDt = lewModelDetail.Time; // Time = 2024/4/8 17:00:00
            DateTime endDt = lewModelDetail.Time.AddHours(1);// // Time = 2024/4/8 18:00:00
            string sql = String.Empty;
            sql = "SELECT Id as Id, lew_num as LewNum, `path` as ImagePath, Bolt1_ang as Bolt1Ang, Bolt1_res as Bolt1Res, Bolt2_ang as Bolt2Ang, Bolt2_res as Bolt2Res, `time` as Time from bolt_2 " +
             "where time >= @StartDt and time < @EndDt " +
             $" and lew_num = '{lewModelDetail.LewNum}'";
            Trace.WriteLine(sql);
            area2Models = MySqlUtils.ExecuteQueryToList<Area2Model>(sql, new MySqlParameter[] { new MySqlParameter("@StartDt", startDt), new MySqlParameter("@EndDt", endDt) });
            if (area2Models.Count > 0)
            {
                return area2Models[0];
            }
            else
            {
                return null;
            }
        }

        public Area3Model SelectArea3ModelByLewModel(LewModelDetail lewModelDetail)
        {
            List<Area3Model> area3Models = new List<Area3Model>();

            // 根据吊具号查询区域1的螺栓详细信息
            Trace.WriteLine($"AreaModelDao 的SelectArea1ModelByLewModel 的参数 lewModelDetail ====> {lewModelDetail}");
            DateTime startDt = lewModelDetail.Time; // Time = 2024/4/8 17:00:00
            DateTime endDt = lewModelDetail.Time.AddHours(1);// // Time = 2024/4/8 18:00:00
            string sql = String.Empty;
            sql = "SELECT Id as Id, lew_num as LewNum, `path` as ImagePath, Bolt1_ang as Bolt1Ang, Bolt1_res as Bolt1Res, Bolt2_ang as Bolt2Ang, Bolt2_res as Bolt2Res, Bolt3_ang as Bolt3Ang, Bolt3_res as Bolt3Res, Bolt4_ang as Bolt4Ang, Bolt4_res as Bolt4Res, `time` as Time from bolt_3 " +
             "where time >= @StartDt and time < @EndDt " +
             $" and lew_num = '{lewModelDetail.LewNum}'";
            Trace.WriteLine(sql);
            area3Models = MySqlUtils.ExecuteQueryToList<Area3Model>(sql, new MySqlParameter[] { new MySqlParameter("@StartDt", startDt), new MySqlParameter("@EndDt", endDt) });
            if (area3Models.Count > 0)
            {
                return area3Models[0];
            }
            else
            {
                return null;
            }
        }
    }
}