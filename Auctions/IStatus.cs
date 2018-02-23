namespace Auctions
{
    public interface IStatus
    {
        AuctionStatusEnum Status { get; }
        void Do();
    }
}