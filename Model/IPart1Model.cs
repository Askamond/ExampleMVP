using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVP.Model
{
    public interface IPart1Model
    {
        //Task1
        List<int> SimpleLessThanN(int num);
        string Karatsuba(string leftNum, string rightNum);
    }
}
