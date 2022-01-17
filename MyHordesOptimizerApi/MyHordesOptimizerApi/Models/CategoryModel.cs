using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyHordesOptimizerApi.Models
{
    [Table("Category")]
    public class CategoryModel
    {
        [Key]
        public int IdCategory { get; set; }
        public string Label_Fr { get; set; }
        public string Label_En { get; set; }
        public string Label_Es { get; set; }
        public string Label_De { get; set; }
    }
}
