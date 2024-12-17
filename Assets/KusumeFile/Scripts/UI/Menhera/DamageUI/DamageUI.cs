using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Kusume
{
    [RequireComponent(typeof(Image))]
    public class DamageUI : MonoBehaviour
    {
        private Image image;

        [SerializeField]
        private Color baseColor;

        [SerializeField]
        private Color changeColor;

        [SerializeField]
        [ReadOnly]
        private bool active;

        private Timer timer = new Timer(0);
        private Timer loopTimer = new Timer(0);
        //全体のカウント
        [SerializeField]
        private float count = 2f;
        //点滅するカウント
        [SerializeField]
        private float loopCount = 0.5f;

        private void Awake()
        {
            image = GetComponent<Image>();
        }

        // Start is called before the first frame update
        private void Start()
        {
            baseColor = image.color;

            timer.OnEnd += Finsh;

            loopTimer.SetLoop(true);
            loopTimer.OnEnd += Toggle;

            active = false;
        }

        // Update is called once per frame
        private void Update()
        {
            if (timer.IsEnd())
            {
                return;
            }


            float t = Time.deltaTime;
            loopTimer.Update(t);
            timer.Update(t);
        }

        public void ColorChangeStart()
        {
            timer.Start(count);
            loopTimer.Start(loopCount);
        }

        public void Toggle()
        {
            SetState(!active);
        }
        public void Finsh()
        {
            SetState(false);
        }

        private void SetState(bool b)
        {
            active = b;
            image.color = b ? changeColor : baseColor;
        }

    }
}
