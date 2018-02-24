using Auctions.Domain;
using Microsoft.EntityFrameworkCore;

namespace Auctions.Context
{
    public class ContextDb : DbContext
    {

        public DbSet<Auction> Auctions { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-L51S99M;Initial Catalog=AuctionDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }
    }
}