using System.ComponentModel.DataAnnotations.Schema;

namespace MyHordesOptimizerApi.Models
{
    [Table("TownWishList")]
    public class TownWishListModel
    {
        public int TownId { get; set; }
        public int WishListId { get; set; }
        public int LastUpdateInfoId { get; set; }

        public TownModel Town { get; set; }
        public WishListItemModel WishList { get; set; }
        public LastUpdateInfoModel LastUpdateInfo { get; set; }
    }
}