using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Shop.Catalog.Domain;
using Shop.Catalog.Domain.SeedData;

namespace Shop.Catalog.DataAccess.Impl
{
    public class MockProductRepository : IProductRepository
    {
        private List<Product> Products { get; }

        public MockProductRepository(IProductSeedDataGenerator dataGenerator)
        {
            Products = dataGenerator.GetSeedData(100);
        }

        public Task<IEnumerable<Product>> GetAllAsync()
        {
            return Task.FromResult(Products.AsEnumerable());
        }

        public Task<Product> FindByIdAsync(Guid id)
        {
            return Task.FromResult(Products.FirstOrDefault(p => p.Id.Equals(id)));
        }

        public Task<IEnumerable<Product>> FindByConditionASync(Expression<Func<Product, bool>> condition)
        {
            return Task.FromResult(Products.Where(condition.Compile()));
        }

        public Task<Product> FindFirstByConditionAsync(Expression<Func<Product, bool>> condition)
        {
            return Task.FromResult(Products.FirstOrDefault(condition.Compile()));
        }

        public Task CreateAsync(Product product)
        {
            Products.Append(product);
            return Task.CompletedTask;
        }

        public Task DeleteAsync(Product product)
        {
            Products.Remove(product);
            return Task.CompletedTask;
        }

        public Task UpdateAsync(Product product)
        {
            var existing = Products.First(p => p.Id == product.Id);
            Products.Remove(existing);
            Products.Append(product);
            return Task.CompletedTask;
        }
    }
}