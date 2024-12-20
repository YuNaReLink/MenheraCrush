using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using LucKee;

namespace Kusume
{
    //メニューの管理クラス
    //ポーズメニューの各ボタンの処理を持つ。
    //ポーズメニューなのでPauseを、効果音を扱うのでSEManagerを要求する。
    //越権(LucKee：2024/12/13)
    [RequireComponent(typeof(Pause))]
    [RequireComponent(typeof(SEManager))]
    public class PauseMenu : MonoBehaviour
    {
        /*static*/

        //シングルトン
        public static PauseMenu Instance { get; private set; }

        /*Serialized*/
        [SerializeField]
        private SceneList next;
        [SerializeField]
        private Text returnText;



        /*Component*/

        //効果音再生用のコンポーネント
        private SEManager se;

        //時を止めるためのコンポーネント
        private Pause pause;

        /*Event*/

        private void Awake()
        {
            //シングルトン用の変数に代入する。
            Instance = this;

            /*各コンポーネントの取得*/

            se = GetComponent<SEManager>();
            pause = GetComponent<Pause>();
        }

        private void Start()
        {
            //開始時に音を鳴らす。
            se.Play();

            //ポーズを有効化する。
            pause.Enable();
        }

        private void OnDestroy()
        {
            //オブジェクトの破棄をシングルトン用変数に伝える。
            //万が一、自身以外が入っていた場合は何もしない。
            if(Instance == this)
            {
                Instance = null;
            }
        }

        /*Method*/

        //メニュー終了処理
        public void Close()
        {
            //ポーズの解除はPause.OnDestroyに含まれているため、ここで書く必要は無い。
            //pause.Disable();

            //効果音の再生
            se.Play();

            //オブジェクトの破棄
            Destroy(gameObject);
        }

        //チュートリアルの呼び出し
        public void CallTutorial()
        {
            //TODO:チュートリアルの作成
        }

        //タイトルの呼び出し
        public void CallScene()
        {
            //TODO:タイトルへの遷移の作成
            SceneChanger.ChangeScene(next);
        }

        public void SetNext(SceneList n)
        {
            next = n;
            string t = "";
            switch (next)
            {
                case SceneList.Title:
                    t = "タイトル";
                    break;
                case SceneList.StageSelect:
                    t = "ステージ選択";
                    break;
                default:
                    t = "v(´・ω・`)v{エラー......)";
                    break;
            }
            returnText.text = t + "に戻る";
        }
    }
}
