using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LucKee
{
    //[CreateAssetMenu(fileName = "SkillLedger", menuName = "ScriptableObjects/SkillLedger", order = 1)]
    public class SkillLedger : ScriptableObject
    {
        [SerializeField]
        private List<Skill> skills;
        public List<Skill> Skills { get { return skills; } }
        public Skill GetSkill(int i) { return skills[i]; }
    }
}
