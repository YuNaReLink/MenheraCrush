using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kusume
{
    public class GameScore
    {
        private int count;
        public int Count => count;

        public void AddScore(int _count)
        {
            count += _count;
        }
    }
}
