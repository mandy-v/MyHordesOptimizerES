using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyHordesOptimizerApi.Models
{
    [Table("Bank")]
    public class BankModel
    {
        [Key]
        public int IdBank { get; set; }

        public ICollection<BankItemModel> Items { get; set; }
    }
}
