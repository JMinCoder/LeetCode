using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scenarios.NotTagged
{
    /*
     * https://leetcode.com/problems/dota2-senate/description/
     * 
     * In the world of Dota2, there are two parties: the Radiant and the Dire.

The Dota2 senate consists of senators coming from two parties. Now the senate wants to make a decision about a change in the Dota2 game. The voting for this change is a round-based procedure. In each round, each senator can exercise one of the two rights:

Ban one senator's right: 
A senator can make another senator lose all his rights in this and all the following rounds.
Announce the victory: 
If this senator found the senators who still have rights to vote are all from the same party, he can announce the victory and make the decision about the change in the game.
Given a string representing each senator's party belonging. The character 'R' and 'D' represent the Radiant party and the Dire party respectively. Then if there are n senators, the size of the given string will be n.

The round-based procedure starts from the first senator to the last senator in the given order. This procedure will last until the end of voting. All the senators who have lost their rights will be skipped during the procedure.

Suppose every senator is smart enough and will play the best strategy for his own party, you need to predict which party will finally announce the victory and make the change in the Dota2 game. The output should be Radiant or Dire.

Example 1:
Input: "RD"
Output: "Radiant"
Explanation: The first senator comes from Radiant and he can just ban the next senator's right in the round 1. 
And the second senator can't exercise any rights any more since his right has been banned. 
And in the round 2, the first senator can just announce the victory since he is the only guy in the senate who can vote.
Example 2:
Input: "RDD"
Output: "Dire"
Explanation: 
The first senator comes from Radiant and he can just ban the next senator's right in the round 1. 
And the second senator can't exercise any rights anymore since his right has been banned. 
And the third senator comes from Dire and he can ban the first senator's right in the round 1. 
And in the round 2, the third senator can just announce the victory since he is the only guy in the senate who can vote.
Note:
The length of the given string will in the range [1, 10,000].
     */
    class L649Dota2Senate
    {
        public void Test()
        {
        }

        public string PredictPartyVictory(string senate)
        {
            var arr = new int[senate.Length];
            int r = 0;
            int d = 0;
            for (var i = 0; i < senate.Length; i++)
            {
                if (senate[i] == 'R')
                {
                    arr[i] = 1;
                    r++;
                }
                else
                {
                    arr[i] = 2;
                    d++;
                }
            }

            int cur = 0;
            while (r != 0 && d != 0)
            {
                if (arr[cur] == 1)
                {
                    for (var i = (cur + 1) % senate.Length; i != cur; i = (i + 1) % senate.Length)
                    {
                        if (arr[i] == 2)
                        {
                            arr[i] = 0; d--;
                            break;
                        }
                    }
                }
                else if (arr[cur] == 2)
                {
                    for (var i = (cur + 1) % senate.Length; i != cur; i = (i + 1) % senate.Length)
                    {
                        if (arr[i] == 1)
                        {
                            arr[i] = 0;
                            r--;
                            break;
                        }
                    }
                }
                cur = (cur + 1) % senate.Length;
            }

            if (d == 0)
            {
                return "Radiant";
            }
            return "Dire";
        }
    }
}
