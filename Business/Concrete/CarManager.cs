using Business.Abstract;
using Business.Constants;
using Core.Utilities;
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

        public IResult Add(Car car)
        {
            if(car.CarName.Length>2 && car.DailyPrice > 0)
            {
                _carDal.Add(car);
                return new SuccessResult(Message.CarAdded);
            }
            else
            {
                return new ErrorResult(Message.ErrorMessage);
            }
        }

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Message.CarDeleted);
        }
        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult(Message.CarUpdated);
        }

        public IDataResult<List<Car>> GetAll()
        {
            var data = _carDal.GetAll();
            return new SuccessDataResult<List<Car>>(data, Message.CarsListed);
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            var data = _carDal.GetCarDetails();
            return new SuccessDataResult<List<CarDetailDto>>(data, Message.CarsDetailsListed);
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int id)
        {
            var data = _carDal.GetAll(c => c.BrandId == id);
            return new SuccessDataResult<List<Car>>(data, Message.CarsListed);
        }

        public IDataResult<List<Car>> GetCarsByColorId(int id)
        {
            var data = _carDal.GetAll(c => c.ColorId == id);
            return new SuccessDataResult<List<Car>>(data, Message.CarsListed);
        }

        
    }
}
