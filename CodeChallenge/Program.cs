using System;
using System.Collections.Generic;
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
        public const string NotAllowNegativeNumberMessage = "Should provide no negative numbers.The input includes:";
        private List<int> negNumbers;
        private List<int> allNumbers;
        public StringCalculator()
        {
            negNumbers = new List<int>();
            allNumbers = new List<int>();
        }

        public int Addition(string st)
        {
            string[] nums = ParseString(st, delimiter);
           
            /*removed for req2
             checkCountOfNums(nums); */
            int temp = 0;

            ConvertNumberAndStore(nums);
            CheckNegativeNumbers();
            foreach (int i in allNumbers)
            {

                temp += i;
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

        private void ConvertNumberAndStore(string[] stArr)
        {
            int x = 0;
            foreach (string st in stArr)
            {

                if (Int32.TryParse(st, out x))
                {
                    if (x < 0) negNumbers.Add(x);
                    allNumbers.Add(x);
                }
                
            }
          
        }
        private void CheckNegativeNumbers()
        {
            if (negNumbers.Count > 0)
            {
                StringBuilder sb = new StringBuilder();
                foreach(int i in negNumbers)
                {
                    sb.Append(i.ToString() + ",") ; 
                }
                throw new ArgumentException(NotAllowNegativeNumberMessage + sb.ToString());
            }

        }
      
    }
}
