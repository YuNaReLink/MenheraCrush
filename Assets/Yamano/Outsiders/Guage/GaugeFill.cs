using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace LucKee
{
    [RequireComponent(typeof(Image))]
    public class GaugeFill : MonoBehaviour
    {
        Image image = null;
        [SerializeField]
        float r;
        private void Awake()
        {
            image = GetComponent<Image>();
        }
        private void Update()
        {
            SetGoalRatio(r);
        }
        public void SetGoalRatio(float ratio)
        {
            Material mat = image.material;
            mat.SetFloat("_ColorBorder", ratio);
        }

    }
}