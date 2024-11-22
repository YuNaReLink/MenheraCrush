using LucKee;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

namespace Kusume
{
    [Serializable]
    public struct CharacterInfo
    {
        public CharacterNameList tag;
        public string name;
        public Skill skill;
        public int skillGauge; 
        public AnimatorController animator;
        public Sprite sprite;
        public Vector2 ImageOffset;
    }

    [CreateAssetMenu(fileName = "Menhera", menuName = "ScriptableObjects/Menhera", order = 1)]
    public class MenheraData : ScriptableObject
    {
        [SerializeField]
        private CharacterInfo[] characters;
        public CharacterInfo[] Characters => characters;

    }
}

