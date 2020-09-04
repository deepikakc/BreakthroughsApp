using Breakthroughs.Shared.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Breakthroughs.Shared.Models
{
    public class NinjaModel
    {
        [Key] public int Id { get; set; }
        [MaxLength(100)] public string Name { get; set; }
        [MaxLength(2000)] public string Skills { get; set; }
        [MaxLength(2000)] public string SkillsBT { get; set; }
        [Required] public EAttributes Attribute { get; set; }
        public string ImagePath { get; set; }
        [Required] public int Stars { get; set; }
    }
}
