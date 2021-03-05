﻿using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface ICarDal : IGenericDal<Car>
    {
        List<CarDetailDto> GetCarDetails();
    }
}
