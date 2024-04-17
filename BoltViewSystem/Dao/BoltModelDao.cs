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
    public class BoltModelDao
    {
        public List<BoltModel> SelectBoltModels(BoltQueryModel boltQueryModel)
        {
            string sql = String.Empty;
            if (boltQueryModel != null)
            {
                string startDt = boltQueryModel.StartDt.ToString("yyyyMMdd");
                string endDt = boltQueryModel.EndDt.ToString("yyyyMMdd");
                //sql = $"select cast('{startDt}' as datetime ) as StartDt, cast('{endDt}' as datetime ) as EndDt,  AreaNum, BoltNum,Quality,count(1) as Sum from V_Bolt_Model_Data where time >= '{startDt}'  and time <=  '{endDt}' and Quality in ('True','False')  group by AreaNum ,BoltNum, Quality order by AreaNum ,BoltNum, Quality;";
                sql = $"select cast('{startDt}' as datetime ) as StartDt, cast('{endDt}' as datetime ) as EndDt,  AreaNum, BoltNum,Quality,count(1) as Sum from V_Bolt_Model_Data where time >= '{startDt}'  and time <=  '{endDt}' and Quality in ('True')  group by AreaNum ,BoltNum, Quality order by AreaNum ,BoltNum, Quality;";
            }
            Trace.WriteLine(sql);
            return MySqlUtils.ExecuteQueryToList<BoltModel>(sql);
        }

        public long SelectBoltModelsCounts(BoltQueryModel boltQueryModel)
        {
            string sql = String.Empty;
            if (boltQueryModel != null)
            {
                string startDt = boltQueryModel.StartDt.ToString("yyyyMMdd");
                string endDt = boltQueryModel.EndDt.ToString("yyyyMMdd");
                //sql = $"select count(1) as Sum from V_Bolt_Model_Data where time >= '{startDt}'  and time <=  '{endDt}' and Quality in ('True','False') ;";
                sql = $"select count(1) as Sum from V_Bolt_Model_Data where time >= '{startDt}'  and time <=  '{endDt}' and Quality in ('True') ;";
            }

            Trace.WriteLine(sql);
            return MySqlUtils.ExecuteQueryCount(sql);
        }
    }
}