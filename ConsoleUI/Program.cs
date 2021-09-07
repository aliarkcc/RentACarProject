using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            BrandManager carService = new BrandManager(new EfBrandDal());
            var result = carService.GetAll();
            foreach (var item in result.Data)
            {
                Console.WriteLine(item.BrandName);
            }
        }
    }
}
