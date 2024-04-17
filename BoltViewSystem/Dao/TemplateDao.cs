using BoltViewSystem.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoltViewSystem.Dao
{
    public class TemplateDao
    {
        public void UpdateTemplateByLewNum(int lewNum, ref int result1, ref int result2, ref int result3)
        {
            // 需要更新3个区域
            result1 = UpdateMbAngle1(lewNum);
            result2 = UpdateMbAngle2(lewNum);
            result3 = UpdateMbAngle3(lewNum);
        }

        public int UpdateMbAngle1(int lewNum)
        {
            string sql = $"update mb_ang1 set model_status = 2 where lew_num = {lewNum}";
            return MySqlUtils.ExecuteNonQuery(sql);
        }

        public int UpdateMbAngle2(int lewNum)
        {
            string sql = $"update mb_ang1 set model_status = 2 where lew_num = {lewNum}";
            return MySqlUtils.ExecuteNonQuery(sql);
        }

        public int UpdateMbAngle3(int lewNum)
        {
            string sql = $"update mb_ang1 set model_status = 2 where lew_num = {lewNum}";
            return MySqlUtils.ExecuteNonQuery(sql);
        }
    }
}