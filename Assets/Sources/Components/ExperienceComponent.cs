﻿using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace Sources.Components {
   [Game]
   [Unique]
    public class ExperienceComponent : IComponent {
        public int level;
        public int xp;
    }
}