using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyHordesOptimizerApi.Models
{
    [Table("LastUpdateInfo")]
    public class LastUpdateInfoModel
    {
        [Key]
        public int IdLastUpdateInfo { get; set; }
        public DateTime DateUpdate { get; set; }
        public CitizenModel Citizen { get; set; }
    }
}
