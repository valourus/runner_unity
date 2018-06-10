using Entitas;
using Sources.Logic;
using Sources.UI;
using UnityEngine;

namespace Sources {
    public class RootSystem : MonoBehaviour {
        public static Config cfg { get; private set; }
        private Contexts context { get; set; }
        private Systems systems { get; set; }
        
        private void Start() {
            cfg = GetComponent<Config>();
            cfg.init();
            context = Contexts.sharedInstance;
            systems = createSystems(context);
            systems.Initialize();
        }

        private void Update() {
            systems.Execute(); 
            systems.Cleanup();
        }

        private void OnDestroy() {
            systems.TearDown();
        }
        
        private Systems createSystems(Contexts context) {
            return new Systems().Add(new Feature("GAME_FEATURES")                
                .Add(new TickSystem(context))
                .Add(new GenerateObstacleSystem(context))
                .Add(new InitPlayerSystem(context))
                .Add(new UpdateUILayerSystem(context))
                .Add(new MoveLeftSystem(context))
                .Add(new MoveRightSystem(context))
                .Add(new OnPlayerCollisionSystem(context))
                .Add(new UpdateScoreSystem(context))
                .Add(new SpeedSystem(context))
                .Add(new UpdateAnimation(context))
                .Add(new MoveForwardSystem(context))
                .Add(new SlowMotionCooldownSystem(context))
                .Add(new PlayerJumpSystem(context))
                .Add(new SlowMotionSystem(context))
                .Add(new JumpCoolDownSystem(context))
                .Add(new StartGameSystem(context))
                .Add(new RestartGameSystem(context))
                .Add(new OnObstacleCollisionSystem(context))
                .Add(new SaveProgressSystem(context.game))
                .Add(new DestroyObstacleSystem(context))
                .Add(new AdjustUILayerSystem(context)));
        }
    }
}