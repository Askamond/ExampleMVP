using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVP.Model
{
    public interface IPart2Model
    {
        int flp2(int x);//Генри Уоррен стр.59(55)

        int clp2(int x);//Генри Уоррен стр.60(56)

        int MaxDivider(int x);


        int MaxPowerLesserTheNumber(int x);

        int XorAllBits(int number);

        int CyclicShiftLeft(int number, int shift);

        int CyclicShiftRight(int number, int shift);

        int MixBits(int number, params int[] mass);
    }
}
