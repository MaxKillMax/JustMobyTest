﻿using UnityEngine;

namespace JMT.Interfaces
{
    public class InterfaceInitializer : MonoBehaviour
    {
        [SerializeField] private Interface[] _interfaces;

        private void Awake()
        {
            for (int i = 0; i < _interfaces.Length; i++)
                _interfaces[i].Mark();

            for (int i = 0; i < _interfaces.Length; i++)
                _interfaces[i].Initialize();
        }
    }
}
