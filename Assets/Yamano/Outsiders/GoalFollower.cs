using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LucKee
{
    public class GoalFollower : GradualValueHolder
    {
        private float goal;
        private float speed;
        public override float Goal { get => goal; set => goal = value; }
        public override float Speed { get => speed; set => speed = value; }
    }
}