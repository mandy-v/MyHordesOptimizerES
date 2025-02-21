﻿using MyHordesOptimizerApi.Dtos.MyHordes.MyHordesOptimizer;
using MyHordesOptimizerApi.Dtos.MyHordesOptimizer;
using System.Collections.Generic;

namespace MyHordesOptimizerApi.Repository.Interfaces
{
    public interface IMyHordesOptimizerFirebaseRepository
    {
        void PatchTown(Town town);
        Town GetTown(int townId);

        void PatchHeroSkill(IEnumerable<HeroSkill> heroSkills);
        Dictionary<string, HeroSkill> GetHeroSkills();

        void PatchItems(List<Item> items);
        List<Item> GetItems();
        Item GetItemsById(int itemId);

        void PatchRecipes(List<ItemRecipe> recipes);
        Dictionary<string, ItemRecipe> GetRecipes();

        void PutBank(int townId, BankWrapper bank);

        void PatchCitizen(int townId, CitizensWrapper citizens);

        void PutWishList(int townId, WishListWrapper wishList);
        void PatchRuins(List<MyHordesOptimizerRuin> jsonRuins);
        Dictionary<string, MyHordesOptimizerRuin> GetRuins();
    }
}
