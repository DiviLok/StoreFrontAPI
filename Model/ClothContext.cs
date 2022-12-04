using Microsoft.EntityFrameworkCore;

namespace StoreFrontAPI.Model
{
    public class ClothContext : DbContext
    {
        public DbSet<Clothes> clothes { get; set; }
        public DbSet<AvailableSize> availableSizes { get; set; }
        public DbSet<KidsClothes> kidsclothes { get; set; }
        public DbSet<ClothesAndSize> clothesAndSizes { get; set; }

        public ClothContext(DbContextOptions<ClothContext> options) : base(options) 
        { 

        } 

       /* protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost;Database=ShopClothesDB;Trusted_Connection=True;encrypt=False;");
        }*/
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ClothesAndSize>()
                .HasKey(k => new { k.SizeID, k.ClothId });

            modelBuilder.Entity<ClothesAndSize>()
                .HasOne(s => s.clothes)
                .WithMany(ss => ss.clothesAndSizes)
                .HasForeignKey(k => k.ClothId);

            modelBuilder.Entity<ClothesAndSize>()
                .HasOne(s => s.availabesizes)
                .WithMany(ss => ss.clothesAndSizes)
                .HasForeignKey(k => k.SizeID);
        }
    }
}
