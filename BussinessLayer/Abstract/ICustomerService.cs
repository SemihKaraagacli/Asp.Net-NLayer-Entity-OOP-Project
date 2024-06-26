﻿using EntityLayer.Concrete;
using System.Collections.Generic;

namespace BussinessLayer.Abstract
{
    public interface ICustomerService:IGenericService<Customer>
    {
        List<Customer> GetCustomerWithJobList();
    }
}
