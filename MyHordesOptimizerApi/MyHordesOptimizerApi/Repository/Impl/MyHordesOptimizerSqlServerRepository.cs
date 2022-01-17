using Microsoft.Extensions.Logging;
using MyHordesOptimizerApi.Database;
using MyHordesOptimizerApi.Extensions;
using MyHordesOptimizerApi.Models;
using MyHordesOptimizerApi.Repository.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace MyHordesOptimizerApi.Repository.Impl
{
    public class MyHordesOptimizerSqlServerRepository : IMyHordesOptimizerDatabaseRepository
    {
        protected MyHordesOptimizerContext Context { get; private set; }
        protected ILogger<MyHordesOptimizerSqlServerRepository> Logger { get; private set; }

        public MyHordesOptimizerSqlServerRepository(MyHordesOptimizerContext context, ILogger<MyHordesOptimizerSqlServerRepository> logger)
        {
            Context = context;
            Logger = logger;
        }

        #region Town 

        public void PatchTown(TownModel town)
        {
            throw new System.NotImplementedException();
        }

        public TownModel GetTown(int townId)
        {
            throw new System.NotImplementedException();
        }

        #endregion

        #region HeroSkills

        public void PatchHeroSkill(IEnumerable<HeroSkillModel> heroSkills)
        {
            throw new System.NotImplementedException();
        }

        public Dictionary<string, HeroSkillModel> GetHeroSkills()
        {
            throw new System.NotImplementedException();
        }

        #endregion

        #region Items

        public void PatchItems(List<ItemModel> items)
        {
            throw new System.NotImplementedException();
        }

        public List<ItemModel> GetItems()
        {
            throw new System.NotImplementedException();
        }

        public ItemModel GetItemsById(int itemId)
        {
            throw new System.NotImplementedException();
        }

        #endregion

        #region Recipes

        public void PatchRecipes(List<RecipeModel> recipes)
        {
            throw new System.NotImplementedException();
        }

        public List<RecipeModel> GetRecipes()
        {
            throw new System.NotImplementedException();
        }

        #endregion

        #region Bank

        public void PutBank(int townId, BankModel bank)
        {
            throw new System.NotImplementedException();
        }

        #endregion

        #region Citizens

        public void PatchCitizen(int townId, List<CitizenModel> citizens)
        {
            throw new System.NotImplementedException();
        }

        public void PatchCitizen(CitizenModel citizen)
        {
            var updateCitizen = Context.Citizens.FirstOrDefault(x => x.Name == citizen.Name);
            if (updateCitizen != null)
            {
                updateCitizen.UpdateItem(citizen);
                Context.Citizens.Update(updateCitizen);
            }
            else
            {
                Context.Citizens.Add(citizen);
            }
            Context.SaveChanges();
        }

        #endregion

        #region WishList

        public void PutWishList(int townId, WishListModel wishList)
        {
            throw new System.NotImplementedException();
        }

        List<HeroSkillModel> IMyHordesOptimizerDatabaseRepository.GetHeroSkills()
        {
            throw new System.NotImplementedException();
        }

        #endregion
    }
}
