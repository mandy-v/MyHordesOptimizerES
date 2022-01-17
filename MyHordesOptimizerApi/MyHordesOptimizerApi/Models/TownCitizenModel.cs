using System.ComponentModel.DataAnnotations.Schema;

namespace MyHordesOptimizerApi.Models
{
    [Table("TownCitizen")]
    public class TownCitizenModel
    {
        public int TownId { get; set; }
        public int CitizenId { get; set;}
        public int LastUpdateInfoId { get; set; }

        public TownModel Town { get; set; }
        public CitizenModel Citizen { get; set; }
        public LastUpdateInfoModel LastUpdateInfo { get; set; }
        public string HomeMessage { get; set; }
        public string JobNanme { get; set; }
        public string JobUID { get; set; }
        public int PositionX { get; set; }
        public int PositionY { get; set; }
        public bool IsGhost { get; set; }
    }
}