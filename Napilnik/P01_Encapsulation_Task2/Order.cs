namespace Napilnik.Napilnik.P01_Encapsulation_Task2
{
    internal class Order
    {
        public string PayLink { get; }

        public Order(string payLink)
        {
            PayLink = payLink;
        }
    }
}