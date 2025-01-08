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
        private Button              selectButton;

        [SerializeField]
        private CharacterNameList   character;

        [SerializeField]
        private GameBGMType gameBGMType;

        private void Awake()
        {
            selectButton = GetComponentInChildren<Button>();
            if(selectButton == null)
            {
                Debug.LogWarning("Button���R���|�[�l���g����Ă��܂���");
            }
        }

        private void Start()
        {
            selectButton.onClick.AddListener(Set);
        }

        public void Set()
        {
            SelectStageContainer.SetEnemyCharacter(character);
            SelectStageContainer.SetGameBGMType(gameBGMType);
        }

        public void RandomSet()
        {
            //int randomChara = Random.Range((int)CharacterNameList.HuzisakiAyane, (int)CharacterNameList.HanayaRaika);
            int randomChara = GetRandomExcluding((int)CharacterNameList.HuzisakiAyane, (int)CharacterNameList.HanayaRaika,CharacterSelect.SelectCharacterNo);
            character = (CharacterNameList)randomChara;
            SelectStageContainer.SetEnemyCharacter(character);
            SelectStageContainer.SetGameBGMType(gameBGMType);
        }

        int GetRandomExcluding(int min, int max, int exclude)
        {
            // �l���i�[���郊�X�g���쐬
            List<int> numbers = new List<int>();

            // �w�肳�ꂽ�͈͂̐��l�����X�g�ɒǉ�
            for (int i = min; i <= max; i++)
            {
                if (i != exclude) // ���O�l���X�L�b�v
                {
                    numbers.Add(i);
                }
            }

            // ���X�g���烉���_���Ȓl��I��
            int randomIndex = Random.Range(0, numbers.Count);
            return numbers[randomIndex];
        }
    }
}
