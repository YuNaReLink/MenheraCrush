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
        public Vector2 ImageOffset;
        public Skill skill;
    }

    [CreateAssetMenu(fileName = "Ally", menuName = "ScriptableObjects/Ally", order = 1)]
    public class AllyData : ScriptableObject
    {
        [SerializeField]
        private AllyCharacterInfo[] characters;
        public AllyCharacterInfo[] Characters => characters;

    }
}

