using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kusume
{
    public class TimerDestroyObject : MonoBehaviour
    {
        [SerializeField]
        private float destroyCount;

        private Timer destroyTimer;
        private void Awake()
        {
            destroyTimer = new Timer(0);
        }

        private void Start()
        {
            destroyTimer.Start(destroyCount);
            destroyTimer.OnOnceEnd += Run;
        }

        private void Update()
        {
            destroyTimer.Update(Time.deltaTime);
        }

        private void Run()
        {
            Destroy(gameObject);
        }
    }
}
