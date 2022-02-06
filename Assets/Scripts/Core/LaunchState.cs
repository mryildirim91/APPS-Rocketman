
using Mryildirim.Core;
using UnityEngine;

namespace Mryildirim.StateMachine
{
    public class LaunchState : StateMachineBehaviour
    {
        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            EventManager.TriggerRocketmanLaunched();
        }
    }
}


