using UnityEngine;


namespace Kusume
{
    /// <summary>
    /// 選択したステージに合わせて敵キャラクターのタグを指定&保存するクラス
    /// </summary>
    public class SelectStageContainer : MonoBehaviour
    {
        private static CharacterNameList enemyCharacter = CharacterNameList.HanayaRaika;

        public static CharacterNameList EnemyCharacter => enemyCharacter;

        public static void SetEnemyCharacter(CharacterNameList tag) { enemyCharacter = tag; }
    }
}

