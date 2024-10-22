using System;
using UnityEngine;

namespace Kusume
{
    public class Timer
    {
        public event Action OnEnd;
        public event Action OnOnceEnd;

        private float current = 0;

        private float time = 0;

        public float Current => current;

        private bool loop = false;
        public void SetLoop(bool l) {  loop = l; }

        public void Start(float _time)
        {
            current = _time;
            time = _time;
        }

        public void Update()
        {
            if(current <= 0) { return; }
            current -= Time.deltaTime;
            if(current <= 0)
            {
                if (loop)
                {
                    current += time;
                }
                End();
            }
        }

        public void End() 
        {
            OnEnd?.Invoke();
            OnOnceEnd?.Invoke();
            OnOnceEnd = null;
        }

        public bool IsEnd() {  return current <= 0; }

        public int GetMinutes()
        {
            return (int)current / 60;
        }

        public int GetSecond()
        {
            return (int)current % 60;
        }

    }
}
