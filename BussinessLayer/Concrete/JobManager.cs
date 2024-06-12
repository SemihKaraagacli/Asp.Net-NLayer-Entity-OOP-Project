using BussinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System.Collections.Generic;

namespace BussinessLayer.Concrete
{
    public class JobManager : IJobService
    {
        IJobDal _jobDal;

        public JobManager(IJobDal jobDal)
        {
            _jobDal = jobDal;
        }

        public List<Job> GetAll()
        {
            return _jobDal.GetAll();
        }

        public Job GetById(int id)
        {
            var value= _jobDal.GetById(id);
            return value;
        }

        public void TDelete(Job entity)
        {
            _jobDal.Delete(entity);
        }

        public void TInsert(Job entity)
        {
            _jobDal.Insert(entity);
        }

        public void TUpdate(Job entity)
        {
            _jobDal.Update(entity);
        }
    }
}
