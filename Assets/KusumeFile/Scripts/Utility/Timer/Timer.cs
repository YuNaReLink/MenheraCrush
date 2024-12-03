using System;

namespace Kusume
{
    public class Timer
    {
        public Timer(float _endTime)
        {
            endTime = _endTime;
        }

        public event Action OnEnd;
        public event Action OnOnceEnd;

        private float current = 0;

        private float time = 0;

        private float endTime = 0;

        public float Current => current;

        private bool loop = false;
        public void SetLoop(bool l) {  loop = l; }

        public void Start(float _time)
        {
            current = _time;
            time = _time;
        }

        public void AddCurrent(float _time)
        {
            current += _time;
        }

        public void Update(float t)
        {
            if(current <= endTime) { return; }
            current -= t;
            if(current <= endTime)
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

        public bool IsEnd() {  return current <= endTime; }

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
