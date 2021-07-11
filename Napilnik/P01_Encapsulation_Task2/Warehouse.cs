using System;
using System.Collections.Generic;

namespace Napilnik.Napilnik.P01_Encapsulation_Task2
{
    internal class Warehouse
    {
        private readonly List<GoodRecord> _goodRecords;
        
        public Warehouse()
        {
            _goodRecords = new List<GoodRecord>();
        }

        public void Deliver(Good good, int count)
        {
            if(good is null)
                throw new NullReferenceException(nameof(good));

            if(count < 0)
                throw new ArgumentOutOfRangeException(nameof(count));
            
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

        public void Take(Good good, int count)
        {
            if (good is null)
                throw new NullReferenceException(nameof(good));

            if (count < 0)
                throw new ArgumentOutOfRangeException(nameof(count));

            if (CanTake(good, count))
            {
                var goodIndex = FindGoodIndex(good);
                var newGoodCount = _goodRecords[goodIndex].Count - count;

                if (newGoodCount == 0)
                {
                    _goodRecords.RemoveAt(goodIndex);
                }
                else
                {
                    _goodRecords[goodIndex] = new GoodRecord(_goodRecords[goodIndex].Good, newGoodCount);
                }
            }
            else
            {
                throw new ArgumentException($"There is not enough good [{good.Title}] in warehouse");
            }
        }

        public bool CanTake(Good good, int count)
        {
            var wareHouseGoodCount = GetGoodCount(good);
            return count <= wareHouseGoodCount;
        }

        public int FindGoodIndex(Good good)
        {
            return _goodRecords.FindIndex(g => g.Good == good);
        }

        public int GetGoodCount(Good good)
        {
            var index = FindGoodIndex(good);
            return index == -1 ? -1 : _goodRecords[index].Count;
        }

        public void ShowReport()
        {
            Console.WriteLine("\nWAREHOUSE REPORT");
            Console.WriteLine("================");

            for (int i = 0; i < _goodRecords.Count; i++)
            {
                Console.WriteLine($"{i}.  {_goodRecords[i].Good.Title}  [ {_goodRecords[i].Count} ]");
            }
        }
    }
}