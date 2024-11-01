using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LucKee {
    public class Skill : MonoBehaviour 
    {
        [SerializeField]
        private float duration = 0.0f;
        public void SetDuration(float d) { duration = d; }

        public void End() { Destroy(gameObject); }

        private void Update()
        {
            duration -= Time.deltaTime;
            if (duration <= 0.0f)
            {
                End();
            }
        }
    }
}