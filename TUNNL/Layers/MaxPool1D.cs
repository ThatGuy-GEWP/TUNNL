using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TUNNL.Common;

namespace TUNNL.Layers
{
    public class MaxPool1D : Layer
    {
        readonly int kernal_size;

        public MaxPool1D(uint kernal_size)
        {
            if(kernal_size <= 0) { throw new ArgumentException("Kernal size of pool must be a non-zero value"); }

            this.kernal_size = (int)kernal_size;
        }


        public override void Forward(float[] inputValues)
        {
            if (Activations.Length != inputValues.Length / kernal_size)
            {
                Activations = new float[inputValues.Length / kernal_size];
            }

            for (int i = 0; i < inputValues.Length; i += kernal_size)
            {
                float maxed = float.MinValue;
                for(int j = 0; j < kernal_size; j++)
                {
                    maxed = MathF.Max(inputValues[i + j], maxed);
                }
                Activations[i/kernal_size] = maxed;
            }
        }
    }
}
