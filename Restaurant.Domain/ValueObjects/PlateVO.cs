namespace Restaurant.Domain.ValueObjects
{
    public class PlateVO
    {
        public int PlateId { get; set; }
        public string PlateName { get; set; }
        public decimal Price { get; set; }
        public int RestaurantId { get; set; }
        public string RestaurantName { get; set; }
    }
}
