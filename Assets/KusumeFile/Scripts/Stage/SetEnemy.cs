using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Kusume
{
    /// <summary>
    /// �X�e�[�W�{�^���ɃA�^�b�`����N���X
    /// �{�^�����������Ƃ��ɂ��̃N���X�ɐݒ肵�Ă�G�^�O��SelectStageContainer�̃^�O�ɕۑ�
    /// </summary>
    public class SetEnemy : MonoBehaviour
    {
        [SerializeField]
        private Button selectButton;

        [SerializeField]
        private CharacterNameList character;

        private void Awake()
        {
            selectButton = GetComponentInChildren<Button>();
        }

        private void Start()
        {
            selectButton.onClick.AddListener(Set);
        }

        public void Set()
        {
            SelectStageContainer.SetEnemyCharacter(character);
        }
    }
}
