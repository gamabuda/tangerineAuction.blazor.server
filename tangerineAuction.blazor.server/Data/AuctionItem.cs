using System;
namespace tangerineAuction.blazor.server.Data
{
	public class AuctionItem
	{
        public string Id { get; set; }              
        public string Name { get; set; }
        public string Image { get; set; } = "https://upload.wikimedia.org/wikipedia/commons/thumb/f/f2/Citrus_reticulata.jpg/1200px-Citrus_reticulata.jpg";
        public string Description { get; set; }   
        public decimal StartingPrice { get; set; }
        public decimal CurrentPrice { get; set; }
        public DateTime EndTime { get; set; }              
        public UserAccount HighestBidder { get; set; }
    }
}

