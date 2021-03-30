using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Abstract
{
    public interface ICarDal : IGenericDal<Car>
    {
        List<CarDetailDto> GetCarDetails();
        List<CarDetailDto> GetCarDetailsById(int id);
        List<CarDetailDto> GetCarsByBrandId(int id);
        List<CarDetailDto> GetCarsByColorId(int id);
        List<CarDetailDto> GetCarDetails(int brandId,int colorId);
    }
}
