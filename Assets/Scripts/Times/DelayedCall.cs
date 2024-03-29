﻿using System;
using System.Collections.Generic;
using System.Linq;
using JMT.Extensions;

namespace JMT.Times
{
    public class DelayedCall
    {
        private static List<DelayedCall> Calls = new List<DelayedCall>();

        private float _currentDelay;
        private readonly float _delay;
        private readonly Action _call;

        public bool Repeat { get; set; } = false;

        private DelayedCall(Action call, float delay)
        {
            _currentDelay = delay;
            _delay = delay;
            _call = call;

            Start();
        }

        public static DelayedCall Start(Action call, float delay) => new DelayedCall(call, delay);

        public static void Continue(DelayedCall call) => call.Start();

        public static void Stop(DelayedCall call) => Calls.FirstOrDefault((c) => c == call)?.Stop();

        private void Start()
        {
            Calls.Add(this);
            Time.OnUpdate += DecreaseDelay;
        }

        private void Stop()
        {
            Calls.Remove(this);
            Time.OnUpdate -= DecreaseDelay;
        }

        public void DecreaseDelay()
        {
            _currentDelay -= Time.Delta;

            if (_currentDelay <= 0)
            {
                _call?.SafeInvoke();

                if (Repeat)
                    _currentDelay += _delay;
                else
                    Stop();
            }
        }
    }
}