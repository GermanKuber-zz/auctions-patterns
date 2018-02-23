namespace ConsoleApp2
{
    public interface IAuction : IHasRound
    {
        IStatus AuctionStatus { get; set; }
        RoundPattern RoundPattern { get;}
        AuctionProviders Providers { get; }
        Rounds Rounds { get; }
        
        void Do();
        void AddProvider(Provider provider);
        void AddRound(AuctionProviders providers);
    }
}