using Core.DataAccess.EF;
using DataAccess.Abstract;
using DataAccess.Concrete.EF.Context;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EF.Repositories
{
    public class EFCarImageRepository : EFGenericRepositoryBase<CarImage,ReCapContext>, ICarImageDal
    {
    }
}
