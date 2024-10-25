using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SkillDestroyType
{
    Time,
    SkillEnd,
    Count
}

namespace LucKee {
    public class Skill : MonoBehaviour 
    {
        [SerializeField]
        private float duration = 0.0f;
        public void SetDuration(float d) { duration = d; }
        [SerializeField]
        private bool end = false;
        public void SetEnd(bool b) {  end = b; }
        [SerializeField]
        private SkillDestroyType destroyType = SkillDestroyType.Time;
        public void SetSkillDestroyType(SkillDestroyType type) { destroyType = type; }


        private void Update()
        {
            if(destroyType == SkillDestroyType.Time)
            {
                duration -= Time.deltaTime;
                if (duration <= 0.0f)
                {
                    Destroy(gameObject);
                }
            }
            else if(destroyType == SkillDestroyType.SkillEnd)
            {
                if (!end) { return; }
                Destroy(gameObject);
            }
        }
    }
}