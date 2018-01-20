using Entitas;
using UnityEngine;

namespace Sources.Logic {
    public class MoveBackSystem : IExecuteSystem {
        private GameContext game { get; set; }
        private IGroup<GameEntity> obstacles { get; set; }
        
        public MoveBackSystem(Contexts context) {
            game = context.game;
            obstacles = game.GetGroup(GameMatcher.Obstacle);
        }
        
        public void Execute() {
            foreach(var obstacle in obstacles) 
                if(obstacle.view.value != null)
                    obstacle.view.value.transform.Translate(Vector3.back * Time.deltaTime * game.speed.value * 10);       
        }
    }
}