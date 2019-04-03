using System;
using System.Collections.Generic;

namespace Brotal.Extensions
{
    public static class Linq
    {
        public static void ForEach<T>(this IEnumerable<T> items,
            Action<T> action)
        {
            foreach (var item in items)
            {
                action(item);
            }
        }

        public static void ForEach<T1, T2>(this IEnumerable<T1> items,
            Action<T2> action, Func<T1, T2> conversion)
        {
            foreach (var item in items)
            {
                action(conversion(item));
            }
        }
    }
}
