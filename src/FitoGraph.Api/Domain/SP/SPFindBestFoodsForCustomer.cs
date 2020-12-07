namespace FitoGraph.Api.Domain.SP
{
    public class SPFindBestFoodsForCustomer
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public string Tags { get; set; }
        public decimal Price { get; set; }
        public int MatchRate { get; set; }        
        public string Restaurant { get; set; }        
    }
}