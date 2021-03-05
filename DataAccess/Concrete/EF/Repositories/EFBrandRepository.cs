using Core.DataAccess.EF;
using DataAccess.Abstract;
using DataAccess.Concrete.EF.Context;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EF.Repositories
{
    public class EFBrandRepository : EFGenericRepositoryBase<Brand,ReCapContext>,IBrandDal
    {
        
    }
}
