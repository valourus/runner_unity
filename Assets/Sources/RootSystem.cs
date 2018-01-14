using Entitas;
using Sources.Logic;
using UnityEngine;
using UnityEngine.Networking;

namespace Sources {
    public class RootSystem : MonoBehaviour {
        public static Config cfg { get; private set; }
        private Contexts context { get; set; }
        private Systems systems { get; set; }
        
        private void Awake() {
            Screen.orientation = ScreenOrientation.Portrait;
            cfg = GetComponent<Config>();
            context = Contexts.sharedInstance;
            systems = createSystems(context);
            systems.Initialize();
        }

        private void Update() {
            systems.Execute();    
        }
        
        private Systems createSystems(Contexts context) {
            return new Systems().Add(new Feature("GAME_FEATURES")                
                .Add(new TickSystem(context))
                .Add(new InitObstacleSystem(context))
                .Add(new InitPlayerSystem(context))
                .Add(new UpdateUILayerSystem(context))
                .Add(new MoveLeftSystem(context))
                .Add(new MoveRightSystem(context))
                .Add(new OnPlayerCollisionSystem(context))
                .Add(new OnObstacleCollisionSystem(context.input))
                .Add(new UpdateScoreSystem(context))
                .Add(new UpdateAnimation(context))
                .Add(new MoveForwardSystem(context))
                .Add(new CooldownSystem(context))
                .Add(new OnSwipeDown(context)));
        }
    }
}