using LucKee;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kusume
{
    [Serializable]
    public struct AllyCharacterInfo
    {
        public CharacterNameList name;
        public Sprite sprite;
        public Vector2 ImagePosition;
        public Skill skill;
    }

    [CreateAssetMenu(fileName = "Skill", menuName = "ScriptableObjects/Skill", order = 1)]
    public class AllyData : ScriptableObject
    {
        [SerializeField]
        private AllyCharacterInfo[] characters;
        public AllyCharacterInfo[] Characters => characters;

        [SerializeField]
        private List<Skill> dataList = new List<Skill>();
        public List<Skill> DataList => dataList;
    }
}

