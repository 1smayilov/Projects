using Business.Concrete;
using Core.Entities.Concrete;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System.ComponentModel.DataAnnotations;
using System.Net.WebSockets;

namespace ConsoleUI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //CarTest();
            //BrandTest();
            //ColorTest();
            //RentalTest();
            //UserTest();
            //CustomerTest();

        }

        private static void CustomerTest()
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());

            var result = customerManager.Delete;
            
        }

        //private static void UserTest()
        //{
        //    UserManager userManager = new UserManager(new EfUserDal());
        //    User newUser = new User();
        //    //newUser.Firstname = "Elvin";
        //    //newUser.Lastname = "Ismayilov";
        //    //newUser.Email = "elvin1smayilov";
        //    //newUser.Password = "123456";

        //    var result = userManager.Insert(newUser);



        //    if (result.Success)
        //    {
        //        Console.WriteLine(newUser.FirstName + " " + newUser.LastName);
        //        Console.WriteLine(result.Message);
        //    }
        //    else
        //    {
        //        Console.WriteLine(result.Message);
        //    }
        //}

        private static void RentalTest()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            var result = rentalManager.GetAll();

            if (result.Success)
            {

                foreach (var resultItem in result.Data)
                {
                    Console.WriteLine(resultItem.RentDate);
                    Console.WriteLine(result.Message);
                }

            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void ColorTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            var result = colorManager.GetbyID(2);

            if (result.Success) 
            {
                var color = result.Data;

                Console.WriteLine(color.ColorName);
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void BrandTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            {
                var result = brandManager.GetAll();

                if(result.Success)
                {
                    foreach (var brand in result.Data)
                    {
                        Console.WriteLine(brand.BrandName);
                    }
                }
                else
                {
                    Console.WriteLine(result.Message);
                }
            }
        }

        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            var result = carManager.GetCarDetails();
            if (result.Success)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine($"Avtomobilin adı-{car.CarName}" + ". " +
                    $"Modelinin adı-{car.BrandName}" + ". " +
                    $"Avtomobilin rengi-{car.ColorName}" + ". " +
                    $"Gunluk icare haqqı-{car.DailyPrice} Azn");
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }
    }
}
