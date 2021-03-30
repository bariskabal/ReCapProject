﻿using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Abstract
{
    public interface ICustomerDal : IGenericDal<Customer>
    {
        List<CustomerDetailDto> GetCustomerDetails();
        List<CustomerDetailDto> GetCustomerDetails(Expression<Func<Customer, bool>> filter = null);
        UserCustomerDto GetCustomerIdOfUser(string email);
    }
}
