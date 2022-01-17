using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyHordesOptimizerApi.Models
{
    [Table("Citizen")]
    public class CitizenModel
    {
        [Key]
        public int IdCitizen { get; set; }
        public string Name { get; set; }
        public string UserKey { get; set; }
        public int UserId { get; set; }

        public ICollection<TownCitizenModel> Towns { get; set; }
    }
}
