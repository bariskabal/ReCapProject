using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Validation;
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
    public class CarManager : ICarService
    {
        private readonly ICarDal _carDal;
        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }
        //[SecuredOperation("car.add,admin")]
        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Add(Car car)
        {
                _carDal.Add(car);
                return new SuccessResult(Message.CarAdded);
        }
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Message.CarDeleted);
        }
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult(Message.CarUpdated);
        }
        [CacheAspect]
        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Message.CarsListed);
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            var data = _carDal.GetCarDetails();
            return new SuccessDataResult<List<CarDetailDto>>(data, Message.CarsDetailsListed);
        }

        public IDataResult<List<CarDetailDto>> GetCarsByBrandId(int id)
        {
            var data = _carDal.GetCarsByBrandId(id);
            return new SuccessDataResult<List<CarDetailDto>>(data, Message.CarsListed);
        }

        public IDataResult<List<CarDetailDto>> GetCarsByColorId(int id)
        {
            var data = _carDal.GetCarsByColorId(id);
            return new SuccessDataResult<List<CarDetailDto>>(data, Message.CarsListed);
        }
        [CacheAspect]
        [PerformanceAspect(5)]
        public IDataResult<Car> GetById(int id)
        {
            var data = _carDal.Get(c => c.Id == id);
            return new SuccessDataResult<Car>(data, Message.CarsListed);
        }

        public IDataResult<List<CarDetailDto>> GetCarDetailsById(int id)
        {
            var data = _carDal.GetCarDetailsById(id);
            return new SuccessDataResult<List<CarDetailDto>>(data, Message.CarsListed);
        }
        [CacheAspect]
        public IDataResult<List<CarDetailDto>> GetCarDetailsFilter(int brandId, int colorId)
        {
            var data = _carDal.GetCarDetails(brandId, colorId);
            return new SuccessDataResult<List<CarDetailDto>>(data,Message.CarsListed);
        }
    }
}
