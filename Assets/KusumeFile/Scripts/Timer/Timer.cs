using System;
using UnityEngine;

namespace Kusume
{
    public class Timer
    {
        public event Action OnCompleted;

        private float currentCount = 0;

        public float CurrentTime => currentCount;

        public void Start(float time)
        {
            currentCount = time;
        }

        public void DoRefresh()
        {
            if(currentCount <= 0) { return; }
            currentCount -= Time.deltaTime;
            if(currentCount <= 0)
            {
                currentCount = 0;
            }
        }

        public void End() 
        {
            currentCount = 0; 
            OnCompleted?.Invoke();
            OnCompleted = null;
        }
        public bool IsRefresh() { return currentCount > 0; }

        public bool IsEnd() {  return currentCount <= 0; }

        public int GetMinutes()
        {
            int m = 0;
            m = Mathf.FloorToInt(currentCount / 60);
            return m;
        }

        public int GetSecond()
        {
            int s = 0;
            s = Mathf.FloorToInt(currentCount % 60);
            return s;
        }

    }
}
