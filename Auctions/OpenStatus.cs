using System;

namespace ConsoleApp2
{
    public class OpenStatus : IStatus
    {
        public AuctionStatusEnum Status { get; } = AuctionStatusEnum.Open;

        public void Do()
        {
            Console.WriteLine("Estoy Abierto");

        }
    }
}