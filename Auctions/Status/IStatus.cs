namespace Auctions.Status
{
    public interface IStatus
    {
        AuctionStatusEnum Status { get; }
        void Do();
    }
}