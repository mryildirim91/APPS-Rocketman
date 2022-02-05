
using Mryildirim.Core;
using UnityEngine;

namespace Mryildirim.StateMachine
{
    public class LaunchState : StateMachineBehaviour
    {
        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            EventManager.TriggerRocketmanLaunched();
        }
    }
}


