using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Globalization;
using System.Linq;
using System.Numerics;


namespace MVP.Model
{
    public class Part1Model: IPart1Model
    {
        //Task1
        public List<int> SimpleLessThanN(int num)
        {
            List<int> resultList = new List<int>();
            bool isBreak = false;

            if (num <= 2)
                return resultList;
            resultList.Add(2);
            for (int i = 3; i < num; i++)
            {
                if ((i > 10) && (i % 10 == 5))
                {
                    i++;
                    continue;
                }
                isBreak = false;
                foreach (var j in resultList)
                {
                    if (j * j - 1 > i)
                    {
                        isBreak = true;
                        resultList.Add(i);
                        break;
                    }
                    if (i % j == 0)
                    {
                        isBreak = true;
                        break;
                    }
                }
                if (!isBreak)
                    resultList.Add(i);
                i++;
            }

            return resultList;
        }

        //Task5

        private List<int> StringToIntList(string num)
        {
            List<int> result = new List<int>();
            for (int i = num.Length; i > 0; i--)
                result.Add(num[i-1]);
            return result;
        } 

        private string NumSizeEqualizer(string input, int size)
        {
            while (input.Length < size)
                input = '0' + input;
            return input;
        }

        private BigInteger NaiveMultiply(BigInteger left, BigInteger right)
        {
            return BigInteger.Multiply(left, right);
        }
        
        private BigInteger KaratsubaMultiply(List<int> left, List<int> right)
        {
            BigInteger result = new BigInteger(0);

            return result;
        }

        public string Karatsuba(string leftNum, string rightNum)
        {
            int numLength = Math.Max(leftNum.Length, rightNum.Length);
            if (numLength == 1)
                return Convert.ToString(Convert.ToInt32(leftNum) * Convert.ToInt32(rightNum));
            if (leftNum.Length != rightNum.Length)
                if (leftNum.Length != numLength)
                    leftNum = NumSizeEqualizer(leftNum, numLength);
                else
                    rightNum = NumSizeEqualizer(rightNum, numLength);


            return KaratsubaMultiply(StringToIntList(leftNum), StringToIntList(rightNum)).ToString();
        }

    }
}
