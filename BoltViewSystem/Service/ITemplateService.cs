using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoltViewSystem.Service
{
    public interface ITemplateService
    {
        void UpdateTemplateByLewNum(int lewNum, ref int result1, ref int result2, ref int result3);
    }
}
