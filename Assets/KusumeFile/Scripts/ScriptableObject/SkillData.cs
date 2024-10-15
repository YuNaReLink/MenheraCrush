using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kusume
{
    [CreateAssetMenu(fileName = "Skill", menuName = "ScriptableObjects/Skill", order = 1)]
    public class SkillData : ScriptableObject
    {
        [SerializeField]
        private GameObject data = null;
        public GameObject Data => data;
    }
}

