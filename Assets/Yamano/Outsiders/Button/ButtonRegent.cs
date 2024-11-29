using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace LucKee
{
    //ボタンの代理
    //キー入力で代用できるようにするためのコンポーネント
    [RequireComponent(typeof(Button))]
    public class ButtonRegent : MonoBehaviour
    {
        //対象キー
        [SerializeField]
        private KeyCode key = KeyCode.A;


        private Button button = null;
        private bool down = false;

        private void Awake()
        {
            button = GetComponent<Button>();
        }


        private void Update()
        {
            bool p = IsPushed();
            if (down == p)
            {
                return;
            }
            if (p)
            {
                Down();
            }
            else
            {
                Up();
            }
        }

        private bool IsPushed()
        {
            return Input.GetKey(key);
        }
        private void Down()
        {
            button.targetGraphic.color = button.colors.pressedColor;
            down = true;
        }
        private void Up()
        {
            button.targetGraphic.color = button.colors.normalColor;
            down = false;
            button.onClick.Invoke();
        }
    }

}