using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LucKee {
    public class Tester : MonoBehaviour
    {
        [SerializeField]
        Canvas canvas = null;
        [SerializeField]
        CutIn prefab = null;
        private void Update()
        {
            if (Input.anyKeyDown)
            {
                Instantiate(prefab, canvas.transform);
            }
        }
    }
}

