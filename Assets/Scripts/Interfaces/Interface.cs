using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace JMT.Interfaces
{
    [RequireComponent(typeof(RectTransform)), DisallowMultipleComponent]
    public abstract class Interface : MonoBehaviour
    {
        private static readonly List<Interface> Interfaces = new List<Interface>();

        public bool State { get; private set; }

        public void Mark() => Interfaces.Add(this);

        public void Initialize()
        {
            OnInitialized();
            UpdateState();
        }

        protected virtual void OnInitialized() { }

        protected virtual void OnDestroyed() { }

        protected virtual void Enable() { }

        protected virtual void Disable() { }

        private void OnDestroy()
        {
            if (Interfaces.Contains(this))
                Interfaces.Remove(this);

            SetState(false);
            OnDestroyed();
        }

        public void SetState(bool state)
        {
            if (state == State)
                return;

            State = state;
            UpdateState();
        }

        private void UpdateState()
        {
            gameObject.SetActive(State);

            if (State)
                Enable();
            else
                Disable();
        }

        public static void Single<T>() where T : Interface
        {
            Interfaces.ForEach((i) => i.SetState(false));
            Interfaces.First((i) => i.GetType() == typeof(T)).SetState(true);
        }

        public static void Single<T>(T @interface) where T : Interface
        {
            Interfaces.ForEach((i) => i.SetState(false));
            Interfaces.First((i) => @interface == i).SetState(true);
        }

        public static void Additive<T>() where T : Interface => Interfaces.First((i) => i.GetType() == typeof(T)).SetState(true);

        public static void Additive<T>(T @interface) where T : Interface => Interfaces.First((i) => @interface == i).SetState(true);

        public static void Close<T>() where T : Interface => Interfaces.First((i) => i.GetType() == typeof(T)).SetState(false);

        public static void Close<T>(T @interface) where T : Interface => Interfaces.First((i) => @interface == i).SetState(false);

        public static T Get<T>() where T : Interface => Interfaces.OfType<T>().FirstOrDefault();
    }
}
