using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scenarios
{
    /*
     * Given a Third party api, which returns 10 elements on each call,
     * Write your own api, which takes number n and return those many elements.
     */
    class C_LibraryApi
    {
        public void Test()
        {
            for (var i=0;i<25;i++)
            {
                var r = this.GetValues(i);
                Console.WriteLine("{0} : {1}.", r.Length, String.Join(", ", r));
            }
        }

        ThirdParty thirdParty = null;
        int[] mResult;
        int mCount;

        public C_LibraryApi()
        {
            thirdParty = new ThirdParty();            
        }

        public int[] GetValues(int n)
        {
            var result = new int[n];
            int count = 0;
            if (mResult == null)
            {
                mResult = thirdParty.GetValues();
                mCount = 0;
            }
            while (count < n)
            {
                for (; count < n && mCount < mResult.Length; count++, mCount++)
                {
                    result[count] = mResult[mCount];
                }

                if (mCount == mResult.Length)
                {
                    mResult = thirdParty.GetValues();
                    mCount = 0;
                }
            }

            return result;
        }

        class ThirdParty
        {
            private readonly int MaxNumber = 10;
            private int counter = 0;

            public int[] GetValues()
            {
                var result = new int[MaxNumber];
                for (var i = 0; i < MaxNumber; i++)
                {
                    result[i] = counter + i;
                }
                counter += MaxNumber;

                return result;
            }
        }
    }
}
