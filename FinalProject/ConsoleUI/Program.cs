using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using System.Net.Http.Headers;

namespace ConsoleUI
{
    // SOLID = O
    // Open Closed Principle
    // Yaptığın yazılıma yeni bir özellik ekliyosan mevcuttaki hiç bir koduna dokunamazsın
    internal class Program
    {
        static void Main(string[] args)
        {
            ProductTest();
            //CategoryTest();
        }

        private static void CategoryTest()
        {
            CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
            foreach (var category in categoryManager.GetAll())
            {
                Console.WriteLine(category.CategoryName);
            }
        }

        private static void ProductTest()
        {
            ProductManager productManager = new ProductManager(new EfProductDal());
            foreach (var pManager in productManager.GetProductDetails())
            {
                Console.WriteLine(pManager.ProductName + "//" + pManager.CategoryName);
            }
        }
    }
}
