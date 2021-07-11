namespace Napilnik.Napilnik.P01_Encapsulation_Task2
{
    internal struct GoodRecord
    {
        public Good Good;
        public int Count;

        public GoodRecord(Good good, int count)
        {
            Good = good;
            Count = count;
        }
    }
}