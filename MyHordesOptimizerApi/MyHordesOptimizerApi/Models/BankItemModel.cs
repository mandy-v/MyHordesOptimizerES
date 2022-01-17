using System.ComponentModel.DataAnnotations.Schema;

namespace MyHordesOptimizerApi.Models
{
    [Table("BankItem")]
    public class BankItemModel
    {
        public int IdBank { get; set; }
        public int IdItem { get; set; }

        [ForeignKey("IdBank")]
        public BankModel Bank { get; set; }
        [ForeignKey("IdItem")]
        public ItemModel Item { get; set; }
        public int Count { get; set; }
    }
}