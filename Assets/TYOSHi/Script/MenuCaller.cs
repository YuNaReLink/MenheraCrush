using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Kusume;

//���j���[���Ăяo�����߂̃N���X
//���Ɋ���t���Ă����Ȃ������B
//�z��(LucKee�F2024/12/13)
public class MenuCaller : MonoBehaviour
{

    /*Serialized*/

    //���j���[���������邽�߂̃L�����o�X
    //�L�����o�X����������ꍇ�ȂǁA����ɐݒ肳���ƍ���ꍇ�͎蓮�Őݒ肷��ׂ��B
    //�L�����o�X���P�̂Ȃ疢�ݒ�ł����Ȃ������B
    [SerializeField]
    private Canvas canvas;

    //�������郁�j���[�̃v���n�u
    [SerializeField]
    private PauseMenu menuPrefab;

    //�������郁�j���[���߂��̃V�[��
    //�I����ʂ���I����ʂɖ߂邱�Ƃ�h�����߁B
    [SerializeField]
    private SceneList returnTo = SceneList.Title;

    /*Event*/

    private void Awake()
    {
        //���ݒ�̏ꍇ�A�L�����o�X�������擾����B
        if (canvas == null)
        {
            canvas = FindAnyObjectByType<Canvas>();
        }
    }

    private void Update()
    {
        //Esc�L�[�ȊO�̏����͍s��Ȃ����߁A�Y�����Ȃ��ꍇ�͂����Œ��f���Ă���B
        if (!Input.GetKeyUp(KeyCode.Escape))
        {
            return;
        }

        /*
         * Esc�L�[�������ꂽ�ꍇ�A�ȉ��̏����ɏ]���ď������s���B
         * �E���j���[�����݂��Ȃ��ꍇ�A���j���[���Ăяo���B
         * �E���j���[�����݂���ꍇ�A���j���[�����B
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

    //���j���[�Ăяo��
    public void Call()
    {
        //public�ō쐬���Ă��邽��null�`�F�b�N�����ށB
        if (PauseMenu.Instance != null)
        {
            return;
        }

        //�Ώۂ̃L�����o�X�ɐ�������B
        PauseMenu menu = Instantiate(menuPrefab, canvas.transform);

        //���̃V�[�����w�肷��B
        menu.SetNext(returnTo);
    }

    //���j���[�̏I��
    public void Close()
    {
        //public�ō쐬���Ă��邽��null�`�F�b�N�����݂Ȃ������B
        PauseMenu.Instance?.Close();
    }
}
