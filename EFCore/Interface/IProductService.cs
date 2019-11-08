using System;
using System.Collections.Generic;
using System.Text;

namespace EFCore.Interface
{
    public interface IProductService
    {
         void InsertProduct();

        void GetProducts();

        void UpdateProduct();

        void DeleteProduct();
    }
}
