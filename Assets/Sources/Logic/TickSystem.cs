using System.Runtime.CompilerServices;
using Entitas;

namespace Sources.Logic {
    public class TickSystem : IInitializeSystem, IExecuteSystem {
        private Contexts context { get; set; }
        private InputEntity tick;
        
        public TickSystem(Contexts context) {
            this.context = context;
        }
        
        public void Initialize() {
            context.input.SetTick(0);
        }

        public void Execute() {
            if(RootSystem.cfg.isPaused) return;
            
            context.input.ReplaceTick(++context.input.tick.value);
        }
    }
}