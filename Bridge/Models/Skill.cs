using System.ComponentModel.DataAnnotations;

namespace Bridge.Models
{
    public class Skill
    {
        [Key]
        public int SkillId { get; set; }
        public string Name { get; set; }
    }
}