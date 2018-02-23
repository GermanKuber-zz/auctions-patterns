namespace ConsoleApp2
{
    public interface IStatus
    {
        AuctionStatusEnum Status { get; }
        void Do();
    }
}