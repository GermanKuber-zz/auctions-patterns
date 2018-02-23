using System.Collections.Generic;
using Auctions.Domain;

namespace Auctions.Entities
{
    public class RoundEntity
    {
        public List<Provider> ProvidersC { get; protected set; }
        public Auction Auction { get; protected set; }
        public int Id { get; protected set; }

        public RoundEntity()
        {

        }

        public RoundEntity(Auction auction, IEnumerable<Provider> providers)
        {

        }

    }

}