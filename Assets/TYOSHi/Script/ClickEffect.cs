using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class ClickEffect : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem effectPrefab;

    [SerializeField]
    private Camera main;


    private void Awake()
    {
        //�ȉ��L�����o�X�̐ݒ�
        //�J�����̃����_�[���[�h���X�N���[���X�y�[�X�J�����ɕύX
        //�����_�[�J�����Ƀ��C���J�����������
        //�\�[�g���C���[��UI�ɕύX

        main = GameObject.Find("Main Camera").GetComponent<Camera>();

    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
        {
            //�}�E�X�̏ꏊ�擾
            Vector2 mousePos = Input.mousePosition;
            Vector2 pos = main.ScreenToWorldPoint(mousePos);
            ParticleSystem effect = Instantiate(effectPrefab, transform);
            effect.transform.position = pos;
            effect.Play();
        }
    }
}
