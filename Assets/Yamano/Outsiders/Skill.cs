using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LucKee {
    public class Skill : MonoBehaviour 
    {
        [SerializeField]
        private float duration = 0.0f;
        private void Update()
        {
            duration -= Time.deltaTime;
            if (duration <= 0.0f)
            {
                Destroy(gameObject);
            }
        }
    }
}