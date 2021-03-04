using Business.Concrete;
using DataAccess.Concrete.EF.Repositories;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager1 = new CarManager(new EFCarRepository());
            carManager1.Add(new Entities.Concrete.Car()
            {Id=1, BrandId = 1, ColorId = 1, CarName = "Doblo", ModelYear = "2005", DailyPrice = 50, Description = "Arabaya dair herhangi bir sorundan müşteri sorumludur." });
        }
    }
}
