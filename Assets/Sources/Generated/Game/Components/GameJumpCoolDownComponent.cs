//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public Sources.Components.JumpCoolDownComponent jumpCoolDown { get { return (Sources.Components.JumpCoolDownComponent)GetComponent(GameComponentsLookup.JumpCoolDown); } }
    public bool hasJumpCoolDown { get { return HasComponent(GameComponentsLookup.JumpCoolDown); } }

    public void AddJumpCoolDown(int newCooldown, float newUsedAt) {
        var index = GameComponentsLookup.JumpCoolDown;
        var component = CreateComponent<Sources.Components.JumpCoolDownComponent>(index);
        component.cooldown = newCooldown;
        component.usedAt = newUsedAt;
        AddComponent(index, component);
    }

    public void ReplaceJumpCoolDown(int newCooldown, float newUsedAt) {
        var index = GameComponentsLookup.JumpCoolDown;
        var component = CreateComponent<Sources.Components.JumpCoolDownComponent>(index);
        component.cooldown = newCooldown;
        component.usedAt = newUsedAt;
        ReplaceComponent(index, component);
    }

    public void RemoveJumpCoolDown() {
        RemoveComponent(GameComponentsLookup.JumpCoolDown);
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

    static Entitas.IMatcher<GameEntity> _matcherJumpCoolDown;

    public static Entitas.IMatcher<GameEntity> JumpCoolDown {
        get {
            if (_matcherJumpCoolDown == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.JumpCoolDown);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherJumpCoolDown = matcher;
            }

            return _matcherJumpCoolDown;
        }
    }
}