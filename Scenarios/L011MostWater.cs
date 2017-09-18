using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scenarios
{
    class MostWater
    {
        public void Test()
        {
            Console.WriteLine(this.MaxArea(new int[] { 1, 2, 4, 3}));
        }

        public int MaxArea(int[] height)
        {
            int max = 0;
            int i = 0; int j = height.Length - 1;
            while (i < j)
            {
                int area = (j - i) * Math.Min(height[i], height[j]) ;
                max = Math.Max(max, area);
                if (height[i] < height[j])
                    i++;
                else
                    j--;
            }

            return max;
        }
    }
}
