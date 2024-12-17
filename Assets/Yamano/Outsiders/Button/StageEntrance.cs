using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace LucKee
{
    [RequireComponent(typeof(Button))]
    [RequireComponent(typeof(SceneChanger))]
    public class StageEntrance : MonoBehaviour
    {
        [SerializeField]
        private Text text;
        public void SetText(String s)
        {
            text.text = s;
        }
    }

}