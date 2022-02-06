using System;

namespace Mryildirim.Core
{
    public static class EventManager
    {
        public static Action OnRocketmanLaunched;
        public static Action OnRocketmanJumped;

        public static void TriggerRocketmanLaunched()
        {
            OnRocketmanLaunched?.Invoke();
        }

        public static void TriggerRocketmanJumped()
        {
            OnRocketmanJumped?.Invoke();
        }
    }
}

