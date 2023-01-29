using System.Collections.Generic;
using System.Linq;
using EFDemo.Entities;
using Microsoft.EntityFrameworkCore;

namespace EFDemo
{
    public class Dal
    {
        private readonly EFDemoDbContext _dbContext;

        public Dal(EFDemoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddProduct(Product product)
        {
            _dbContext.Add(new Product
            {
                Name = product.Name,
                Description = product.Description,
                Weight = product.Weight,
                Height = product.Height,
                Width = product.Width,
                Length = product.Length
            });

            _dbContext.SaveChanges();
        }

        public Product GetProductById(int id)
        {
            return _dbContext.Products
                .FirstOrDefault(p => p.Id.Equals(id));
        }

        public void UpdateProduct(Product product)
        {
            var productToUpdate = _dbContext.Products
                .FirstOrDefault(p => p.Id.Equals(product.Id));

            if (productToUpdate != null)
            {
                productToUpdate.Name = product.Name;
                productToUpdate.Description = product.Description;
                productToUpdate.Weight = product.Weight;
                productToUpdate.Height = product.Height;
                productToUpdate.Width = product.Width;
                productToUpdate.Length = product.Length;
            }

            _dbContext.SaveChanges();
        }

        public void DeleteProduct(int id)
        {
            var productToRemove = _dbContext.Products
                .FirstOrDefault(p => p.Id.Equals(id));

            if (productToRemove != null)
                _dbContext.Remove(productToRemove);

            _dbContext.SaveChanges();
        }

        public List<Product> GetAllProducts()
        {
            return _dbContext.Products.ToList();
        }

        public void AddOrder(Order order)
        {
            _dbContext.Add(new Order
            {
                Status = order.Status,
                CreatedDate = order.CreatedDate,
                UpdatedDate = order.UpdatedDate,
                ProductId = order.ProductId
            });

            _dbContext.SaveChanges();
        }

        public Order GetOrderById(int id)
        {
            return _dbContext.Orders
                .FirstOrDefault(o => o.Id.Equals(id));
        }

        public void UpdateOrder(Order order)
        {
            var orderToUpdate = _dbContext.Orders
                .FirstOrDefault(o => o.Id.Equals(order.Id));

            if (orderToUpdate != null)
            {
                orderToUpdate.Status = order.Status;
                orderToUpdate.CreatedDate = order.CreatedDate;
                orderToUpdate.UpdatedDate = order.UpdatedDate;
                orderToUpdate.ProductId = order.ProductId;
            }

            _dbContext.SaveChanges();
        }

        public void DeleteOrder(int id)
        {
            var orderToRemove = _dbContext.Orders
                .FirstOrDefault(o => o.Id.Equals(id));

            if (orderToRemove != null)
                _dbContext.Remove(orderToRemove);

            _dbContext.SaveChanges();
        }

        public List<Order> GetAllOrders()
        {
            return _dbContext.Orders.ToList();
        }

        public List<Order> GetFilteredOrders(
            int? year = null,
            int? month = null,
            OrderStatus? status = null,
            int? product = null)
        {
            return _dbContext.Orders
                .FromSqlRaw($"spGetFilteredOrders @p0, @p1, @p2, @p3", year, month, status, product)
                .ToList();
        }

        public void DeleteOrders(
            int? year = null,
            int? month = null,
            OrderStatus? status = null,
            int? product = null)
        {
            _dbContext.Database
                .ExecuteSqlRaw("spDeleteOrders @p0, @p1, @p2, @p3", year, month, status, product);
        }

        public void ClearAllData()
        {
            _dbContext.Database.ExecuteSqlRaw("EXEC spClearDB");
        }
    }
}