using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LucKee
{
    //�I�_��ǂ����߂̃N���X
    //���ۉ����Ă��镔�������̂܂܎������Ă���B
    public class GoalFollower : GradualValueHolder
    {
        //�I�_
        private float goal;

        //���x
        private float speed;

        public override float Goal { get => goal; set => goal = value; }

        public override float Speed { get => speed; set => speed = value; }
    }
}