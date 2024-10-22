using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LucKee
{
    public interface IChangeWaiter
    {
        public void OnChanged(float moved, float current);
    }
    public interface IFinishWaiter
    {
        public void OnFinished();
    }

    public abstract class GradualValueHolder
    {
        private List<IChangeWaiter> changed = new();
        private List<IFinishWaiter> finished = new();

        public void AddListener(IChangeWaiter c) { changed.Add(c); }
        public void AddListener(IFinishWaiter f) { finished.Add(f); }

        public float Current { get; protected set; }

        public abstract float Goal { get; set; }
        public abstract float Speed { get; set; }

        public bool IsFinished() { return Current == Goal; }

        public void Update(float delta)
        {
            if (IsFinished())
            {
                return;
            }
            float diff = Goal - Current;
            float move = Speed * delta;
            
            if (Mathf.Abs(diff) <= move)
            {
                Current = Goal;
                InvokeChange(diff);
                InvokeFinish();
                return;
            }

            if (diff < 0)
            {
                move *= -1;
            }
            Current += move;
            InvokeChange(diff);
        }

        private void InvokeChange(float moved)
        {
            foreach (IChangeWaiter c in changed)
            {
                c.OnChanged(moved, Current);
            }
        }
        private void InvokeFinish()
        {
            foreach (IFinishWaiter f in finished)
            {
                f.OnFinished();
            }
        }

    }

}