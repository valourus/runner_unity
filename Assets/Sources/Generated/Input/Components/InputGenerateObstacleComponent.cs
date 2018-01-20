//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class InputEntity {

    public Sources.Components.GenerateObstacleComponent generateObstacle { get { return (Sources.Components.GenerateObstacleComponent)GetComponent(InputComponentsLookup.GenerateObstacle); } }
    public bool hasGenerateObstacle { get { return HasComponent(InputComponentsLookup.GenerateObstacle); } }

    public void AddGenerateObstacle(Sources.Utils.GeneratePlace newPlace) {
        var index = InputComponentsLookup.GenerateObstacle;
        var component = CreateComponent<Sources.Components.GenerateObstacleComponent>(index);
        component.place = newPlace;
        AddComponent(index, component);
    }

    public void ReplaceGenerateObstacle(Sources.Utils.GeneratePlace newPlace) {
        var index = InputComponentsLookup.GenerateObstacle;
        var component = CreateComponent<Sources.Components.GenerateObstacleComponent>(index);
        component.place = newPlace;
        ReplaceComponent(index, component);
    }

    public void RemoveGenerateObstacle() {
        RemoveComponent(InputComponentsLookup.GenerateObstacle);
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
public sealed partial class InputMatcher {

    static Entitas.IMatcher<InputEntity> _matcherGenerateObstacle;

    public static Entitas.IMatcher<InputEntity> GenerateObstacle {
        get {
            if (_matcherGenerateObstacle == null) {
                var matcher = (Entitas.Matcher<InputEntity>)Entitas.Matcher<InputEntity>.AllOf(InputComponentsLookup.GenerateObstacle);
                matcher.componentNames = InputComponentsLookup.componentNames;
                _matcherGenerateObstacle = matcher;
            }

            return _matcherGenerateObstacle;
        }
    }
}
