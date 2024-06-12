using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessLayer.EntityFramework
{
    public class EfCustomerDal : GenericDal<Customer>, ICustomerDal
    {
        public List<Customer> GetCustomerWithJob()
        {
            using (var c=new Context())
            {
                return c.Customers.Include(x=>x.Job).ToList();
            }
        }
    }
}
