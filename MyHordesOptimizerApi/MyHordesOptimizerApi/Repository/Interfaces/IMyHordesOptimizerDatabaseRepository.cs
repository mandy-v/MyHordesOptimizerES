using MyHordesOptimizerApi.Models;
using System.Collections.Generic;

namespace MyHordesOptimizerApi.Repository.Interfaces
{
    public interface IMyHordesOptimizerDatabaseRepository
    {
        void PatchTown(TownModel town);
        TownModel GetTown(int townId);

        void PatchHeroSkill(IEnumerable<HeroSkillModel> heroSkills);
        List<HeroSkillModel> GetHeroSkills();

        void PatchItems(List<ItemModel> items);
        List<ItemModel> GetItems();
        ItemModel GetItemsById(int itemId);

        void PatchRecipes(List<RecipeModel> recipes);
        List<RecipeModel> GetRecipes();

        void PutBank(int townId, BankModel bank);

        void PatchCitizen(int townId, List<CitizenModel> citizens);
        void PatchCitizen(CitizenModel citizen);

        void PutWishList(int townId, WishListModel wishList);
    }
}
