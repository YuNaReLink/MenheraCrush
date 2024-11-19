using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class ClickEffect : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem effect;

    [SerializeField]
    private Camera main;

    private Vector2 mousePos;

    private void Awake()
    {
        //�ȉ��L�����o�X�̐ݒ�
        //�J�����̃����_�[���[�h���X�N���[���X�y�[�X�J�����ɕύX
        //�����_�[�J�����Ƀ��C���J�����������
        //�\�[�g���C���[��UI�ɕύX

        effect = GameObject.Find("Particle System").GetComponent<ParticleSystem>();
        main = GameObject.Find("Main Camera").GetComponent<Camera>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
        {
            //�}�E�X�̏ꏊ�擾
            mousePos = Input.mousePosition;
            //�G�t�F�N�g�̈ʒu�ݒ�
            effect.transform.position = main.ScreenToWorldPoint(mousePos);
            //�v���C
            effect.Play();
        }
    }
}
