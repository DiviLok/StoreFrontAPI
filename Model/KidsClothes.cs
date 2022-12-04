using System.ComponentModel.DataAnnotations;

namespace StoreFrontAPI.Model
{
    public class KidsClothes
    {
        [Key]
        public int KidClothID { get; set; }
        public string KidClothName { get; set; }
        public string KidClothType { get; set; }
        public int ClothId { get; set; }
        public Clothes clothes { get; set; }
    }
}
