using System;
using UnityEngine;

namespace JMT.Inputs
{
    public class Input
    {
        public static event Action OnEscapeClicked;
        public static event Action OnPointerDown;
        public static event Action OnPointerUp;

        public static bool IsPointerHolding { get; private set; }

        public void Update()
        {
            if (UnityEngine.Input.GetKeyDown(KeyCode.Escape))
                OnEscapeClicked?.Invoke();

            IsPointerHolding = UnityEngine.Input.GetMouseButton(0) || (UnityEngine.Input.touchCount > 0 && UnityEngine.Input.GetTouch(0).phase == TouchPhase.Moved);

            if (UnityEngine.Input.GetMouseButtonDown(0) || (UnityEngine.Input.touchCount > 0 && UnityEngine.Input.GetTouch(0).phase == TouchPhase.Began))
                OnPointerDown?.Invoke();

            if (UnityEngine.Input.GetMouseButtonUp(0) || (UnityEngine.Input.touchCount > 0 && UnityEngine.Input.GetTouch(0).phase == TouchPhase.Ended))
                OnPointerUp?.Invoke();
        }
    }
}