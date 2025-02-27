using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TUNNL.Common
{
    public class Network
    {
        public Layer[] Layers;

        public Network(params Layer[] layers)
        {
            this.Layers = layers;
        }

        public virtual void Forward(float[] input)
        {
            Layers[0].Forward(input);
            for (int i = 1; i < Layers.Length; i++)
            {
                Layers[i].Forward(Layers[i-1].Activations);
            }
        }

        public int[] GetLayerSizes()
        {
            int[] sizes = new int[Layers.Length];

            // to initalize layers that dont have a defined activations count on creation
            Forward(new float[Layers[0].Activations.Length]);

            for (int i = 0; i < sizes.Length; i++)
            {
                sizes[i] = Layers[i].Activations.Length;
            }

            return sizes;
        }

    }
}
