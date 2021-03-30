using Core.DataAccess.EF;
using DataAccess.Abstract;
using DataAccess.Concrete.EF.Context;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess.Concrete.EF.Repositories
{
    public class EFCustomerRepository : EFGenericRepositoryBase<Customer, ReCapContext>, ICustomerDal
    {
        public List<CustomerDetailDto> GetCustomerDetails()
        {
            using (ReCapContext context = new ReCapContext())
            {
                var result = from c in context.Customers
                             join u in context.Users on c.UserId equals u.Id
                             select new CustomerDetailDto { CustomerId = c.Id, FirstName = u.FirstName + " " + u.LastName, CompanyName = c.CompanyName };
                return result.ToList();
            }
        }
        public List<CustomerDetailDto> GetCustomerDetails(Expression<Func<Customer, bool>> filter = null)
        {
            using (ReCapContext context = new ReCapContext())
            {
                var result = from ct in filter == null ? context.Customers : context.Customers.Where(filter)
                             join us in context.Users
                                 on ct.UserId equals us.Id
                             select new CustomerDetailDto
                             {
                                 CustomerId = ct.Id,
                                 UserId = us.Id,
                                 CompanyName = ct.CompanyName,
                                 Email = us.Email,
                                 FirstName = us.FirstName,
                                 LastName = us.LastName,
                                 Status = us.Status
                             };
                return result.ToList();

            }
        }
        public UserCustomerDto GetCustomerIdOfUser(string email)
        {
            using (ReCapContext context = new ReCapContext())
            {
                var result = from c in context.Customers
                             join u in context.Users on c.UserId equals u.Id
                             where u.Email == email
                             select new UserCustomerDto
                             {
                                 userId = u.Id,
                                 email = u.Email,
                                 customerId = c.Id,
                                 FindeksScore = c.FindeksScore,
                                 CompanyName = c.CompanyName
                             };

                return result.SingleOrDefault();
            };
        }
    }
}
