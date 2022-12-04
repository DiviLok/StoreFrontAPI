namespace StoreFrontAPI.Model
{
    public class ClothesAndSize
    {
        public int ClothId { get; set; }
        public int SizeID { get; set; }
        public Clothes clothes { get; set; }
        public AvailableSize availabesizes { get; set; }
    }
}
