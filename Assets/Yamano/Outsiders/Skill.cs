using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LucKee 
{
    /// <summary>
    /// �X�L���I�u�W�F�N�g�����Ԍo�߂ŏ����N���X
    /// </summary>
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