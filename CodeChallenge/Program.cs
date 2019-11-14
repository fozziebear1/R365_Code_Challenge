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
        private List<string> delimiter;
        private readonly int MaxiumnNumber = 1000;
        public const string MaximumTwoNumberMessage = "Should provide no more than 2 numbers";
        public const string NotAllowNegativeNumberMessage = "Should provide no negative numbers.The input includes:";
        private List<int> negNumbers;
        private List<int> allNumbers;
        public StringCalculator()
        {
            negNumbers = new List<int>();
            allNumbers = new List<int>();
            delimiter = new List<string>();
            delimiter.Add(",");
            delimiter.Add("\n");
           
        }

        public int Addition(string st)
        {
            string[] nums = ParseString(st, delimiter.ToArray());
           
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
            if (st.StartsWith("//"))
            {
                //use custom delimiter
                int dividerIndex = st.IndexOf("\n");
                string temp = st.Substring(2, dividerIndex-2);
          
                List<string> customDlmRange = new List<string>();
                if (temp.Length == 1)
                {
                    customDlmRange.Add(temp);
                }     
                else if(temp.Length >2)
                {

                    int left = temp.IndexOf('[');
                    int right = temp.IndexOf(']');
                    while(left!=-1 && right != -1)
                    {
                        string singleDlm = ParseDelimiter(temp.Substring(left, right - left+1));
                        customDlmRange.Add(singleDlm);
                        temp = temp.Substring(right+1);
                        left = temp.IndexOf('[');
                        right = temp.IndexOf(']');
                    }
                    
                }
               
                this.delimiter.AddRange(customDlmRange);
                string nums = st.Substring(dividerIndex);
                return st.Split(this.delimiter.ToArray(), StringSplitOptions.None);
                
            }
           
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
                    if(x> MaxiumnNumber) continue;
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

        private string ParseDelimiter(string customSt)
        {
            if (customSt[0] != '[' || customSt[customSt.Length - 1] != ']')
            {
                return null;
            }
            else
            {
               
                return customSt.Substring(1, customSt.Length - 2);
            }
        }


    }
}
