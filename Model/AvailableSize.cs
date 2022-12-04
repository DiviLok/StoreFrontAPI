using System.ComponentModel.DataAnnotations;

namespace StoreFrontAPI.Model
{
    public class AvailableSize
    {
        [Key]
        public int SizeID { get; set; }
        public string SizeName { get; set; }
        public string SizeDescription { get; set; }
        public List<ClothesAndSize> clothesAndSizes { get; set; }

    }
}
