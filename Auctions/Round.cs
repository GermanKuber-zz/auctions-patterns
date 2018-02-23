using System.Collections.Generic;

namespace ConsoleApp2
{
    public class Round
    {
        public List<Provider> Providers { get; }
        public int Id { get; set; }

        public Round()
        {
            
        }

        public Round(Auction auction, IEnumerable<Provider> providers)
        {
           
        }
    } 
    
    
}