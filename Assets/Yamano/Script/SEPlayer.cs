using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LucKee
{
    //効果音を鳴らすためだけのコンポーネント
    //空のオブジェクトに括り付けて使う前提のため、鳴り終わるとオブジェクトごと消える。
    //当然ながら鳴らすための機能を要求する。
    [RequireComponent(typeof(AudioSource))]
    public class SEPlayer : MonoBehaviour
    {
        /*Component*/

        //本体
        private AudioSource source = null;

        /*Event*/

        private void Awake()
        {
            //生成時に機能を取得しておく。
            source = GetComponent<AudioSource>();
        }

        private void Update()
        {
            //鳴っていなければ消える。
            if (!source.isPlaying)
            {
                Destroy(gameObject);
            }
        }

        /*Method*/

        //クリップを指定して再生する。
        public void Play(AudioClip clip)
        {
            source.clip = clip;
            source.Play();
        }

    }
}
