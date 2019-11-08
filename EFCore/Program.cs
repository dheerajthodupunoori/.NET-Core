using EFCore.Operations;
using System;

namespace EFCore
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("EFCore demo solution - inserting into database");
            ProductService _productService = new ProductService();
            _productService.InsertProduct();
            Console.WriteLine("EFCore demo solution - inserting into database completed");
            Console.WriteLine("Retrieving products started");
            _productService.GetProducts();
            Console.WriteLine("Retreiving products completed");
            _productService.UpdateProduct();
            _productService.DeleteProduct();
            Console.ReadKey();
        }
    }
}
