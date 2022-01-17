using System.ComponentModel.DataAnnotations.Schema;

namespace MyHordesOptimizerApi.Models
{
    [Table("TownBank")]
    public class TownBankModel
    {
        public int TownId { get; set; }
        public int BankId { get; set; }
        public int LastUpdateInfoId { get; set; }

        public TownModel Town { get; set; }
        public BankModel Bank { get; set; }
        public LastUpdateInfoModel LastUpdateInfo { get; set; }
    }
}