using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TUNNL.Common
{
    public static class Math
    {

        /// <summary>
        /// Sums an array of floats
        /// </summary>
        /// <param name="floats"></param>
        /// <returns></returns>
        public static float Sum(float[] floats)
        {
            float sum = 0;
            for (int i = 0; i < floats.Length; i++)
            {
                sum += floats[i];
            }

            return sum;
        }

        public static void Mult(float[] a, float[] b)
        {
            for (int i = 0; i < a.Length; i++)
            {
                a[i] *= b[i];
            }
        }

    }
}
