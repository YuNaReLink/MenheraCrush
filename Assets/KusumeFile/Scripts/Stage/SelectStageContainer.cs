using UnityEngine;


namespace Kusume
{
    public enum GameBGMType
    {
        Null = -1,
        Stage01,
        Stage02,
        Stage03
    }

    /// <summary>
    /// �I�������X�e�[�W�ɍ��킹�ēG�L�����N�^�[�̃^�O���w��&�ۑ�����N���X
    /// </summary>
    public class SelectStageContainer : MonoBehaviour
    {
        private static CharacterNameList enemyCharacter = CharacterNameList.HanayaRaika;

        public static CharacterNameList EnemyCharacter => enemyCharacter;

        public static void SetEnemyCharacter(CharacterNameList tag) { enemyCharacter = tag; }

        private static GameBGMType gameBGMType = GameBGMType.Null;
        public static GameBGMType GameBGMType => gameBGMType;

        public static void SetGameBGMType(GameBGMType bgm)
        {
            gameBGMType = bgm;
        }
    }
}

