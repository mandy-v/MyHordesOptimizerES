using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyHordesOptimizerApi.Models
{
    [Table("Property")]
    public class PropertyModel
    {
        [Key]
        public int PropertyId { get; set; }
    }
}
