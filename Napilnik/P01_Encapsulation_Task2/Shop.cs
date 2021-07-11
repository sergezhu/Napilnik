namespace Napilnik.Napilnik.P01_Encapsulation_Task2
{
    internal class Shop
    {
        private readonly Warehouse _warehouse;
        private readonly Cart _cart;
        
        public Shop(Warehouse warehouse)
        {
            _warehouse = warehouse;
            _cart = new Cart(_warehouse);
        }

        public void ClearCart()
        {
            _cart.Clear();
        }

        public bool TryAddGoodsToCart(Good good, int count)
        {
            return _cart.TryAddGoods(good, count);
        }

        public void BuyGoodsInCart()
        {
            _cart.Buy();
            _cart.Clear();
        }

        public void ShowCartReport()
        {
            _cart.ShowReport();
        }

        public void ShowOrderPayLink()
        {
            _cart.ShowPayLink();
        }
    }
}