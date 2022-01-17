using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyHordesOptimizerApi.Models
{
    [Table("Action")]
    public class ActionModel
    {
        [Key]
        public int IdAction { get; set; }
    }
}
