using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace TUNNL.Common
{
    public enum LayerType
    {
        Fully_Connected
    }


    /// <summary>
    /// A Layer in a network.
    /// Contains an array of floats representing its current value.
    /// </summary>
    public abstract class Layer
    {
        /// <summary>
        /// The activations/output of this layer.
        /// </summary>
        public float[] Activations = [];

        /// <summary>
        /// If false, a bias gradient will not be expected or trained.
        /// </summary>
        public bool bias = false;

        /// <summary>
        /// Inputs values, then pushes them forward.
        /// </summary>
        /// <param name="inputValues">Input from the layer behind.</param>
        public abstract void Forward(float[] inputValues);

        public static implicit operator float[](Layer layer) => layer.Activations;
    }
}
