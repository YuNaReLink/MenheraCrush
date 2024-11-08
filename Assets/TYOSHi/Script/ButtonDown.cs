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
        //�C�x���g�g���K�[��ǉ����Ĥ�|�C���^�[Exit��ǉ����Ĥ�{�^�������Ĥ�����ݒ肵��
        down = false;
    }
    public void Enter()
    {
        //�C�x���g�g���K�[��ǉ����Ĥ�|�C���^�[Enter��ǉ����Ĥ�{�^�������Ĥ�����ݒ肵��
        down = true;        
    }
}
