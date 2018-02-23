namespace ConsoleApp2
{
    public interface IHasRound
    {
        Rounds Rounds { get; }
        void AddProvider(Provider provider);
    }
}