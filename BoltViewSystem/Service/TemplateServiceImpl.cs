using BoltViewSystem.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoltViewSystem.Service
{
    public class TemplateServiceImpl : ITemplateService
    {
        private readonly TemplateDao _templateDao = new TemplateDao();

        public void UpdateTemplateByLewNum(int lewNum, ref int result1, ref int result2, ref int result3)
        {
            _templateDao.UpdateTemplateByLewNum(lewNum, ref result1, ref result2, ref result3);
        }
    }
}