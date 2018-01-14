using Entitas.CodeGeneration.Attributes;
using Sources.Components;
using UnityEngine;

namespace Sources.Logic {
	public static class LevelLogic {
		
		public static void addXP(int amount, ExperienceComponent component) {
			component.xp += amount;
			while(component.xp > getXPNeeded(component.level)) {
				component.xp -= getXPNeeded(component.level);
				component.level++;
			}
		}

		public static int getXPNeeded(int level) {
			int xpNeeded = 500;
			for(int i = 0; i < level; i++)
				xpNeeded *= 2;
			return xpNeeded;
		}

		public static float getXPPercentage(ExperienceComponent component) {
			int xpNeeded = 500;
			for(int i = 0;i < component.level;i++)
				xpNeeded *= 2;
			return (float) component.xp / xpNeeded * 100;
		}
	}
}
