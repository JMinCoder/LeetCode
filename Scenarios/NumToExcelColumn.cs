using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scenarios
{
    class NumToExcelColumn
    {
        public void Test()
        {
            this.ToExcelColumn(1);
            this.ToExcelColumn(26);
            this.ToExcelColumn(27);
            this.ToExcelColumn(52);
            this.ToExcelColumn(53);
            this.ToExcelColumn(26*25);
            this.ToExcelColumn(676); // YZ
            this.ToExcelColumn(702); // ZZ
            this.ToExcelColumn(705); // AAC
            this.ToExcelColumn(26 * 26);
            this.ToExcelColumn(26 * 26 + 3);
            this.ToExcelColumn(26 * 27);
            this.ToExcelColumn(26 * 27 + 1);
        }

        public string ToExcelColumn(int n)
        {
            int orig = n;
                        
            var sb = new StringBuilder();
            while (n > 0)
            {
                var r = (n - 1) % 26;
                sb.Append((char)('A' + r));
                n = (n-1) / 26;
            }
            char[] arr = sb.ToString().ToCharArray();
            Array.Reverse(arr);
            var res =  new string(arr);

            Console.WriteLine("{0} => {1}", orig, res);

            return res;
        }
    }
}
