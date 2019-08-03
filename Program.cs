using System;
using MongoDbConsoleDemo.Models;
using MongoDbConsoleDemo.Repository;
using MongoDbConsoleDemo.Utils;

namespace MongoDbConsoleDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            AssetsRepository _repo = new AssetsRepository();

            Console.WriteLine(DateTime.Now);

            _repo.Create(new Asset()
            {
                Code = new Random().Next(2) % 2 == 0
                ? ((int)HelperMath.RandomEnumValue<AlarmType>()).ToString()
                : ((int)HelperMath.RandomEnumValue<WarningType>()).ToString(),
                DateCreate = DateTime.Now,
                DateMeasure = DateTime.Now
            });

            foreach (Asset asset in _repo.Get())
            {
                Console.WriteLine("{0} : {1} : {2}", asset.Code, asset.DateMeasure, asset.DateCreate);
            }
        }
    }
}
