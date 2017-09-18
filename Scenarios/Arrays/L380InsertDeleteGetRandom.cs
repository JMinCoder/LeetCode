using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scenarios.Arrays
{
    /*
     * Design a data structure that supports all following operations in average O(1) time.
     * 
     * insert(val): Inserts an item val to the set if not already present.
     * remove(val): Removes an item val from the set if present.
     * getRandom: Returns a random element from current set of elements. Each element must have the same probability of being returned.
Example:

// Init an empty set.
RandomizedSet randomSet = new RandomizedSet();

// Inserts 1 to the set. Returns true as 1 was inserted successfully.
randomSet.insert(1);

// Returns false as 2 does not exist in the set.
randomSet.remove(2);

// Inserts 2 to the set, returns true. Set now contains [1,2].
randomSet.insert(2);

// getRandom should return either 1 or 2 randomly.
randomSet.getRandom();

// Removes 1 from the set, returns true. Set now contains [2].
randomSet.remove(1);

// 2 was already in the set, so return false.
randomSet.insert(2);

// Since 2 is the only number in the set, getRandom always return 2.
randomSet.getRandom();

     */
    class L380InsertDeleteGetRandom
    {

        public void Test()
        {
            // Your RandomizedSet object will be instantiated and called as such:
            RandomizedSet randomSet = new RandomizedSet();

            Console.WriteLine(randomSet.Insert(1));

            // Returns false as 2 does not exist in the set.
            Console.WriteLine(randomSet.Remove(2));

            // Inserts 2 to the set, returns true. Set now contains [1,2].
            Console.WriteLine(randomSet.Insert(2));

            // getRandom should return either 1 or 2 randomly.
            Console.WriteLine(randomSet.GetRandom());
            Console.WriteLine(randomSet.GetRandom());
            Console.WriteLine(randomSet.GetRandom());
            Console.WriteLine(randomSet.GetRandom());
            Console.WriteLine(randomSet.GetRandom());

            // Removes 1 from the set, returns true. Set now contains [2].
            Console.WriteLine(randomSet.Remove(1));

            // 2 was already in the set, so return false.
            Console.WriteLine(randomSet.Insert(2));

            // Since 2 is the only number in the set, getRandom always return 2.
            Console.WriteLine(randomSet.GetRandom());
        }

        public class RandomizedSet
        {
            Dictionary<int, int> dict = new Dictionary<int, int>();
            List<int> list = new List<int>();
            Random rnd = new Random();

            /** Initialize your data structure here. */
            public RandomizedSet()
            {

            }

            /** Inserts a value to the set. Returns true if the set did not already contain the specified element. */
            public bool Insert(int val)
            {
                if (dict.ContainsKey(val)) return false;
                dict.Add(val, list.Count);
                list.Add(val);
                return true;
            }

            /** Removes a value from the set. Returns true if the set contained the specified element. */
            public bool Remove(int val)
            {
                if (!dict.ContainsKey(val)) return false;
                if (list.Count != 1)
                {
                    // Swap with the last element
                    int tmp = list[list.Count - 1];
                    list[dict[val]] = tmp;
                    dict[tmp] = dict[val];
                }
                list.RemoveAt(list.Count - 1);
                dict.Remove(val);

                return true;
            }

            /** Get a random element from the set. */
            public int GetRandom()
            {
                return this.list[rnd.Next(0, this.list.Count)];
            }
        }

        
    }
}
