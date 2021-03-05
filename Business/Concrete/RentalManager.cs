using Business.Abstract;
using Business.Constants;
using Core.Utilities;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        private readonly IRentalDal _rentalDal;
        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }
        public IResult Add(Rental rental)
        {
            var result = _rentalDal.GetAll(r => r.CarId == rental.CarId && r.ReturnDate == default(DateTime));
            if (result.Count == 0)
            {
                _rentalDal.Add(rental);
                return new SuccessResult(Message.RentalAdded);
                
            }
            else
            {
                return new ErrorResult(Message.ErrorMessage);
            }
        }

        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult(Message.RentalDeleted);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            var data = _rentalDal.GetAll();
            return new SuccessDataResult<List<Rental>>(data, Message.RentalsListed);
        }

        public IDataResult<List<Rental>> GetByCarId(int id)
        {
            var data = _rentalDal.GetAll(r => r.CarId == id);
            return new SuccessDataResult<List<Rental>>(data, Message.RentalsListed);
        }

        public IDataResult<List<Rental>> GetByCustomerId(int id)
        {
            var data = _rentalDal.GetAll(r => r.CustomerId == id);
            return new SuccessDataResult<List<Rental>>(data, Message.RentalsListed);
        }

        public IDataResult<Rental> GetById(int id)
        {
            var data = _rentalDal.Get(r => r.Id == id);
            return new SuccessDataResult<Rental>(data, Message.RentalsListed);
        }

        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult(Message.RentalAdded);
        }
    }
}
