using System;
using System.Text;

namespace StringCalculatorNS
{
    class Program
    {
        static void Main(string[] args)
        {
          
        }
    }
    public class StringCalculator
    {

        //req3 private readonly string[] delimiter = { ","};
        private readonly string[] delimiter = { ",", "\n" };
        public const string MaximumTwoNumberMessage = "Should provide no more than 2 numbers";
        public StringCalculator()
        {
        }

        public int Addition(string st)
        {
            string[] nums = ParseString(st, delimiter);
           
            /*removed for req2
             checkCountOfNums(nums); */
            int temp = 0;
            foreach (string s in nums)
            {

                temp += ConvertNumber(s);
            }

            return temp;
        }

        public string[] ParseString(string st, string[] delimiter)
        {
            return st.Split(delimiter, StringSplitOptions.None);
        }

        private void checkCountOfNums(string[] st)
        {
            if (st.Length > 2)
            {
                throw new ArgumentException(MaximumTwoNumberMessage);
            }
        }

        private int ConvertNumber(string st)
        {

            int x = 0;

            if (Int32.TryParse(st, out x))
            {
                return x;
            }
            return 0;
        }
    }
}
