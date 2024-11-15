using Kusume;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kusume
{
    public class PieceShaderController : MonoBehaviour
    {
        [SerializeField]
        private Piece piece;

        private SpriteRenderer spriteRenderer;

        private Material mat;

        [SerializeField]
        private float speed = 1.5f;

        private void Awake()
        {
            piece = GetComponent<Piece>();
            spriteRenderer = GetComponent<SpriteRenderer>();
        }
        // Start is called before the first frame update
        void Start()
        {
            if (spriteRenderer != null)
            {
                mat = spriteRenderer.material;
            }

            SetLightSpeed();
        }

        private void SetLightSpeed()
        {
            switch (piece.Tag)
            {
                case PieceTag.Red:
                    speed = 1.5f;
                    break;
                case PieceTag.Blue:
                    speed = 1.0f;
                    break;
                case PieceTag.Green:
                    speed = 0.5f;
                    break;
                case PieceTag.Yellow:
                    speed = -0.5f;
                    break;
                case PieceTag.Pink:
                    speed = -1.0f;
                    break;
                case PieceTag.Purple:
                    speed = -1.5f;
                    break;
            }
        }

        // Update is called once per frame
        private void Update()
        {
            MaterialSin();
        }
        private void MaterialSin()
        {
            float offset = Mathf.Sin(Time.time * speed);
            mat.SetFloat("_LightOffset", offset);
        }
    }
}
