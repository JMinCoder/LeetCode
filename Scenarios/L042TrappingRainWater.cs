using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scenarios
{
    class L042TrappingRainWater
    {
        public void Test()
        {
            int[][] hs = {
                    new int[] { },
                    new int[] {0 },
                    new int[] {0, 1 },
                    new int[] {1, 0 },
                    new int[] {1, 0, 1 },
                    new int[] {1, 1 },
                    new int[] {0, 1, 0, 2, 1, 0, 1, 3},
                    new int[] {0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1 },                    
            };

            foreach (var h in hs)
            {
                Console.WriteLine(this.Trap(h));
                if (this.Trap(h) != this.Trap3(h))
                {
                    Console.WriteLine("Diff: " + this.Trap(h));
                    Console.WriteLine("Diff: " + this.Trap3(h));
                }
            }
        }

        /*
         * Here is my idea: instead of calculating area by height*width, we can think it in a cumulative way. 
         *  In other words, sum water amount of each bin(width=1).
         *  Search from left to right and maintain a max height of left and right separately, 
         *  which is like a one-side wall of partial container. 
         *  Fix the higher one and flow water from the lower part. 
         *  For example, if current height of left is lower, we fill water in the left bin. 
         *  Until left meets right, we filled the whole container.
         */
        public int Trap2(int[] height)
        {
            int left = 0; int right = height.Length - 1;
            int res = 0;
            int maxleft = 0, maxright = 0;
            while (left <= right)
            {
                if (height[left] <= height[right])
                {
                    if (height[left] >= maxleft) maxleft = height[left];
                    else res += maxleft - height[left];
                    left++;
                }
                else
                {
                    if (height[right] >= maxright) maxright = height[right];
                    else res += maxright - height[right];
                    right--;
                }
            }
            return res;
        }

        public int Trap3(int[] height)
        {
            int a = 0;
            int b = height.Length - 1;
            int max = 0;
            int leftmax = 0;
            int rightmax = 0;
            while (a <= b)
            {
                leftmax = Math.Max(leftmax, height[a]);
                rightmax = Math.Max(rightmax, height[b]);
                if (leftmax < rightmax)
                {
                    max += (leftmax - height[a]);       // leftmax is smaller than rightmax, so the (leftmax-A[a]) water can be stored
                    a++;
                }
                else
                {
                    max += (rightmax - height[b]);
                    b--;
                }
            }
            return max;
        }

        

        public int Trap(int[] height)
        {
            var list = new List<int>();
            int prev = 1;
            if (height == null || height.Length == 0) return 0;
            for (var i=0;i<height.Length;i++)
            {
                if (height[i] >= prev)
                {
                    list.Add(i);
                    prev = height[i];
                }
            }
            if (list.Count == 0) return 0;
            prev = list[0];
            int area = 0;
            for (var i=1;i<list.Count;i++)
            {
                for (var j=prev+1;j<list[i];j++)
                {
                    area += (height[prev] - height[j]);
                }
                prev = list[i];
            }
            // Reverse
            var revList = new List<int>();
            prev = 1;
            
            for (var i=height.Length-1;i>=list[list.Count-1];i--)
            {
                if (height[i] >= prev)
                {
                    revList.Add(i);
                    prev = height[i];
                }
            }
            int rem = 0;

            if (revList.Count > 0)
            {
                prev = revList[0];

                for (var i = 1; i < revList.Count; i++)
                {
                    for (var j = prev; j > revList[i]; j--)
                    {
                        rem += (height[prev] - height[j]);
                    }
                    prev = revList[i];
                }
            }
            return area + rem;
        }
    }
}
