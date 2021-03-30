using Core.DataAccess.EF;
using DataAccess.Abstract;
using DataAccess.Concrete.EF.Context;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EF.Repositories
{
    public class EFCarRepository : EFGenericRepositoryBase<Car, ReCapContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (ReCapContext context = new ReCapContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands on c.BrandId equals b.BrandId
                             join cl in context.Colors on c.ColorId equals cl.ColorId
                             select new CarDetailDto { CarId = c.Id, CarName = c.CarName, BrandName = b.BrandName, ColorName = cl.ColorName,ModelYear=c.ModelYear, DailyPrice = c.DailyPrice, Description = c.Description,
                                 Status = !context.Rentals.Any(r => r.CarId == c.Id && (r.ReturnDate == null || r.ReturnDate > DateTime.Now))
                             };
                return result.ToList();
            }
        }

        public List<CarDetailDto> GetCarDetailsById(int id)
        {
            using (ReCapContext context = new ReCapContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands on c.BrandId equals b.BrandId
                             join cl in context.Colors on c.ColorId equals cl.ColorId
                             where(c.Id==id)
                             select new CarDetailDto { CarId = c.Id, CarName = c.CarName, BrandName = b.BrandName, ColorName = cl.ColorName, ModelYear = c.ModelYear, DailyPrice = c.DailyPrice, Description = c.Description,
                                 Status = !context.Rentals.Any(r => r.CarId == c.Id && (r.ReturnDate == null || r.ReturnDate > DateTime.Now))
                             };
                return result.ToList();
            }
        }
        public List<CarDetailDto> GetCarsByBrandId(int id)
        {
            using (ReCapContext context = new ReCapContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands on c.BrandId equals b.BrandId
                             join cl in context.Colors on c.ColorId equals cl.ColorId
                             where(c.BrandId==id)
                             select new CarDetailDto { CarId = c.Id, CarName = c.CarName, BrandName = b.BrandName, ColorName = cl.ColorName, ModelYear = c.ModelYear, DailyPrice = c.DailyPrice, Description = c.Description,
                                Status = !context.Rentals.Any(r => r.CarId == c.Id && (r.ReturnDate == null || r.ReturnDate > DateTime.Now))
                             };
                return result.ToList();
            }
        }
        public List<CarDetailDto> GetCarsByColorId(int id)
        {
            using (ReCapContext context = new ReCapContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands on c.BrandId equals b.BrandId
                             join cl in context.Colors on c.ColorId equals cl.ColorId
                             where (c.ColorId == id)
                             select new CarDetailDto { CarId = c.Id, CarName = c.CarName, BrandName = b.BrandName, ColorName = cl.ColorName, ModelYear = c.ModelYear, DailyPrice = c.DailyPrice, Description = c.Description,
                                 Status = !context.Rentals.Any(r => r.CarId == c.Id && (r.ReturnDate == null || r.ReturnDate > DateTime.Now))
                             };
                return result.ToList();
            }
        }
        public List<CarDetailDto> GetCarDetails(int brandId, int colorId)
        {
            using (ReCapContext context = new ReCapContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands on c.BrandId equals b.BrandId
                             join cl in context.Colors on c.ColorId equals cl.ColorId
                             where (c.ColorId== colorId && c.BrandId == brandId)
                             select new CarDetailDto { CarId = c.Id, CarName = c.CarName, BrandName = b.BrandName, ColorName = cl.ColorName, ModelYear = c.ModelYear, DailyPrice = c.DailyPrice, Description = c.Description,
                                 Status = !context.Rentals.Any(r => r.CarId == c.Id && (r.ReturnDate == null || r.ReturnDate > DateTime.Now))
                             };
                return result.ToList();
            }
        }
    }
}
