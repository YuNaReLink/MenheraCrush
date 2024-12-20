using System.Collections.Generic;
using UnityEngine;

namespace Kusume
{
    [CreateAssetMenu(fileName = "AllSkill", menuName = "ScriptableObjects/AllSkill", order = 1)]
    public class AllSkillData : ScriptableObject
    {
        [SerializeField]
        private List<LucKee.Skill> skills;
        public List<LucKee.Skill> Skills => skills;
    }
}
