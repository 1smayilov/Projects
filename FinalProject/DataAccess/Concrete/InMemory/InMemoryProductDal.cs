﻿using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _products;
        public InMemoryProductDal()
        {
            _products = new List<Product>
            {
                new Product{ProductId=1,CategoryId=1,ProductName="Sthekan",UnitPrice=15,UnitsInStock=12},
                new Product{ProductId=2,CategoryId=1,ProductName="Kamera",UnitPrice=500,UnitsInStock=3},
                new Product{ProductId=3,CategoryId=2,ProductName="Telefon",UnitPrice=1200,UnitsInStock=5},
                new Product{ProductId=4,CategoryId=2,ProductName="Klavyatura",UnitPrice=250,UnitsInStock=45},
                new Product{ProductId=5,CategoryId=2,ProductName="Mış",UnitPrice=120,UnitsInStock=78}
            };
        }
        public void Add(Product product)
        {
            // Üstdəki product Uİ dan gəlir
            // Business dən gələni Database-ə yükləyirəm
            _products.Add(product); 
        }

        public void Delete(Product product)
        {
            // productToDelete burada artıq eyni referanslı 2 dəyəri tapır
            Product productToDelete = _products.SingleOrDefault(p=>p.ProductId == product.ProductId);
            _products.Remove(productToDelete);
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll()
        {
            return _products;
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAllByCategory(int categoryId)
        {
            return _products.Where(p => p.CategoryId == categoryId).ToList();
        }

        public List<ProductDetailDto> GetProductDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Product product)
        {
            Product productToUpdate = _products.SingleOrDefault(p=>p.ProductId == product.ProductId);
            productToUpdate.CategoryId = product.CategoryId;
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.UnitPrice = product.UnitPrice;
            productToUpdate.UnitsInStock = product.UnitsInStock;
        }
    }
}
