using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scenarios.Design
{
    /*
     * https://leetcode.com/problems/design-compressed-string-iterator
     * 
     * Design and implement a data structure for a compressed string iterator. It should support the following operations: next and hasNext.

The given compressed string will be in the form of each letter followed by a positive integer representing the number of this letter existing in the original uncompressed string.

next() - if the original string still has uncompressed characters, return the next letter; Otherwise return a white space.
hasNext() - Judge whether there is any letter needs to be uncompressed.

Note:
Please remember to RESET your class variables declared in StringIterator, as static/class variables are persisted across multiple test cases. Please see here for more details.

Example:

StringIterator iterator = new StringIterator("L1e2t1C1o1d1e1");

iterator.next(); // return 'L'
iterator.next(); // return 'e'
iterator.next(); // return 'e'
iterator.next(); // return 't'
iterator.next(); // return 'C'
iterator.next(); // return 'o'
iterator.next(); // return 'd'
iterator.hasNext(); // return true
iterator.next(); // return 'e'
iterator.hasNext(); // return false
iterator.next(); // return ' '
     */
    class L604CompressedStringIterator
    {
        public void Test()
        {
            StringIterator iterator = new StringIterator("L12e2t1C1o1d1e1");

            //StringIterator iterator = new StringIterator("L1e2");
            int count = 1;
            while (iterator.HasNext())
            {
                Console.WriteLine("{0} [{1}]", count++, iterator.Next());

            }
            Console.WriteLine("Last [{0}]", iterator.Next());

            iterator = new StringIterator("L12e2t1C1o1d1e1");

            Console.WriteLine(iterator.Next()); // return 'L'
            Console.WriteLine(iterator.Next()); // return 'e'
            Console.WriteLine(iterator.Next()); // return 'e'
            Console.WriteLine(iterator.Next()); // return 't'
            Console.WriteLine(iterator.Next()); // return 'C'
            Console.WriteLine(iterator.Next());// return 'o'
            Console.WriteLine(iterator.Next()); // return 'd'
            Console.WriteLine(iterator.HasNext()); // return true
            Console.WriteLine(iterator.Next()); // return 'e'
            Console.WriteLine(iterator.HasNext()); // return false
            Console.WriteLine("[{0}]", iterator.Next()); ; // return ' 
        }

        public class StringIterator
        {
            string str;
            int cur;
            int repeat;
            Char ch;

            public StringIterator(string compressedString)
            {
                str = compressedString;
                cur = 0;
                repeat = 0;
                ch = ' ';
            }

            public char Next()
            {
                if (repeat > 0)
                {
                    repeat--;
                    return ch;
                }
                if (cur == str.Length) return ' ';

                ch = str[cur];
                repeat = 0;
                int i = cur + 1;
                while (i < str.Length)
                {
                    if (str[i] >= '0' && str[i] <= '9')
                    {
                        repeat = repeat * 10 + str[i] - '0';
                    }
                    else
                    {
                        break;
                    }
                    i++;
                }

                repeat--;
                cur = i;
                return ch;
            }

            public bool HasNext()
            {
                return cur < str.Length || repeat > 0;
            }
        }
    }
}
