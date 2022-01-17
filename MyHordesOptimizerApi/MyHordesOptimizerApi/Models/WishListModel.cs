using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyHordesOptimizerApi.Models
{
    [Table("WishList")]
    public class WishListModel
    {
        [Key]
        public int WishListId { get; set; }
        public ICollection<WishListItemModel> Items { get; set; }
    }
}
