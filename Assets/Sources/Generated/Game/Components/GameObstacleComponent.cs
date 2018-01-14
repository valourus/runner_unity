//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    static readonly Sources.Components.ObstacleComponent obstacleComponent = new Sources.Components.ObstacleComponent();

    public bool isObstacle {
        get { return HasComponent(GameComponentsLookup.Obstacle); }
        set {
            if (value != isObstacle) {
                var index = GameComponentsLookup.Obstacle;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : obstacleComponent;

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

    static Entitas.IMatcher<GameEntity> _matcherObstacle;

    public static Entitas.IMatcher<GameEntity> Obstacle {
        get {
            if (_matcherObstacle == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.Obstacle);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherObstacle = matcher;
            }

            return _matcherObstacle;
        }
    }
}
