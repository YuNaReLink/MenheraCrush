using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Kusume
{
    public class ViewHP : MonoBehaviour
    {
        [SerializeField]
        private PlayerController controller;

        [SerializeField]
        private Slider damageSlider;

        [SerializeField]
        private float decreaseSpeed = 0.01f;

        [SerializeField]
        private Slider hpSlider;

        public void Setup(PlayerController c)
        {
            controller = c;
        }

        // Update is called once per frame
        private void Update()
        {
            if(controller == null) { return; }
            UpdateGauge();

        }

        private void UpdateGauge()
        {
            float value = controller.HP.GetRatio();
            hpSlider.value = value;

            if (value < damageSlider.value)
            {
                damageSlider.value -= decreaseSpeed * Time.deltaTime;
            }

            if (damageSlider.value < value)
            {
                damageSlider.value = value;
            }
        }
    }
}
