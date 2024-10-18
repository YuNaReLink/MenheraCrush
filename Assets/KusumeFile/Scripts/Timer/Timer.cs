using System;
using UnityEngine;

namespace Kusume
{
    public class Timer
    {
        public event Action OnEnd;

        private float current = 0;

        public float Current => current;

        public void Start(float time)
        {
            current = time;
        }

        public void Update()
        {
            if(current <= 0) { return; }
            current -= Time.deltaTime;
            if(current <= 0)
            {
                current = 0;
                End();
            }
        }

        public void End() 
        {
            current = 0; 
            OnEnd?.Invoke();
            OnEnd = null;
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
