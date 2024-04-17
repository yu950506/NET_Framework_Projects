using System;

namespace BoltViewSystem.Model
{
    /// <summary>
    /// 检测区模型
    /// </summary>
    public class BoltPositionModel
    {
        public int Id { get; set; }
        public int LewNum { get; set; }
        public string ImageUrl { get; set; }
        public int AreaNum { get; set; }
        public int BoltNum { get; set; }
        public double RMid { get; set; }
        public double CMid { get; set; }
        public double HvRMid { get; set; }
        public double HvCMid { get; set; }
        public DateTime Time { get; set; }
        public DateTime StartDt { get; set; }
        public DateTime EndDt { get; set; }

        public override string ToString()
        {
            return $" Id = {Id} ,LewNum = {LewNum},ImageUrl = {ImageUrl},AreaNum = {AreaNum},BoltNum = {BoltNum},RMid = {RMid},CMid = {CMid},HvRMid = {HvRMid},HvCMid = {HvCMid},Time = {Time},StartDt = {StartDt},EndDt = {EndDt}";
        }
    }
}