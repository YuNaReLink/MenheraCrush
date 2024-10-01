using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LucKee
{
    public class Pause : MonoBehaviour
    {
        private float wait = 0;
        private void Update()
        {
            if (wait <= 0)
            {
                return;
            }
            wait -= Time.unscaledDeltaTime;
            if (wait <= 0)
            {
                wait = 0;
                Disable();
            }
        }

        public void Enable()
        {
            Time.timeScale = 0.0f;
        }
        public void Disable()
        {
            Time.timeScale = 1.0f;
        }
        public void Disable(float w)
        {
            if (w <= 0)
            {
                Disable();
                return;
            }
            wait = w;
        }

    }
}
