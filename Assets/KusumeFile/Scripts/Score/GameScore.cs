using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kusume
{
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

        public static void InitCount(int g) 
        {
            goal = g;
            count = 0; 
        }


        public static float GetProgress()
        {
            return (float)count / goal;
        }
    }
}
