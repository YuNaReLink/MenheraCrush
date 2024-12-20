using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.VisualScripting;

namespace LucKee
{
    public class LoopInteger
    {

        private int current = 0;

        private int max = 0;

        public int Current => current;

        public int Max => max;

        public LoopInteger(int max = 1) { this.max = max; }

        public void SetMax(int m)
        {
            max = m;
            current %= max;
        }

        public void Next(int count = 1)
        {
            current += count;
            current %= max;
        }


    }
}
