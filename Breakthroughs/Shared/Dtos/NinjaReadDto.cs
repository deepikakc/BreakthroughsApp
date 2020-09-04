using Breakthroughs.Shared.Utility;
using System;
using System.Collections.Generic;
using System.Text;

namespace Breakthroughs.Shared.Dtos
{
    public class NinjaReadDto
    {
        public string Name { get; set; }
        public string Skills { get; set; }
        public string SkillsBT { get; set; }
        public EAttributes Attribute { get; set; }
        public string ImagePath { get; set; }
        public int Stars { get; set; }
        public bool IsSelected { get; set; } = false;
    }
}
