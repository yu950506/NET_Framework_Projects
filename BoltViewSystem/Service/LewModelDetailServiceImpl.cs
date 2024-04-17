using BoltViewSystem.Dao;
using BoltViewSystem.Model;
using System.Collections.Generic;

namespace BoltViewSystem.Service
{
    public class LewModelDetailServiceImpl : ILewModelDetailService
    {
        private readonly LewModelDetailDao LewModelDetailDao = new LewModelDetailDao();

        public List<LewModelDetail> GetDetailList(LewModel lewModel)
        {
            return LewModelDetailDao.SelectAllByLewModel(lewModel);
        }
    }
}