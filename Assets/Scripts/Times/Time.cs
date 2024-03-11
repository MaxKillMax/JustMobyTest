using System;
using JMT.Extensions;

namespace JMT.Times
{
    public class Time
    {
        public static float Delta { get; private set; }
        public static event Action OnUpdate;

        public void Update()
        {
            Delta = UnityEngine.Time.deltaTime;
            OnUpdate?.SafeInvoke();
        }

        public void Stop()
        {
            Delta = 0;
        }
    }
}