using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace BestBuyPractices
{
    public class DapperProductRepository : IProductRepository
    {
        private readonly IDbConnection _connection;

        public DapperProductRepository()
        {
        }

        public DapperProductRepository(IDbConnection connection) 
        {
            _connection = connection;  
        }
        public void CreateProduct(string name, double price, int categoryID)
        {
            _connection.Execute("INSERT INTO products (NAME, PRICE, CategoryID) VALUES (@name, @price, @categoryID);",
                new {name = name, price = price, categoryID = categoryID});
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _connection.Query<Product>("SELECT * from Products;");
        }

        public void UpdateProductName (int productID, string updatedName)
        {
            _connection.Execute("update products set name = @updatedname where productID = @productid;",
                new { updatedName = updatedName, productID = @productID });  
        }

        public void DeleteProduct (int ProductID)
        {
            _connection.Execute("DELETE from reviews where productID = @productID;",
                new { ProductID = ProductID });

            _connection.Execute("Delete from sales where productID = @productID;",
                new { productID = ProductID });

            _connection.Execute("DELETE from products where productID = @productID;",
                new { productID = ProductID });
        }
    }
}
