using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace LucKee
{
    //�{�^���̑㗝
    //�L�[���͂ő�p�ł���悤�ɂ��邽�߂̃R���|�[�l���g
    [RequireComponent(typeof(Button))]
    public class ButtonRegent : MonoBehaviour
    {
        //�ΏۃL�[
        [SerializeField]
        KeyCode key = KeyCode.A;


        Button button = null;
        bool down = false;

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