using BoltViewSystem.Model;
using BoltViewSystem.Utils;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace BoltViewSystem.Dao
{
    public class BoltPositionModelDao
    {
        /// <summary>
        /// 根据检测区的模型查询数据
        /// </summary>
        /// <param name="bolt"></param>
        /// <returns></returns>
        public List<BoltPositionModel> SelectBoltPositionModelByBoltPositionModel(BoltPositionModel bolt)
        {
            /*
            SELECT Id as Id, LEW_NO as LewNum, `path` as ImageUrl, `zone` as AreaNum, bolt_num as BoltNum, rmid as RMid, cmid as CMid, hv_Rmid as HvRmid, hv_Cmid as HvCmid, `Datetime` as Time
            FROM bolt_position where `Datetime` >= '20240404' and `Datetime` <= '20240415'
            and LEW_NO = 195
            and zone = 1
            and bolt_num = 4
            order by Datetime desc , LEW_NO, zone, bolt_num;
            ;
            */
            List<BoltPositionModel> boltPositionModels = new List<BoltPositionModel>();
            Trace.WriteLine($" {DateTime.Now}, BoltPositionModel => {bolt} ");
            string sql = String.Empty;
            if (bolt != null)
            {
                string startDt = bolt.StartDt.ToString("yyyyMMdd");
                string endDt = bolt.EndDt.ToString("yyyyMMdd");

                sql = "SELECT Id as Id, LEW_NO as LewNum, `path` as ImageUrl, `zone` as AreaNum, bolt_num as BoltNum, rmid as RMid, cmid as CMid, hv_Rmid as HvRMid, hv_Cmid as HvCMid, `Datetime` as Time " +
                   $"FROM bolt_position where `Datetime` >= '{startDt}' and `Datetime` <= '{endDt}'";
                if (bolt.LewNum > 0)
                {
                    sql += $" and LEW_NO = {bolt.LewNum} ";
                }

                if (bolt.AreaNum > 0)
                {
                    sql += $" and zone = {bolt.AreaNum} ";
                }
                if (bolt.BoltNum > 0)
                {
                    sql += $" and bolt_num = {bolt.BoltNum}";
                }
            }
            sql += "order by Datetime desc , LEW_NO, zone, bolt_num";

            Trace.WriteLine($" {DateTime.Now}, sql => {sql} ");
            boltPositionModels = MySqlUtils.ExecuteQueryToList<BoltPositionModel>(sql);

            return boltPositionModels;
        }
    }
}