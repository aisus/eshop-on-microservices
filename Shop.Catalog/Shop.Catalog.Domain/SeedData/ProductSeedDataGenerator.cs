using System;
using System.Collections.Generic;
using System.Linq;

namespace Shop.Catalog.Domain.SeedData
{
    public class ProductSeedDataGenerator : IProductSeedDataGenerator
    {
        private readonly string[] _names =
        {
            "ProductName",
        };

        private readonly string[] _manufacturers =
        {
            "Apple",
            "IBM",
            "HP",
            "Acer",
            "Asus",
            "Sony"
        };

        private readonly string[] _categories =
        {
            "Phones",
            "Notebooks",
            "PCs",
            "Tablets",
            "Audio"
        };

        private readonly string _description =
            "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et";

        private List<Product> Generated { get; set; }

        public List<Product> GetSeedData(int count)
        {
            if (Generated == null)
            {
                Generated = new List<Product>();
            }

            if (count <= Generated.Count)
            {
                return Generated.Take(count).ToList();
            }

            var delta = count - Generated.Count;
            var rnd = new Random();

            for (var i = 0; i < delta; i++)
            {
                Generated.Add(new Product
                {
                    Id = Guid.NewGuid(),
                    Name = _names[rnd.Next(_names.Length)],
                    Category = _categories[rnd.Next(_categories.Length)],
                    Description = _description,
                    Manufacturer = _manufacturers[rnd.Next(_manufacturers.Length)],
                    Price = (decimal) Math.Round(rnd.NextDouble() * 1000, 2)
                });
            }

            return Generated;
        }
    }
}