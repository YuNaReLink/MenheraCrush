using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LucKee
{
    public class BGMManager
    {

        public static void Play(AudioClip clip)
        {
            GameObject o = new GameObject("BGM Player");
            BGMPlayer player = o.AddComponent<BGMPlayer>();
            player.Play(clip);
        }
    }
}
