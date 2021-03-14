using Business.Concrete;
using Core.Entities.Concrete;
using DataAccess.Concrete.EF.Repositories;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            AddingRental();
            //AddingCustomer();
            //AddingUser();
            //CarDetailsTest();
        }
        private static void AddingRental()
            {
                Rental rent = new Rental();
                rent.CarId = 4;
                rent.CustomerId = 1;
                rent.RentDate = DateTime.Now;
                RentalManager rentalManager = new RentalManager(new EFRentalRepository());
                Console.WriteLine(rentalManager.Add(rent).Message);
            }

            private static void AddingCustomer()
            {
                Customer customer1 = new Customer();
                customer1.UserId = 1;
                customer1.CompanyName = "KABALLSS";
                CustomerManager customerManager = new CustomerManager(new EFCustomerRepository());
                Console.WriteLine(customerManager.Add(customer1).Message);
            }

            private static void AddingUser()
            {
                User user = new User();
                user.FirstName = "naber";
                user.LastName = "ii";
                user.Email = "naber@gmail.com";
                user.Password = "1234";
                UserManager userManager = new UserManager(new EFUserRepository());
                Console.WriteLine(userManager.Add(user).Message);
            }

            private static void CarDetailsTest()
            {
                CarManager carManager = new CarManager(new EFCarRepository());
                foreach (var item in carManager.GetCarDetails().Data)
                {
                    Console.WriteLine(item.CarName + " - " + item.BrandName + " - " + item.ColorName);
                }
            }

            private static void BrandManagerTest()
            {
                BrandManager brandManager = new BrandManager(new EFBrandRepository());
                var brands = brandManager.GetAll().Data;
            foreach (var item in brands)
            {
                Console.WriteLine(item.BrandName);
            }
            }

            private void ColorManagerTest()
            {
                ColorManager colorManager = new ColorManager(new EFColorRepository());

                // colorManager.Delete(colorManager.GetById(10));
            }

            private static void CarManagerTest()
            {
                CarManager carManager = new CarManager(new EFCarRepository());

                //foreach (var c in carManager.GetAll())
                //{
                //    Console.WriteLine(c.Description);
                //}


            }


        
    }
}
