using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�e�L�X�g�t�@�C���̑䒠
//�e�L�X�g�t�@�C����SerializeField����ǉ����邱�ƂŎg����B
//ScriptableObject���p�����Ă��邽�߁A���L��1�s�̃R�����g�A�E�g���������邱�ƂŎg����悤�ɂȂ�B
[CreateAssetMenu(fileName = "TextLedger", menuName = "ScriptableObjects/TextLedger", order = 1)]
public class TextLedger : ScriptableObject
{
    //�䒠�̖{��
    //������C���X�y�N�^��ŕҏW���邱�ƂŁA�g�p����e�L�X�g�t�@�C���₻�̏��Ԃ�ύX�ł���B
    [SerializeField]
    private TextAsset[] texts;

    //�擾�p���\�b�h
    //TextAsset�^�Ŏg�����Ƃ�z�肵�Ă��Ȃ����߁A�P�ɕ�����^�Ŏ擾����悤�ɂ��Ă���B
    //�z��̏��ԂƓY�����̑Ή��ɒ��ӂ���ׂ��B
    public string GetText(int i) { return texts[i].text; }
}
