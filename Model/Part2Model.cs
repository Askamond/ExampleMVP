using System;

namespace MVP.Model
{
    public class Part2Model : IPart2Model
    {
        public int flp2(int x)//Генри Уоррен стр.59(55)
        {
            x |= (x >> 1);
            x |= (x >> 2);
            x |= (x >> 4);
            x |= (x >> 8);
            x |= (x >> 16);
            return x - (x >> 1);
        }

        public int clp2(int x)//Генри Уоррен стр.60(56)
        {
            x -= 1;
            x |= (x >> 1);
            x |= (x >> 2);
            x |= (x >> 4);
            x |= (x >> 8);
            x |= (x >> 16);
            return x + 1;
        }

        public int MaxDivider(int x)
        {
            if (x == 0) return 0;
            int maxPower = (int)Math.Log(x & -x, 2);
            //return (int)Math.Pow(2, maxPower);
            return maxPower;

        }

        public int MaxPowerLesserTheNumber(int x)
        {
            int maxPower = (int)Math.Log(flp2(x), 2);
            return maxPower;
        }

        public int XorAllBits(int number)
        {
            int result = 0;
            while (number != 0)
            {
                result ^= (number & 1);
                number >>= 1;
            }

            return result;
        }

        public int CyclicShiftLeft(int number, int shift)
        {
            int answer = (number << shift) | (number >> (32 - shift));
            return answer;
        }

        public int CyclicShiftRight(int number, int shift)
        {
            int answer = (number >> shift) | (number << (32 - shift));
            return answer;
        }

        public int MixBits(int number, params int[] mass)
        {
            int answer = 0;
            foreach (int index in mass)
            {
                var hit = (number & (1 << index)) >> index;
                answer |= hit;
                answer <<= 1;
            }

            answer >>= 1;
            return answer;
        }
    }
}
