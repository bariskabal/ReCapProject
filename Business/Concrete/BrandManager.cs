using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;
        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }
        [ValidationAspect(typeof(BrandValidator))]
        public IResult Add(Brand brand)
        {
            _brandDal.Add(brand);
            return new SuccessResult(Message.BrandAdded);
        }

        public IResult Delete(Brand brand)
        {
            _brandDal.Delete(brand);
            return new SuccessResult(Message.BrandDeleted);
        }

        public IDataResult<List<Brand>> GetAll()
        {
            var data = _brandDal.GetAll();
            return new SuccessDataResult<List<Brand>>(data, Message.BrandsListed);
        }

        public IDataResult<Brand> GetById(int id)
        {
            var data = _brandDal.Get(b => b.BrandId == id);
            return new SuccessDataResult<Brand>(data, Message.BrandsListed);
        }

        public IResult Update(Brand brand)
        {
            return new SuccessResult(Message.BrandUpdated);
        }
    }
}
