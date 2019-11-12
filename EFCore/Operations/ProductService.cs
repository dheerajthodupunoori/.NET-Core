using EFCore.Interface;
using EFCore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EFCore.Operations
{
    public class ProductService : IProductService
    {
        private readonly ProductContext _productContext;
        private readonly ProductSqlServerContext _productSqlServerContext;
        public ProductService()
        {
            _productContext = new ProductContext();
            _productSqlServerContext = new ProductSqlServerContext();
        }

        public void InsertProduct()
        {
            Product product = new Product()
            {
                Name = "SQL"
            };

            try
            {
                _productSqlServerContext.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [EFCore].[dbo].[Products] ON");
                _productSqlServerContext.SaveChanges();
                _productContext.Add(product);
                _productSqlServerContext.Add(product);
                _productContext.SaveChanges();
                _productSqlServerContext.SaveChanges();
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

        public void TruncateProductsTable()
        {
            Console.WriteLine("Truncating products table");
            foreach(var product in _productContext.products)
            {
                _productContext.products.Remove(product);
            }
            Console.WriteLine("Truncating products table completed");
        }
    }
}
