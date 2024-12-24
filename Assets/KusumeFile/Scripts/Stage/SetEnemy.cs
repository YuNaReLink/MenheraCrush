using UnityEngine;
using UnityEngine.UI;

namespace Kusume
{
    /// <summary>
    /// ステージボタンにアタッチするクラス
    /// ボタンを押したときにこのクラスに設定してる敵タグをSelectStageContainerのタグに保存
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
                Debug.LogWarning("Buttonがコンポーネントされていません");
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
