namespace Auctions
{
    public interface IHasRound
    {
        Rounds Rounds { get; }
        void AddProvider(Provider provider);
    }
}