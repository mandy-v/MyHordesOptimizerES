using System.ComponentModel.DataAnnotations.Schema;

namespace MyHordesOptimizerApi.Models
{
    [Table("WishListItem")]
    public class WishListItemModel
    {
        public int WishListId { get; set; }
        public int ItemId { get; set; }

        public WishListModel WishList { get; set; }
        public ItemModel Item { get; set; }
        public int Count { get; set; }
        public int Priority { get; set; }
    }
}