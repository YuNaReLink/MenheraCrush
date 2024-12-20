using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LucKee
{
    public class TransitionCloser : TransitionUnit
    {
        [SerializeField]
        private SceneList next = SceneList.Title;


        protected override float StartSize => CalcMaxSize();


        protected override void OnFinished()
        {
            gameObject.AddComponent<TransitionOpener>();

            DontDestroyOnLoad(gameObject);
            Destroy(this);

            SceneChanger.ChangeScene(next);
        }

        public void SetNext(SceneList next)
        {
            this.next = next;
        }
    }
}