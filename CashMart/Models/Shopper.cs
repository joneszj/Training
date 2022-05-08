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
        public IEnumerable<Item> ItemsToReturn { get; set; }

        public Shopper GoShopping(Random rng, Market market)
        {
            // this is quite difficult to read
            // IEnumerable has no means of adding after creation, we can only set it with another IEnumerable
            // see remarks https://docs.microsoft.com/en-us/dotnet/api/system.linq.enumerable.selectmany?view=net-6.0 to understand why this has values 
            ItemsToBuy = Enumerable.Range(1, rng.Next(1, 20))
                .Select(RandomItem(rng, market))
                .SelectMany(e => e).Where(e=>e.Price > 5);
            // ItemsToBuy is niether an array or a list, in this context it is an iterator: https://stackoverflow.com/questions/47786030/what-is-the-default-concrete-type-of-ienumerable/72165814#72165814

            foreach (var item in ItemsToBuy)
            {

            }

            ItemsToReturn = Enumerable.Range(1, rng.Next(0, 5))
                .Select(RandomItem(rng, market))
                .SelectMany(e => e);

            //// where as this is a bit easier to read, though verbose
            //var returnsCount = rng.Next(0, 5);
            //foreach (var item in Enumerable.Range(1, returnsCount))
            //{
            //    var randomItemIndex = rng.Next(1, market.Items.Count());
            //    // ItemsToReturn is ICollection<Item>, which has an Add(), simplifying the same process
            //    ItemsToReturn.Add(market.Items.Skip(randomItemIndex).First());
            //}

            return this;
        }

        private static Func<int, IEnumerable<Item>> RandomItem(Random rng, Market market)
        {
            return e => market.Items.Skip(rng.Next(1, market.Items.Count())).Take(1);
        }
    }
}
