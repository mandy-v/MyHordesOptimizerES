using MyHordesOptimizerApi.Dtos.MyHordesOptimizer;
using MyHordesOptimizerApi.Dtos.MyHordesOptimizer.WishList;
using System.Collections.Generic;

namespace MyHordesOptimizerApi.Services.Interfaces
{
    public interface IWishListService
    {
        WishListWrapperDto GetWishList();
        WishListWrapperDto PutWishList(List<WishListPutResquestDto> wishList);
        void AddItemToWishList(int itemId);
    }
}
