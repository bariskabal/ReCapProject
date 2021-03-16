using Business.Abstract;
using Business.Constants;
using Core.Utilities;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        private readonly ICustomerDal _customerDal;
        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }
        public IResult Add(Customer customer)
        {
            _customerDal.Add(customer);
            return new SuccessResult(Message.CustomerAdded);
        }

        public IResult Delete(Customer customer)
        {
            _customerDal.Delete(customer);
            return new SuccessResult(Message.CustomerDeleted);
        }

        public IDataResult<List<Customer>> GetAll()
        {
            var data = _customerDal.GetAll();
            return new SuccessDataResult<List<Customer>>(data, Message.CustomerListed);
        }

        public IDataResult<Customer> GetById(int id)
        {
            var data = _customerDal.Get(c => c.Id == id);
            return new SuccessDataResult<Customer>(data, Message.CustomerListed);
        }

        public IDataResult<List<CustomerDetailDto>> GetCustomerDetails()
        {
            var data = _customerDal.GetCustomerDetails();
            return new SuccessDataResult<List<CustomerDetailDto>>(data, Message.CustomerListed);
        }

        public IResult Update(Customer customer)
        {
            return new SuccessResult(Message.CustomerUpdated);
        }
    }
}
