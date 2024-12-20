using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using LucKee;

namespace Kusume
{
    //���j���[�̊Ǘ��N���X
    //�|�[�Y���j���[�̊e�{�^���̏��������B
    //�|�[�Y���j���[�Ȃ̂�Pause���A���ʉ��������̂�SEManager��v������B
    //�z��(LucKee�F2024/12/13)
    [RequireComponent(typeof(Pause))]
    [RequireComponent(typeof(SEManager))]
    public class PauseMenu : MonoBehaviour
    {
        /*static*/

        //�V���O���g��
        public static PauseMenu Instance { get; private set; }

        /*Serialized*/
        [SerializeField]
        private SceneList next;
        [SerializeField]
        private Text returnText;



        /*Component*/

        //���ʉ��Đ��p�̃R���|�[�l���g
        private SEManager se;

        //�����~�߂邽�߂̃R���|�[�l���g
        private Pause pause;

        /*Event*/

        private void Awake()
        {
            //�V���O���g���p�̕ϐ��ɑ������B
            Instance = this;

            /*�e�R���|�[�l���g�̎擾*/

            se = GetComponent<SEManager>();
            pause = GetComponent<Pause>();
        }

        private void Start()
        {
            //�J�n���ɉ���炷�B
            se.Play();

            //�|�[�Y��L��������B
            pause.Enable();
        }

        private void OnDestroy()
        {
            //�I�u�W�F�N�g�̔j�����V���O���g���p�ϐ��ɓ`����B
            //������A���g�ȊO�������Ă����ꍇ�͉������Ȃ��B
            if(Instance == this)
            {
                Instance = null;
            }
        }

        /*Method*/

        //���j���[�I������
        public void Close()
        {
            //�|�[�Y�̉�����Pause.OnDestroy�Ɋ܂܂�Ă��邽�߁A�����ŏ����K�v�͖����B
            //pause.Disable();

            //���ʉ��̍Đ�
            se.Play();

            //�I�u�W�F�N�g�̔j��
            Destroy(gameObject);
        }

        //�`���[�g���A���̌Ăяo��
        public void CallTutorial()
        {
            //TODO:�`���[�g���A���̍쐬
        }

        //�^�C�g���̌Ăяo��
        public void CallScene()
        {
            //TODO:�^�C�g���ւ̑J�ڂ̍쐬
            SceneChanger.ChangeScene(next);
        }

        public void SetNext(SceneList n)
        {
            next = n;
            string t = "";
            switch (next)
            {
                case SceneList.Title:
                    t = "�^�C�g��";
                    break;
                case SceneList.StageSelect:
                    t = "�X�e�[�W�I��";
                    break;
                default:
                    t = "v(�L�E�ցE`)v{�G���[......)";
                    break;
            }
            returnText.text = t + "�ɖ߂�";
        }
    }
}
