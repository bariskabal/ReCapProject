﻿using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string CarAdded = "New car added";
        public static string CarDeleted = "The car was deleted";
        public static string CarUpdated = "The car was updated";
        public static string CarsListed = "Cars listed";
        public static string CarNameInvalid = "Car name is invalid";
        public static string CarImageLimitExceeded = "Car Image Limit Exceeded";

        public static string BrandAdded = "New Brand added";
        public static string BrandDeleted = "The brand was deleted";
        public static string BrandUpdated = "The brand was updated";
        public static string BrandListed = "Brands listed";

        public static string ColorAdded = "New color added";
        public static string ColorDeleted = "The color was deleted";
        public static string ColorUpdated = "The color wad updated";
        public static string ColorListed = "Colors listed";
        public static string MaintenanceTime = "The system is under maintenance";

        public static string UserAdded = "New User added";
        public static string UserDeleted = "The user was deleted";
        public static string UserUpdated = "The user was updated";
        public static string UserListed = "Users listed";

        public static string CustomerAdded = "New Customer added";
        public static string CustomerDeleted = "The customer was deleted";
        public static string CustomerUpdated = "The customer was updated";
        public static string CustomerListed = "Customers listed";

        public static string RentalAdded = "New Rental added";
        public static string RentalDeleted = "The rental was deleted";
        public static string RentalUpdated = "The rental was updated";
        public static string RentalListed = "Rentals listed";
        public static string RentalAddedError = "Cannot be rented because the vehicle is not delivered";
        public static string RentalUpdatedReturnDate = "The vehicle has been received";
        public static string RentalUpdatedReturnDateError = "Vehicle already received";

        public static string AuthorizationDenied = "Yetkiniz yok";

        public static string UserRegistered = "Kayıt oldu";
        public static string UserNotFound = "Kullanıcı bulunamadı";
        public static string PasswordError = "Parola hatası";
        public static string SuccessfulLogin = "Başarılı giriş";
        public static string UserAlreadyExists = "Kullanıcı mevcut";
        public static string AccessTokenCreated = "Token oluşturuldu";

        public static string ErrorMessage = "Error added";

        public static string BrandsListed { get; internal set; }
        public static string CarImagesListed { get; internal set; }
        public static string ColorsListed { get; internal set; }
        public static string RentalsListed { get; internal set; }
        public static string UsersListed { get; internal set; }
        public static User MessageNotListed { get; internal set; }
        public static string MessageListed { get; internal set; }
        public static string CardUpdated { get; internal set; }
        public static string CardIsExists { get; internal set; }
        public static string PaymentAdded { get; internal set; }
        public static string CardAdded { get; internal set; }
        public static string CardDeleted { get; internal set; }
    }
}
