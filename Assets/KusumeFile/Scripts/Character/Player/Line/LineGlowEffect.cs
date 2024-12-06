using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kusume
{
    public class LineGlowEffect : MonoBehaviour
    {
        public LineRenderer lineRenderer;
        public Color startColor = Color.white;
        public Color endColor = Color.blue;
        public float glowSpeed = 2f;

        private float time = 0f;

        private void Awake()
        {
            lineRenderer = GetComponent<LineRenderer>();
        }

        void Update()
        {
            time += Time.deltaTime * glowSpeed;
            Color glowColor = Color.Lerp(startColor, endColor, Mathf.PingPong(time, 1f));
            lineRenderer.startColor = glowColor;
            lineRenderer.endColor = glowColor;
        }
    }
}
