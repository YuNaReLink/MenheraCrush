using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Kusume;

//メニューを呼び出すためのクラス
//何に括り付けても問題なく動く。
//越権(LucKee：2024/12/13)
public class MenuCaller : MonoBehaviour
{

    /*Serialized*/

    //メニューを召喚するためのキャンバス
    //キャンバスが複数ある場合など、勝手に設定されると困る場合は手動で設定するべし。
    //キャンバスが単体なら未設定でも問題なく動く。
    [SerializeField]
    private Canvas canvas;

    //召喚するメニューのプレハブ
    [SerializeField]
    private PauseMenu menuPrefab;

    //召喚するメニューが戻る先のシーン
    //選択画面から選択画面に戻ることを防ぐため。
    [SerializeField]
    private SceneList returnTo = SceneList.Title;

    /*Event*/

    private void Awake()
    {
        //未設定の場合、キャンバスを自動取得する。
        if (canvas == null)
        {
            canvas = FindAnyObjectByType<Canvas>();
        }
    }

    private void Update()
    {
        //Escキー以外の処理は行わないため、該当しない場合はここで中断している。
        if (!Input.GetKeyUp(KeyCode.Escape))
        {
            return;
        }

        /*
         * Escキーが押された場合、以下の条件に従って処理を行う。
         * ・メニューが存在しない場合、メニューを呼び出す。
         * ・メニューが存在する場合、メニューを閉じる。
         */

        if (PauseMenu.Instance == null)
        {
            Call();
        }
        else
        {
            Close();
        }
    }

    //メニュー呼び出し
    public void Call()
    {
        //publicで作成しているためnullチェックを挟む。
        if (PauseMenu.Instance != null)
        {
            return;
        }

        //対象のキャンバスに生成する。
        PauseMenu menu = Instantiate(menuPrefab, canvas.transform);

        //次のシーンを指定する。
        menu.SetNext(returnTo);
    }

    //メニューの終了
    public void Close()
    {
        //publicで作成しているためnullチェックを挟みながら閉じる。
        PauseMenu.Instance?.Close();
    }
}
