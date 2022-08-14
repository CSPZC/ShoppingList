namespace ShoppingList
{
    public class Purchase : Java.Lang.Object
    {
        public string name { get; set; }
        public decimal price { get; set; }
        public int picResource { get; set; }
        public Purchase(string _name, decimal _price, int _pic)
        {
            name = _name;
            price = _price;
            picResource = _pic;
        }
    }
}
