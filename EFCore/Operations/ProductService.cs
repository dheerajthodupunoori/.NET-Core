using EFCore.Interface;
using EFCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EFCore.Operations
{
    public class ProductService : IProductService
    {
        private readonly ProductContext _productContext;
        public ProductService()
        {
            _productContext = new ProductContext();
        }

        public void InsertProduct()
        {
            Product product = new Product()
            {

                Name = "SQL"
            };


            try
            {
                _productContext.Add(product);
                _productContext.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Insertion Failed", ex.Message);
            }

            return;
        }


        public void GetProducts()
        {
            List<Product> products = new List<Product>();

            products = _productContext.products.ToList();
            foreach (Product product in products)
            {
                Console.WriteLine("ID:" + product.Id + "    Name : " + product.Name);
            }

        }


        public void UpdateProduct()
        {
            Product product = _productContext.products.Find(4);
            Console.WriteLine("Product details before updating:");
            Console.WriteLine("ID:" + product.Id + "    Name : " + product.Name);
            product.Name = "dheeraj";
            _productContext.SaveChanges();
            Console.WriteLine("Product details after updating:");
            Product updatedProduct = _productContext.products.Find(4);
            Console.WriteLine("ID:" + updatedProduct.Id + "    Name : " + updatedProduct.Name);
        }

        public void DeleteProduct()
        {
            Product product = _productContext.products.Find(_productContext.products.Last<Product>().Id);
            Console.WriteLine("Product to be deleted is:");
            Console.WriteLine("ID:" + product.Id + "    Name : " + product.Name);
            _productContext.products.Remove(product);
            _productContext.SaveChanges();
            Console.WriteLine("Remaining products after deleting", product.Name);
            GetProducts();
        }
    }
}
