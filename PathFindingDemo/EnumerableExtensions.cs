﻿using System;
using System.Collections.Generic;
using System.Text;

namespace PathFindingDemo
{
    public static class EnumerableExtensions
    {
        public static IEnumerable<(T, T)> Pairwise<T>(this IEnumerable<T> source)
        {
            var previous = default(T);
            using (var it = source.GetEnumerator())
            {
                if (it.MoveNext())
                    previous = it.Current;

                while (it.MoveNext())
                    yield return (previous, previous = it.Current);
            }
        }
    }
}
