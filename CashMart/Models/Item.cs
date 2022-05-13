namespace CashMart.Models
{
    class Item
    {
        public Item(string name, int price)
        {
            Name = name;
            Price = price;
        }
        public string Name { get; set; }
        public int Price { get; set; }
    }
}
