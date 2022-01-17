using AutoMapper;
using Microsoft.Extensions.Logging;
using MyHordesOptimizerApi.Dtos.MyHordes.MyHordesOptimizer;
using MyHordesOptimizerApi.Dtos.MyHordesOptimizer;
using MyHordesOptimizerApi.Models;
using MyHordesOptimizerApi.Providers.Interfaces;
using MyHordesOptimizerApi.Repository.Interfaces;
using MyHordesOptimizerApi.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace MyHordesOptimizerApi.Services.Impl
{
    public class MyHordesFetcherService : IMyHordesFetcherService
    {
        protected ILogger<MyHordesFetcherService> Logger { get; set; }
        protected IMyHordesJsonApiRepository MyHordesJsonApiRepository { get; set; }
        protected IMyHordesXmlApiRepository MyHordesXmlApiRepository { get; set; }
        protected IMyHordesOptimizerDatabaseRepository DatabaseRepository { get; set; }
        protected readonly IMapper Mapper;
        protected IUserInfoProvider UserInfoProvider { get; set; }


        public MyHordesFetcherService(ILogger<MyHordesFetcherService> logger,
            IMyHordesJsonApiRepository myHordesJsonApiRepository,
            IMyHordesXmlApiRepository myHordesXmlApiRepository,
            IMyHordesOptimizerDatabaseRepository firebaseRepository,
            IMapper mapper,
            IUserInfoProvider userInfoProvider)
        {
            Logger = logger;
            MyHordesJsonApiRepository = myHordesJsonApiRepository;
            MyHordesXmlApiRepository = myHordesXmlApiRepository;
            DatabaseRepository = firebaseRepository;
            Mapper = mapper;
            UserInfoProvider = userInfoProvider;
        }

        public IEnumerable<ItemDto> GetItems()
        {
            var items = Mapper.Map<List<ItemDto>>(DatabaseRepository.GetItems());
            var recipes = Mapper.Map<Dictionary<string, ItemRecipeDto>>(DatabaseRepository.GetRecipes());

            foreach (var item in items)
            {
                var recipesToAdd = recipes.Values.Where(recipe => recipe.Components.Any(component => component.XmlId == item.XmlId)).ToList();
                recipesToAdd.AddRange(recipes.Values.Where(recipes => recipes.Result.Any(result => result.Item.XmlId == item.XmlId)));
                item.Recipes = recipesToAdd;
            }

            var me = MyHordesJsonApiRepository.GetMe();
            if (me.Map != null) // On ne récupère les info propres à la ville uniquement si on est incarné
            {
                var town = Mapper.Map<TownDto>(DatabaseRepository.GetTown(me.Map.Id));

                foreach (var item in items)
                {
                    if (town.WishList != null && town.WishList.WishList != null)
                    {
                        if (town.WishList.WishList.TryGetValue(item.XmlId.ToString(), out var wishListItem))
                        {
                            item.WishListCount = wishListItem.Count;
                        }
                        else
                        {
                            item.WishListCount = 0;
                        }
                    }

                    if (town.Bank.Bank.TryGetValue(item.XmlId.ToString(), out var bankItem))
                    {
                        item.BankCount = bankItem.Count;
                    }
                    else
                    {
                        item.BankCount = 0;
                    }
                }
            }
            return items;
        }

        public TownDto GetTown()
        {
            var myHordeMeResponse = MyHordesJsonApiRepository.GetMe();
            myHordeMeResponse.Map.LastUpdateInfo = UserInfoProvider.GenerateLastUpdateInfo();
            var townDto = Mapper.Map<TownDto>(myHordeMeResponse.Map);

            // Enregistrer en base
            var townModel = Mapper.Map<TownModel>(townDto);
            DatabaseRepository.PatchTown(townModel);
            townDto = Mapper.Map<TownDto>(DatabaseRepository.GetTown(townDto.Id));

            return townDto;
        }

        public SimpleMeDto GetSimpleMe()
        {
            var me = MyHordesJsonApiRepository.GetMe();
            var simpleMe = Mapper.Map<SimpleMeDto>(me);

            var citizen = new CitizenModel()
            {
                Name = me.Name,
                UserId = me.Id,
                UserKey = UserInfoProvider.UserKey
            };
            DatabaseRepository.PatchCitizen(citizen);

            return simpleMe;
        }

        public IEnumerable<HeroSkillDto> GetHeroSkills()
        {
            var heroSkills = Mapper.Map<List<HeroSkillDto>>(DatabaseRepository.GetHeroSkills());
            return heroSkills;
        }

        public IEnumerable<ItemRecipeDto> GetRecipes()
        {
            var recipes = Mapper.Map<List<ItemRecipeDto>>(DatabaseRepository.GetRecipes());
            return recipes;
        }

        public BankWrapperDto GetBank()
        {
            var myHordeMeResponse = MyHordesJsonApiRepository.GetMe();
            var town = Mapper.Map<TownDto>(myHordeMeResponse.Map);

            // Enregistrer en base
            var bankModel = Mapper.Map<BankModel>(town.Bank);
            DatabaseRepository.PutBank(town.Id, bankModel);
            town = Mapper.Map<TownDto>(DatabaseRepository.GetTown(town.Id));
            var bankWrapper = town.Bank;

            if (town.WishList != null && town.WishList.WishList != null)
            {
                foreach (var kvp in bankWrapper.Bank)
                {
                    var bankItem = kvp.Value;
                    if (town.WishList.WishList.TryGetValue(bankItem.Item.XmlId.ToString(), out var wishListItem))
                    {
                        bankItem.WishListCount = wishListItem.Count;
                    }
                    else
                    {
                        bankItem.WishListCount = 0;
                    }
                }
            }
            return bankWrapper;
        }

        public CitizensWrapperDto GetCitizens()
        {
            var myHordeMeResponse = MyHordesJsonApiRepository.GetMe();
            var town = Mapper.Map<TownDto>(myHordeMeResponse.Map);

            // Enregistrer en base
            DatabaseRepository.PatchCitizen(town.Id, Mapper.Map<List<CitizenModel>>(town.Citizens));
            town = Mapper.Map<TownDto>(DatabaseRepository.GetTown(town.Id));
            var citizens = town.Citizens;

            return citizens;
        }
    }
}
