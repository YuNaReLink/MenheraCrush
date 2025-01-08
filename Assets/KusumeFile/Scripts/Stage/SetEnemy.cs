using System.Collections.Generic;
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
            //int randomChara = Random.Range((int)CharacterNameList.HuzisakiAyane, (int)CharacterNameList.HanayaRaika);
            int randomChara = GetRandomExcluding((int)CharacterNameList.HuzisakiAyane, (int)CharacterNameList.HanayaRaika,CharacterSelect.SelectCharacterNo);
            character = (CharacterNameList)randomChara;
            SelectStageContainer.SetEnemyCharacter(character);
            SelectStageContainer.SetGameBGMType(gameBGMType);
        }

        int GetRandomExcluding(int min, int max, int exclude)
        {
            // 値を格納するリストを作成
            List<int> numbers = new List<int>();

            // 指定された範囲の数値をリストに追加
            for (int i = min; i <= max; i++)
            {
                if (i != exclude) // 除外値をスキップ
                {
                    numbers.Add(i);
                }
            }

            // リストからランダムな値を選択
            int randomIndex = Random.Range(0, numbers.Count);
            return numbers[randomIndex];
        }
    }
}
