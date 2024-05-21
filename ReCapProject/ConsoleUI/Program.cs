using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System.ComponentModel.DataAnnotations;

namespace ConsoleUI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            InMemoryDal inMemoryDal = new InMemoryDal();
            inMemoryDal.GetById(1);
        }
    }
}
