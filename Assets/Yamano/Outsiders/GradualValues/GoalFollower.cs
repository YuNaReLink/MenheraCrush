using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LucKee
{
    //終点を追うためのクラス
    //抽象化している部分をそのまま実装している。
    public class GoalFollower : GradualValueHolder
    {
        //終点
        private float goal;

        //速度
        private float speed;

        public override float Goal { get => goal; set => goal = value; }

        public override float Speed { get => speed; set => speed = value; }
    }
}