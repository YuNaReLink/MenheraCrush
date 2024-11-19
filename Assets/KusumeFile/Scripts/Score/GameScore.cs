

namespace Kusume
{
    /// <summary>
    /// ゲーム中のスコアを計測&ゲーム中に獲得した総スコアを保持するクラス
    /// 参照はstaticなのでGameScore.Bounsで可能
    /// </summary>
    public class GameScore
    {
        private static bool bonus = false;
        public static bool Bonus => bonus;
        public static void SetBonus(bool b) { bonus = b; }


        private static int onceCount;
        /// <summary>
        /// 一度のスコアを保持する変数
        /// </summary>
        public static int OnceCount => onceCount;
        public static void SetOnceCount(int c) 
        {
            onceCount = c;
            count += c;
        }
        public static void InitOnceCount() { onceCount = 0; }

        /// <summary>
        /// 総スコアを保持する変数
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
