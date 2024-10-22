using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LucKee
{
    [RequireComponent(typeof(AudioSource))]
    public class BGMPlayer : MonoBehaviour
    {
        private static BGMPlayer instance = null;
        public static BGMPlayer Instance { get => instance; }


        private new AudioSource audio = null;

        private void Awake()
        {
            if (instance != null)
            {
                Destroy(instance.gameObject);
            }
            instance = this;
            audio = GetComponent<AudioSource>();
        }

        public void Play(AudioClip clip)
        {
            audio.clip = clip;
            audio.Play();
        }

        private void OnDestroy()
        {
            audio.Stop();
            instance = null;
        }

        public void SetSpeed(float speed)
        {
            audio.pitch = speed;

        }
    }

}
