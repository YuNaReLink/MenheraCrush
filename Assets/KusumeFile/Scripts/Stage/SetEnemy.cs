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
            int randomChara = Random.Range((int)CharacterNameList.HuzisakiAyane, (int)CharacterNameList.HanayaRaika);
            character = (CharacterNameList)randomChara;
            SelectStageContainer.SetEnemyCharacter(character);
            SelectStageContainer.SetGameBGMType(gameBGMType);
        }
    }
}
