using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace LucKee
{
    [RequireComponent(typeof(Image))]
    [RequireComponent(typeof(Pause))]
    public class CutIn : MonoBehaviour
    {
        [SerializeField]
        float duration = 0.0f;
        void Start()
        {
            Pause pause = GetComponent<Pause>();
            pause.Enable();
        }


        void Update()
        {
            duration -= Time.unscaledDeltaTime;
            if (duration <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}

