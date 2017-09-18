using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scenarios.Recursion
{
    /*
     * https://leetcode.com/problems/shopping-offers
     * 
     * In LeetCode Store, there are some kinds of items to sell. Each item has a price.
However, there are some special offers, and a special offer consists of one or more different kinds of items with a sale price.

You are given the each item's price, a set of special offers, and the number we need to buy for each item. 
The job is to output the lowest price you have to pay for exactly certain items as given, where you could make optimal use of the special offers.

Each special offer is represented in the form of an array, the last number represents the price you need to pay for this special offer, 
other numbers represents how many specific items you could get if you buy this offer.

You could use any of special offers as many times as you want.

Example 1:
Input: [2,5], [[3,0,5],[1,2,10]], [3,2]
Output: 14
Explanation: 
There are two kinds of items, A and B. Their prices are $2 and $5 respectively. 
In special offer 1, you can pay $5 for 3A and 0B
In special offer 2, you can pay $10 for 1A and 2B. 
You need to buy 3A and 2B, so you may pay $10 for 1A and 2B (special offer #2), and $4 for 2A.

Example 2:
Input: [2,3,4], [[1,1,0,4],[2,2,1,9]], [1,2,1]
Output: 11
Explanation: 
The price of A is $2, and $3 for B, $4 for C. 
You may pay $4 for 1A and 1B, and $9 for 2A ,2B and 1C. 
You need to buy 1A ,2B and 1C, so you may pay $4 for 1A and 1B (special offer #1), and $3 for 1B, $4 for 1C. 
You cannot add more items, though only $9 for 2A ,2B and 1C.
Note:
There are at most 6 kinds of items, 100 special offers.
For each item, you need to buy at most 6 of them.
You are not allowed to buy more items than you want, even if that would lower the overall price.
     */
    class L638ShoppingOffers
    {
        public void Test()
        {
            Console.WriteLine(this.ShoppingOffers(
                new List<int> { 2, 5 },
                new List<IList<int>> { new List<int> { 3, 0, 5 }, new List<int> { 1, 2, 10 } },
                new List<int> { 3, 2 }
                ));

            Console.WriteLine(this.ShoppingOffers(
                new List<int> { 2, 3, 4 },
                new List<IList<int>> { new List<int> { 1, 1, 0, 4 }, new List<int> { 2, 2, 1, 9 } },
                new List<int> { 1, 2, 1 }
                ));
        }
        public int ShoppingOffers(IList<int> price, IList<IList<int>> special, IList<int> needs)
        {
            var dict = new Dictionary<IList<int>, int>();
            var allZeros = new List<int>(needs.Count);
            for (var i = 0; i < needs.Count; i++) allZeros.Add(0);
            dict.Add(allZeros, 0);

            return Dfs(dict, price, special, needs);
        }

        private int Dfs(Dictionary<IList<int>, int> dict, IList<int> price, IList<IList<int>> special, IList<int> needs)
        {
            if (dict.ContainsKey(needs)) return dict[needs];
            int res = Int32.MaxValue;

            foreach (var sp in special)
            {
                var needsCopy = needs.ToList();
                var isValid = true;
                for (var i=0;i<needs.Count;i++)
                {
                    needsCopy[i] -= sp[i];
                    if (needsCopy[i] < 0) { isValid = false;  break; }
                }
                if (isValid)
                {
                    res = Math.Min(res, sp[needs.Count] + Dfs(dict, price, special, needsCopy));
                }
            }

            var noSpecial = 0;
            for (var i=0;i<needs.Count;i++)
            {
                noSpecial += needs[i] * price[i];
            }
            res = Math.Min(res, noSpecial);
            dict.Add(needs, res);

            return res;
        }
    }
}
