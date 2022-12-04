using System.ComponentModel.DataAnnotations;

namespace StoreFrontAPI.Model
{
    public class Clothes
    {
        [Key]
        public int ClothId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
       // public string AvailableSize { get; set; }
        public string Material { get; set; }
        public string Type { get; set; }//image of the cloth
        public int price { get; set; }
        public List<KidsClothes> kidsClothes { get; set; }
        public List<ClothesAndSize> clothesAndSizes { get; set; }
       // public int KidClothID { get; set; }
    }

   
}

