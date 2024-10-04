using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LucKee
{
    [RequireComponent(typeof(AudioSource))]
    public class SEPlayer : MonoBehaviour
    {
        private AudioSource source = null;
        private void Awake()
        {
            source = GetComponent<AudioSource>();
        }
        public void Play(AudioClip clip)
        {
            source.clip = clip;
            source.Play();
        }
        private void Update()
        {
            if (source.isPlaying)
            {
                Destroy(gameObject);
            }
        }
    }
}
