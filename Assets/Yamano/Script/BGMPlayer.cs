using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LucKee
{
    //BGMを再生するためのコンポーネント
    //管理クラスからのみ呼ばれ、コード上で生成するためプレハブ化を行わない。
    //BGMは同時に1つまでしか流れない想定であり、シングルトンで作成しているためクロスフェードなどは対応していない。
    //音声を扱うため、AudioSourceを要求する。
    [RequireComponent(typeof(AudioSource))]
    public class BGMPlayer : MonoBehaviour
    {
        /*static*/

        //唯一のインスタンス
        public static BGMPlayer Instance { get; private set; }

        /*Component*/

        private new AudioSource audio = null;

        /*Event*/

        private void Awake()
        {
            //既に流れている場合、そのBGMを消す。
            if (Instance != null)
            {
                Destroy(Instance.gameObject);
            }

            //生成時、自身が唯一のインスタンスとなる。
            Instance = this;

            //コンポーネントの取得及びループ設定
            audio = GetComponent<AudioSource>();
            audio.loop = true;
        }

        //破棄時、BGMの停止と唯一の座を降りる。
        private void OnDestroy()
        {
            audio.Stop();
            if(Instance == this)
            {
                Instance = null;
            }
        }

        /*Method*/

        //再生の開始
        //指定したクリップを再生する。
        public void Play(AudioClip clip)
        {
            audio.clip = clip;
            audio.Play();
        }

        //再生速度の変更
        //Unityの仕様上、速度の変更に伴って音程も変わってしまうため注意。
        public void SetSpeed(float speed)
        {
            audio.pitch = speed;
        }
    }

}
