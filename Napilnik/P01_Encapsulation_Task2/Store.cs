using System;
using System.Text;
using System.Threading.Tasks;

namespace Napilnik.Napilnik.P01_Encapsulation_Task2
{
    internal class Store
    {
        public static void RunExample()
        {
            Good iPhone12 = new Good("IPhone 12");
            Good iPhone11 = new Good("IPhone 11");

            Warehouse warehouse = new Warehouse();

            Shop shop = new Shop(warehouse);

            warehouse.Deliver(iPhone12, 10);
            warehouse.Deliver(iPhone11, 1);

            Console.WriteLine("\nВывод всех товаров на складе с их остатком");
            warehouse.ShowReport();

            shop.TryAddGoodsToCart(iPhone12, 4);
            //shop.TryAddGoodsToCart(iPhone11, 3);

            Console.WriteLine("\nВывод всех товаров на складе и в корзине с их остатком ДО покупки");
            warehouse.ShowReport();
            shop.ShowCartReport();

            shop.BuyGoodsInCart();

            Console.WriteLine("\nВывод всех товаров на складе и в корзине с их остатком ПОСЛЕ покупки");
            warehouse.ShowReport();
            shop.ShowCartReport();
            shop.ShowOrderPayLink();
        }
    }
}
