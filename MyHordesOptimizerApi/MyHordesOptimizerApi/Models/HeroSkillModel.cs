using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyHordesOptimizerApi.Models
{
    [Table("HeroSkills")]
    public class HeroSkillModel
    {
        [Key]
        public int IdHeroSkill { get; set; }
        public string Name { get; set; }
        public int DaysNeeded { get; set; }
        public string Label_Fr { get; set; }
        public string Label_En { get; set; }
        public string Label_Es { get; set; }
        public string Label_De { get; set; }
        public string Description_Fr { get; set; }
        public string Description_En { get; set; }
        public string Description_Es { get; set; }
        public string Description_De { get; set; }
        public string Icon { get; set; }
        public int NbUses { get; set; }
    }
}
