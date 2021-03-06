//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentContextGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameContext {

    public GameEntity jumpingEntity { get { return GetGroup(GameMatcher.Jumping).GetSingleEntity(); } }

    public bool isJumping {
        get { return jumpingEntity != null; }
        set {
            var entity = jumpingEntity;
            if (value != (entity != null)) {
                if (value) {
                    CreateEntity().isJumping = true;
                } else {
                    entity.Destroy();
                }
            }
        }
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

    static readonly Sources.Components.JumpingComponent jumpingComponent = new Sources.Components.JumpingComponent();

    public bool isJumping {
        get { return HasComponent(GameComponentsLookup.Jumping); }
        set {
            if (value != isJumping) {
                var index = GameComponentsLookup.Jumping;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : jumpingComponent;

                    AddComponent(index, component);
                } else {
                    RemoveComponent(index);
                }
            }
        }
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

    static Entitas.IMatcher<GameEntity> _matcherJumping;

    public static Entitas.IMatcher<GameEntity> Jumping {
        get {
            if (_matcherJumping == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.Jumping);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherJumping = matcher;
            }

            return _matcherJumping;
        }
    }
}
