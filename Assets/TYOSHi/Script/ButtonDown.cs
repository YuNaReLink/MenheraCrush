using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ButtonDown : MonoBehaviour
{
    Vector2 temp;
    bool down = false;
    bool click = false;

    [SerializeField]
    public float Decrease = 0.9f;

    private void Awake()
    {
        temp = gameObject.transform.localScale;
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
            gameObject.transform.localScale = temp * Decrease;
        }
        else
        {
            gameObject.transform.localScale = temp;
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
