using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LucKee
{
    public class TransitionOpener : TransitionUnit
    {


        protected override float EndSize => CalcMaxSize();


        protected override void OnFinished()
        {
            Destroy(gameObject);
        }

    }
}