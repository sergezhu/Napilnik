using System;
using System.Collections.Generic;
using System.Linq;

namespace Napilnik.Napilnik.P01_Encapsulation_Task2
{
    internal class Cart
    {
        private readonly Warehouse _warehouse;
        private readonly List<GoodRecord> _goodRecords;

        private Order _order;

        public int GoodRecordsCount => _goodRecords.Count();

        public Cart(Warehouse warehouse)
        {
            _warehouse = warehouse;
            _goodRecords = new List<GoodRecord>();
        }

        public bool TryAddGoods(Good good, int count)
        {
            Console.WriteLine($"good [{good.Title}]  count [{count}]  CanTake(good, count) {_warehouse.CanTake(good, count)}");


            if (good is null)
                throw new NullReferenceException(nameof(good));

            if (count < 0)
                throw new ArgumentOutOfRangeException(nameof(count));

            if(_order != null)
                throw new Exception("It is not possible to add an good to an already paid cart");

            var canTake = _warehouse.CanTake(good, count);

            if (canTake)
            {
                AddGoods(good, count);
            }
            else
            {
                throw new ArgumentException($"There is not enough good [{good.Title}] in warehouse");
            }

            return canTake;
        }

        public void Clear()
        {
            _goodRecords.Clear();
        }

        public void Buy()
        {
            if (GoodRecordsCount == 0)
                throw new Exception("There can not to buy from empty cart");

            _goodRecords.ForEach(record =>
            {
                _warehouse.Take(record.Good, record.Count);
            });

            _order = CreateOrder();
        }

        public void ShowReport()
        {
            Console.WriteLine("\nCART REPORT");
            Console.WriteLine("================");

            for (int i = 0; i < _goodRecords.Count; i++)
            {
                Console.WriteLine($"{i}.  {_goodRecords[i].Good.Title}  [ {_goodRecords[i].Count} ]");
            }
        }

        public void ShowPayLink()
        {
            Console.WriteLine($"\nPAY LINK ====>  [ {_order.PayLink} ]");
        }
        public int FindGoodIndex(Good good)
        {
            return _goodRecords.FindIndex(g => g.Good == good);
        }

        private void AddGoods(Good good, int count)
        {
            //var index = _warehouse.FindGoodIndex(good);
            var index = FindGoodIndex(good);

            if (index == -1)
            {
                _goodRecords.Add(new GoodRecord(good, count));
            }
            else
            {
                var newGoodCount = _goodRecords[index].Count + count;
                _goodRecords[index] = new GoodRecord(_goodRecords[index].Good, newGoodCount);
            }
        }

        private Order CreateOrder()
        {
            var order = new Order(CreateOrderPayLink());
            return order;
        }

        private string CreateOrderPayLink()
        {
            var uri = "https://someshop.ru/";
            var result = uri;
            
            _goodRecords.ForEach(record =>
            {
                result = $"{result}{record.Good.Title}_{record.Count}_";
            });

            var randomHashLength = 20;
            for (int i = 0; i < randomHashLength; i++)
            {
                var r = new Random();
                result = $"{result}{r.Next() % 10}";
            }

            return result;
        }
    }
}