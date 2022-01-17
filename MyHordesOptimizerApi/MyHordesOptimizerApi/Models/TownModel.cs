using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyHordesOptimizerApi.Models
{
    [Table("Town")]
    public class TownModel
    {
        [Key]
        public int IdTown { get; set; }
        public ICollection<TownBankModel> Bank { get; set; }
        public ICollection<TownWishListModel> WishList { get; set; }
        public ICollection<TownCitizenModel> Citizens { get; set; }
    }
}
