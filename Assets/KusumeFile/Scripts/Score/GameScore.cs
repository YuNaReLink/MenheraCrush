

namespace Kusume
{
    /// <summary>
    /// �Q�[�����̃X�R�A���v��&�Q�[�����Ɋl���������X�R�A��ێ�����N���X
    /// �Q�Ƃ�static�Ȃ̂�GameScore.Bouns�ŉ\
    /// </summary>
    public class GameScore
    {
        private static bool bonus = false;
        public static bool Bonus => bonus;
        public static void SetBonus(bool b) { bonus = b; }


        private static int onceCount;
        /// <summary>
        /// ��x�̃X�R�A��ێ�����ϐ�
        /// </summary>
        public static int OnceCount => onceCount;
        public static void SetOnceCount(int c) 
        {
            onceCount = c;
            count += c;
        }
        public static void InitOnceCount() { onceCount = 0; }

        /// <summary>
        /// ���X�R�A��ێ�����ϐ�
        /// </summary>
        private static int count;
        public static int Count => count;

        private static int goal;

        private static int overGoal;

        public static void InitCount(int g) 
        {
            goal = g;
            count = 0; 
        }

        public static void InitOverCount(int g)
        {
            overGoal = g;
        }

        public static float GetProgress()
        {
            return (float)count / goal;
        }

        public static float GetOverProgress()
        {
            return (float)count / overGoal;
        }
    }
}
