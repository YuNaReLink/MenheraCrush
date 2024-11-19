using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ButtonDown : MonoBehaviour
{
    //元の座標
    Vector2 defaultScale;
    bool down = false;
    bool click = false;

    [SerializeField]
    public float ratio = 0.9f;

    private void Awake()
    {
        defaultScale = gameObject.transform.localScale;
    }
    private void Update()
    {
        if (down && Input.GetMouseButtonDown(0))
        {
            click = true;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            click = false;
        }

        if (click && down)
        {
            gameObject.transform.localScale = defaultScale * ratio;
        }
        else
        {
            gameObject.transform.localScale = defaultScale;
        }
    }
    public void Exit()
    {
        //イベントトリガーを追加して､ポインターExitを追加して､ボタンを入れて､これを設定して
        down = false;
    }
    public void Enter()
    {
        //イベントトリガーを追加して､ポインターEnterを追加して､ボタンを入れて､これを設定して
        down = true;        
    }
}
