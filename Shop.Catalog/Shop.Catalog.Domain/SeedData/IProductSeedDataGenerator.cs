using System.Collections.Generic;

namespace Shop.Catalog.Domain.SeedData
{
    public interface IProductSeedDataGenerator
    {
        public List<Product> GetSeedData(int count);
    }
}