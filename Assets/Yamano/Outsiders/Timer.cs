using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LucKee
{
    public class Timer : GradualValueHolder
    {
        public override float Goal { get => 0.0f; set { } }
        public override float Speed { get => 1.0f; set { } }

    }
    public class LoopTimer : Timer, IFinishWaiter
    {

        private float length;

        LoopTimer()
        {
            AddListener(this);
        }
        public void SetLength(float l)
        {
            length = l;
        }

        public void OnFinished()
        {
            Current = length;
        }
    }
}