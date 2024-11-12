using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace LucKee
{
    [RequireComponent(typeof(RectTransform))]
    public class GaugeHolder : MonoBehaviour
    {
        [SerializeField]
        private Image fill = null;

        [SerializeField]
        float value;

        private void Update()
        {
            SetProgress(value);
        }

        public void SetProgress(float f)
        {
            fill.fillAmount = f;
        }
    }

}