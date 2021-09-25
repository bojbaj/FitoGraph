namespace FitoGraph.Api.Areas.Admin.Outputs
{
    public class GetSupplierOutput
    {
        public int Id { get; set; }
        public string FireBaseId { get; set; }
        public string Email { get; set; }
        public int Gender { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int RegionCountryId { get; set; }
        public int RegionStateId { get; set; }
        public int RegionCityId { get; set; }
        public string RestaurantName { get; set; }
        public string Address { get; set; }
        public string PostalCode { get; set; }
        public string Phone { get; set; }
        public string ShareAccount { get; set; }
        public decimal SharePercent { get; set; }
        public decimal Lat { get; set; }
        public decimal Lng { get; set; }
    }
}