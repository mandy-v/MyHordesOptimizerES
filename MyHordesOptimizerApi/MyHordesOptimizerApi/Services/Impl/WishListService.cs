using AutoMapper;
using Microsoft.Extensions.Logging;
using MyHordesOptimizerApi.Dtos.MyHordes.MyHordesOptimizer;
using MyHordesOptimizerApi.Dtos.MyHordesOptimizer;
using MyHordesOptimizerApi.Dtos.MyHordesOptimizer.WishList;
using MyHordesOptimizerApi.Extensions;
using MyHordesOptimizerApi.Models;
using MyHordesOptimizerApi.Providers.Interfaces;
using MyHordesOptimizerApi.Repository.Interfaces;
using MyHordesOptimizerApi.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace MyHordesOptimizerApi.Services.Impl
{
    public class WishListService : IWishListService
    {
        protected ILogger<MyHordesFetcherService> Logger { get; set; }

        protected IUserInfoProvider UserInfoProvider { get; set; }
        protected IMyHordesJsonApiRepository MyHordesJsonApiRepository { get; set; }
        protected IMyHordesOptimizerDatabaseRepository DatabaseRepository { get; set; }
        protected IMapper Mapper { get; set; }


        private int _townId; // On est dans de l'injection de dépendance Scoped, on peut se permettre de stocker des infos

        public WishListService(ILogger<MyHordesFetcherService> logger,
            IUserInfoProvider userInfoProvider,
            IMyHordesJsonApiRepository myHordesJsonApiRepository,
            IMyHordesOptimizerDatabaseRepository databaseRepository,
            IMapper mapper)
        {
            Logger = logger;
            UserInfoProvider = userInfoProvider;
            MyHordesJsonApiRepository = myHordesJsonApiRepository;
            DatabaseRepository = databaseRepository;
            Mapper = mapper;
        }

        public WishListWrapperDto GetWishList()
        {
            var myHordeMeResponse = MyHordesJsonApiRepository.GetMe();
            _townId = myHordeMeResponse.Map.Id;

            var town = Mapper.Map<TownDto>(DatabaseRepository.GetTown(myHordeMeResponse.Map.Id));
            var wishList = town.WishList;
            if (wishList == null)
            {
                return new WishListWrapperDto();
            }

            var recipes = Mapper.Map<List<ItemRecipeDto>>(DatabaseRepository.GetRecipes());
            foreach (var kvp in wishList.WishList)
            {
                var wishlistItem = kvp.Value;
                if (town.Bank.Bank.TryGetValue(wishlistItem.Item.XmlId.ToString(), out var bankItem))
                {
                    wishlistItem.BankCount = bankItem.Count;
                }
                else
                {
                    wishlistItem.BankCount = 0;
                }
                wishlistItem.IsWorkshop = recipes.Any(x => x.Type == ItemRecipeType.Workshop.GetDescription()
                                                             && (x.Components.Any(component => component.XmlId == wishlistItem.Item.XmlId) || x.Result.Any(result => result.Item.XmlId == wishlistItem.Item.XmlId)));
            }
            return wishList;
        }

        public WishListWrapperDto PutWishList(List<WishListPutResquestDto> wishListPutRequest)
        {
            var myHordeMeResponse = MyHordesJsonApiRepository.GetMe();
            var items = Mapper.Map<List<ItemDto>>(DatabaseRepository.GetItems());
            var wishListWrapper = new WishListWrapperDto()
            {
                LastUpdateInfo = UserInfoProvider.GenerateLastUpdateInfo()
            };
            foreach (var request in wishListPutRequest)
            {
                var itemId = request.Id;
                var wishLiteItem = new WishListItemDto()
                {
                    Item = items.First(x => x.XmlId == itemId),
                    Count = request.Count,
                    Priority = request.Priority
                };
                wishListWrapper.WishList[itemId.ToString()] = wishLiteItem;
            }
            DatabaseRepository.PutWishList(myHordeMeResponse.Map.Id, Mapper.Map<WishListModel>(wishListWrapper));
            return wishListWrapper;
        }

        public void AddItemToWishList(int itemId)
        {
            var item = Mapper.Map<ItemDto>(DatabaseRepository.GetItemsById(itemId));
            var wishList = GetWishList();
            wishList.LastUpdateInfo = UserInfoProvider.GenerateLastUpdateInfo();
            if (wishList.WishList.TryGetValue(item.XmlId.ToString(), out var @out)) // Si l'item est déjà dans la wishlist, on ne fait rien
            {
                return;
            }
            wishList.WishList[item.XmlId.ToString()] = new WishListItemDto()
            {
                Item = item,
                Priority = 0,
                Count = 1
            };
            DatabaseRepository.PutWishList(_townId, Mapper.Map<WishListModel>(wishList));
        }

    }
}
