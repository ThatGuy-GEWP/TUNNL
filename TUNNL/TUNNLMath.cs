using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TUNNL
{
    public static class TUNNLMath
    {




        public static Half[] Mult(in Half[] a, in Half[] b)
        {
            if(b.Length > a.Length) { throw new ArgumentException("Array B is larger then A"); }

            Half[] res = new Half[a.Length];

            for (int i = 0; i < b.Length; i++)
            {
                res[i] = a[i] * b[i];
            }

            return res;
        }


    }
}
