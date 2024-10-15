using LucKee;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kusume
{
    [CreateAssetMenu(fileName = "Skill", menuName = "ScriptableObjects/Skill", order = 1)]
    public class SkillData : ScriptableObject
    {
        [SerializeField]
        private List<Skill> dataList = new List<Skill>();
        public List<Skill> DataList => dataList;
    }
}

