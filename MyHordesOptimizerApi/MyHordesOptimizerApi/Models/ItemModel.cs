using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyHordesOptimizerApi.Models
{
    [Table("Item")]
    public class ItemModel
    {
        [Key]
        public int IdItem { get; set; } 
        public int IdCategory { get; set; }
        public int IdAction { get; set; }
        [ForeignKey("IdAction")]
        public ActionModel Action { get; set; }
        public ICollection<PropertyModel> Properties { get; set; }
        public int Deco { get; set; }
        public string Label_Fr { get; set; }
        public string Label_En { get; set; }
        public string Label_Es { get; set; }
        public string Label_De { get; set; }
        public string Description_Fr { get; set; }
        public string Description_En { get; set; }
        public string Description_Es { get; set; }
        public string Description_De { get; set; }
        public int Guard { get; set; } 
        public string Img { get; set; }
        public bool IsHeaver { get; set; }
        public string Name { get; set; }
    }
}
