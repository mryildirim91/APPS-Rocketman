using System;

namespace Mryildirim.Core
{
    public static class EventManager
    {
        public static Action OnRocketmanLaunched;

        public static void TriggerRocketmanLaunched()
        {
            OnRocketmanLaunched?.Invoke();
        }
    }
}

