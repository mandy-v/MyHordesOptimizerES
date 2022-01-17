using Microsoft.EntityFrameworkCore;
using MyHordesOptimizerApi.Models;

namespace MyHordesOptimizerApi.Database
{
    public class MyHordesOptimizerContext : DbContext
    {
        public DbSet<ActionModel> Actions { get; set; }
        public DbSet<BankItemModel> BankItemModels { get; set; }
        public DbSet<BankModel> Banks { get; set; }
        public DbSet<CategoryModel> Categories { get; set; }
        public DbSet<CitizenModel> Citizens { get; set; }
        public DbSet<HeroSkillModel> HeroSkills { get; set; }
        public DbSet<ItemModel> Items { get; set; }
        public DbSet<LastUpdateInfoModel> LastUpdateInfos { get; set; }
        public DbSet<PropertyModel> Properties { get; set; }
        public DbSet<RecipeModel> Recipes { get; set; }
        public DbSet<TownBankModel> TownBanks { get; set; }
        public DbSet<TownCitizenModel> TownCitizenModels { get; set; }
        public DbSet<TownModel> Towns { get; set; }
        public DbSet<TownWishListModel> TownWishLists { get; set; }
        public DbSet<WishListItemModel> WishListItems { get; set; }
        public DbSet<WishListModel> WishLists { get; set; }

        public MyHordesOptimizerContext(DbContextOptions<MyHordesOptimizerContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ActionModel>().ToTable("Action");

            modelBuilder.Entity<BankItemModel>().ToTable("BankItem").HasKey(bankItemModel => new { bankItemModel.IdBank, bankItemModel.IdItem });
            modelBuilder.Entity<BankItemModel>()
                .HasOne(bankItemModel => bankItemModel.Bank)
                .WithMany(bank => bank.Items)
                .HasForeignKey(bankItemModel => bankItemModel.IdBank);
            modelBuilder.Entity<BankItemModel>()
                .HasOne(bankItemModel => bankItemModel.Item);

            modelBuilder.Entity<BankModel>().ToTable("Bank");

            modelBuilder.Entity<CategoryModel>().ToTable("Category");

            modelBuilder.Entity<CitizenModel>().ToTable("Citizen");

            modelBuilder.Entity<HeroSkillModel>().ToTable("HeroSkills");

            modelBuilder.Entity<ItemModel>().ToTable("Item");

            modelBuilder.Entity<LastUpdateInfoModel>().ToTable("LastUpdateInfo");

            modelBuilder.Entity<PropertyModel>().ToTable("Property");

            modelBuilder.Entity<RecipeModel>().ToTable("Recipe");

            modelBuilder.Entity<TownBankModel>().ToTable("TownBank").HasKey(townBankModel => new { townBankModel.TownId, townBankModel.BankId, townBankModel.LastUpdateInfoId });
            modelBuilder.Entity<TownBankModel>()
                .HasOne(townBankModel => townBankModel.Bank);
            modelBuilder.Entity<TownBankModel>()
                .HasOne(townBankModel => townBankModel.Town)
                .WithMany(townModel => townModel.Bank)
                .HasForeignKey(townBankModel => townBankModel.TownId);
            modelBuilder.Entity<TownBankModel>()
                .HasOne(townBankModel => townBankModel.LastUpdateInfo);


            modelBuilder.Entity<TownCitizenModel>().ToTable("TownCitizen").HasKey(townCitizen => new { townCitizen.CitizenId, townCitizen.TownId });
            modelBuilder.Entity<TownCitizenModel>()
                .HasOne(townCitizenModel => townCitizenModel.Town)
                .WithMany(town => town.Citizens)
                .HasForeignKey(townCitizenModel => townCitizenModel.TownId);
            modelBuilder.Entity<TownCitizenModel>()
                .HasOne(townCitizenModel => townCitizenModel.Citizen)
                .WithMany(citizenModel => citizenModel.Towns)
                .HasForeignKey(townCitizenModel => townCitizenModel.TownId);

            modelBuilder.Entity<TownModel>().ToTable("Town");

            modelBuilder.Entity<TownWishListModel>().ToTable("TownWishList").HasKey(townWishListModel => new { townWishListModel.LastUpdateInfoId, townWishListModel.TownId, townWishListModel.WishListId });
            modelBuilder.Entity<TownWishListModel>()
                .HasOne(townWishListModel => townWishListModel.WishList);
            modelBuilder.Entity<TownWishListModel>()
                .HasOne(townWishListModel => townWishListModel.LastUpdateInfo);
            modelBuilder.Entity<TownWishListModel>()
                .HasOne(townWishListModel => townWishListModel.Town)
                .WithMany(townModel => townModel.WishList)
                .HasForeignKey(townWishListModel => townWishListModel.TownId);

            modelBuilder.Entity<WishListItemModel>().ToTable("WishListItem").HasKey(wishListItemModel => new { wishListItemModel.ItemId, wishListItemModel.WishListId });
            modelBuilder.Entity<WishListItemModel>()
                .HasOne(wishListItemModel => wishListItemModel.Item);
            modelBuilder.Entity<WishListItemModel>()
                .HasOne(wishListItemModel => wishListItemModel.WishList);

            modelBuilder.Entity<WishListModel>().ToTable("WishList");
        }
    }
}
