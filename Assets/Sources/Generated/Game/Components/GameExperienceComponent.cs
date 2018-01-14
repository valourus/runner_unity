//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentContextGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameContext {

    public GameEntity experienceEntity { get { return GetGroup(GameMatcher.Experience).GetSingleEntity(); } }
    public Sources.Components.ExperienceComponent experience { get { return experienceEntity.experience; } }
    public bool hasExperience { get { return experienceEntity != null; } }

    public GameEntity SetExperience(int newLevel, int newXp) {
        if (hasExperience) {
            throw new Entitas.EntitasException("Could not set Experience!\n" + this + " already has an entity with Sources.Components.ExperienceComponent!",
                "You should check if the context already has a experienceEntity before setting it or use context.ReplaceExperience().");
        }
        var entity = CreateEntity();
        entity.AddExperience(newLevel, newXp);
        return entity;
    }

    public void ReplaceExperience(int newLevel, int newXp) {
        var entity = experienceEntity;
        if (entity == null) {
            entity = SetExperience(newLevel, newXp);
        } else {
            entity.ReplaceExperience(newLevel, newXp);
        }
    }

    public void RemoveExperience() {
        experienceEntity.Destroy();
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public Sources.Components.ExperienceComponent experience { get { return (Sources.Components.ExperienceComponent)GetComponent(GameComponentsLookup.Experience); } }
    public bool hasExperience { get { return HasComponent(GameComponentsLookup.Experience); } }

    public void AddExperience(int newLevel, int newXp) {
        var index = GameComponentsLookup.Experience;
        var component = CreateComponent<Sources.Components.ExperienceComponent>(index);
        component.level = newLevel;
        component.xp = newXp;
        AddComponent(index, component);
    }

    public void ReplaceExperience(int newLevel, int newXp) {
        var index = GameComponentsLookup.Experience;
        var component = CreateComponent<Sources.Components.ExperienceComponent>(index);
        component.level = newLevel;
        component.xp = newXp;
        ReplaceComponent(index, component);
    }

    public void RemoveExperience() {
        RemoveComponent(GameComponentsLookup.Experience);
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherExperience;

    public static Entitas.IMatcher<GameEntity> Experience {
        get {
            if (_matcherExperience == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.Experience);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherExperience = matcher;
            }

            return _matcherExperience;
        }
    }
}