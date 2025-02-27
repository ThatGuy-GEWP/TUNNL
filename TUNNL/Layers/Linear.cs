using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TUNNL.Common;

namespace TUNNL.Layers
{
    /// <summary>
    /// Applies an affine linear transformation to the incoming data.
    /// Is also known as a Fully Connected layer.
    /// </summary>
    public class Linear : Layer
    {
        public float[] bias;
        public float[] Weights;

        public Linear(int neuronCount)
        {
            Activations = new float[neuronCount];
            Weights = [];
            bias = new float[neuronCount];
        }

        public Linear(int connectionsIn, int neuronCount)
        {
            Activations = new float[neuronCount];
            Weights = new float[connectionsIn * neuronCount];
            bias = new float[neuronCount];
        }

        public override void Forward(float[] inputValues)
        {
            if(Weights.Length <= 0)
            {
                for (int i = 0; i < Activations.Length; i++)
                {
                    Activations[i] = inputValues[i];
                }
            }
            else
            {
                int step = inputValues.Length;

                for (int i = 0; i < Activations.Length; i++)
                {
                    int subSectionStart = i * step;

                    float[] weightSub = new float[step];

                    for (int j = 0; j < step; j++)
                    {
                        weightSub[j] = Weights[subSectionStart + j];
                    }

                    // mults weights by last layer activations then saves it in the weights sub.
                    Common.Math.Mult(weightSub, inputValues);

                    Activations[i] = weightSub.Sum(); //sums it up.
                }
            }
        }
    }
}
