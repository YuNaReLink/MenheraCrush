using UnityEngine;


namespace Kusume
{
    /// <summary>
    /// �I�������X�e�[�W�ɍ��킹�ēG�L�����N�^�[�̃^�O���w��&�ۑ�����N���X
    /// </summary>
    public class SelectStageContainer : MonoBehaviour
    {
        private static CharacterNameList enemyCharacter = CharacterNameList.HanayaRaika;

        public static CharacterNameList EnemyCharacter => enemyCharacter;

        public static void SetEnemyCharacter(CharacterNameList tag) { enemyCharacter = tag; }
    }
}

