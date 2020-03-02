using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Shop.Catalog.Domain;

namespace Shop.Catalog.DataAccess
{
    public interface IProductRepository
    {
        public Task<IEnumerable<Product>> GetAllAsync();
        public Task<Product> FindByIdAsync(Guid id);
        public Task<IEnumerable<Product>> FindByConditionASync(Expression<Func<Product, bool>> condition);
        public Task<Product> FindFirstByConditionAsync(Expression<Func<Product, bool>> condition);

        public Task CreateAsync(Product product);
        public Task DeleteAsync(Product product);
        public Task UpdateAsync(Product product);
    }
}