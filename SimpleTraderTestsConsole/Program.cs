using SimpleTrader.Domain.Models;
using SimpleTrader.Domain.Services;
using SimpleTrader.EntityFrameworkCore;
using SimpleTrader.EntityFrameworkCore.Services;
using System;
using System.Linq;

namespace SimpleTraderTestsConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            SimpleTraderDbContextFactory context = new SimpleTraderDbContextFactory();
            IDataService<User> dataServiceUser = new GenericDataService<User>(context);
            //dataServiceUser.Create(new User { Username = "Test2" }).Wait();
            Console.WriteLine(dataServiceUser.Get(1).Result);
            Console.ReadLine();
        }
    }
}
