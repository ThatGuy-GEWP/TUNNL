using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TUNNL.Common;
using static SFML.Graphics.BlendMode;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TUNNL.Layers.Activations
{
    public class TanH : Layer
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Function(float x)
        {
            return MathF.Tanh(x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Derivative(float x)
        {
            var v = Function(x);
            return 1.0f - (v * v);
        }

        public override void Forward(float[] inputValues)
        {
            if (Activations.Length != inputValues.Length)
            {
                Activations = new float[inputValues.Length];
            }

            for (int i = 0; i < Activations.Length; i++)
            {
                Activations[i] = Function(inputValues[i]);
            }
        }
    }
}
