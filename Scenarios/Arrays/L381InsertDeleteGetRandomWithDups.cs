using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scenarios.Arrays
{
    /*
     * Design a data structure that supports all following operations in average O(1) time.

Note: Duplicate elements are allowed.
insert(val): Inserts an item val to the collection.
remove(val): Removes an item val from the collection if present.
getRandom: Returns a random element from current collection of elements. 
The probability of each element being returned is linearly related to the number of same value the collection contains.

Example:

// Init an empty collection.
RandomizedCollection collection = new RandomizedCollection();

// Inserts 1 to the collection. Returns true as the collection did not contain 1.
collection.insert(1);

// Inserts another 1 to the collection. Returns false as the collection contained 1. Collection now contains [1,1].
collection.insert(1);

// Inserts 2 to the collection, returns true. Collection now contains [1,1,2].
collection.insert(2);

// getRandom should return 1 with the probability 2/3, and returns 2 with the probability 1/3.
collection.getRandom();

// Removes 1 from the collection, returns true. Collection now contains [1,2].
collection.remove(1);

// getRandom should return 1 and 2 both equally likely.
collection.getRandom();

     */
    class L381InsertDeleteGetRandomWithDups
    {

        public void Test()
        {
            // Your RandomizedSet object will be instantiated and called as such:
            RandomizedSet randomSet = new RandomizedSet();

            // Inserts 1 to the collection. Returns true as the collection did not contain 1.
            Console.WriteLine(randomSet.Insert(1));

            // Inserts another 1 to the collection. Returns false as the collection contained 1. Collection now contains [1,1].
            Console.WriteLine(randomSet.Insert(1));

            // Inserts 2 to the collection, returns true. Collection now contains [1,1,2].
            Console.WriteLine(randomSet.Insert(2));

            // getRandom should return 1 with the probability 2/3, and returns 2 with the probability 1/3.
            Console.WriteLine(randomSet.GetRandom());

            // Removes 1 from the collection, returns true. Collection now contains [1,2].
            Console.WriteLine(randomSet.Remove(1));

            // getRandom should return 1 and 2 both equally likely.
            Console.WriteLine(randomSet.GetRandom());
        }

        public class RandomizedSet
        {
            Dictionary<int, List<int>> dict = new Dictionary<int, List<int>>();
            List<int> list = new List<int>();
            Random rnd = new Random();

            /** Initialize your data structure here. */
            public RandomizedSet()
            {
            }

            /** Inserts a value to the collection. Returns true if the collection did not already contain the specified element. */
            public bool Insert(int val)
            {
                if (dict.ContainsKey(val))
                {
                    dict[val].Add(list.Count);
                    list.Add(val);

                    return false;
                }
                else
                {
                    dict.Add(val, new List<int>() { list.Count } );
                    list.Add(val);
                    return true;
                }
            }

            /** Removes a value from the set. Returns true if the set contained the specified element. */
            public bool Remove(int val)
            {
                //if (!dict.ContainsKey(val)) return false;
                //if (list.Count != 1)
                //{
                //    // Swap with the last element
                //    int lastElem = list[list.Count - 1];
                //    list[dict[val]] = lastElem;
                //    dict[lastElem] = dict[val];
                //}
                //list.RemoveAt(list.Count - 1);
                //dict.Remove(val);

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
