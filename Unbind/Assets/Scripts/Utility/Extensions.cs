using System;
using System.Collections.Generic;
using UnityEngine;

namespace Unbind
{
    public static class Extensions
    {
        public static IEnumerable<T> GetFlags<T>(this T input) where T : Enum
        {
            T[] values = (T[])Enum.GetValues(typeof(T));
            for (int i = 1;  i < values.Length; i++)
            {
                if (input.HasFlag(values[i]))
                    yield return values[i];
            }
        }
    }
}
