using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashMart.Models
{
    class Shopper
    {
        public static IEnumerable<Shopper> CreateShoppers(int count)
        {
            for (int i = 0; i < count; i++)
            {
                yield return new Shopper();
            }
        }
        public IEnumerable<Item> ItemsToBuy { get; set; }
        public ICollection<Item> ItemsToReturn { get; set; }

        public Shopper GoShopping(Random rng, Market market)
        {
            var itemsCount = rng.Next(1, 20);
            // this is quite difficult to read
            // IEnumerable has no means of adding, we can only set it with another IEnumerable
            this.ItemsToBuy = Enumerable.Repeat(market.Items.Skip(rng.Next(1, market.Items.Count())).First(), itemsCount);

            // where as this is a bit easier to read, though verbose
            var returnsCount = rng.Next(0, 5);
            foreach (var item in Enumerable.Range(1, returnsCount))
            {
                var randomItemIndex = rng.Next(1, market.Items.Count());
                // ItemsToReturn is ICollection<Item>, which has an Add(), simplifying the same process
                this.ItemsToReturn.Add(market.Items.Skip(randomItemIndex).First());
            }

            return this;
        }
    }
}
