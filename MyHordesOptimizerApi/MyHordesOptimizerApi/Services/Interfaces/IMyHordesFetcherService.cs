using MyHordesOptimizerApi.Dtos.MyHordes.MyHordesOptimizer;
using MyHordesOptimizerApi.Dtos.MyHordesOptimizer;
using System.Collections.Generic;

namespace MyHordesOptimizerApi.Services.Interfaces
{
    public interface IMyHordesFetcherService
    {
        IEnumerable<ItemDto> GetItems();
        TownDto GetTown();
        SimpleMeDto GetSimpleMe();
        IEnumerable<HeroSkillDto> GetHeroSkills();
        IEnumerable<ItemRecipeDto> GetRecipes();
        BankWrapperDto GetBank();
        CitizensWrapperDto GetCitizens();
    }
}
