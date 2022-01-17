using System.Collections.Generic;

namespace MyHordesOptimizerApi.Dtos.MyHordesOptimizer
{
    public class WishListWrapperDto
    {
        public Dictionary<string, WishListItemDto> WishList { get; set; }
        public LastUpdateInfoDto LastUpdateInfo { get; set; }

        public WishListWrapperDto()
        {
            WishList = new Dictionary<string, WishListItemDto>();
        }
    }
}
