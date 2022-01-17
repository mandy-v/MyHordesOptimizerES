using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyHordesOptimizerApi.Models
{
    [Table("Recipe")]
    public class RecipeModel
    {
        [Key]
        public int IdRecipe { get; set; }
        public ICollection<ItemModel> Components { get; set; }
        public ICollection<ItemModel> Results { get; set; }
        public bool IsShamanOnly { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
    }
}
