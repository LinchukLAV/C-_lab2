using System;
using System.Collections.Generic;

namespace Presentation_Layer
{
    static class ConsoleWriter
    {
        public static void WriteConsole<Type>(this Type obj, string message)
        {
            Console.WriteLine($"\n{message}");
            Console.WriteLine(obj);
        }

        public static void WriteConsole<Type>(this IEnumerable<Type> collection, string message)
        {
            Console.WriteLine($"\n{message}");
            foreach (Type item in collection)
                Console.WriteLine(item);
        }

        public static void WriteConsole<TKey, TValue>(this Dictionary<TKey, List<TValue>> multy, string message)
        {
            Console.WriteLine($"\n{message}");
            foreach (KeyValuePair<TKey, List<TValue>> pair in multy)
            {
                Console.WriteLine(pair.Key);
                foreach (TValue element in pair.Value)
                {
                    Console.WriteLine(element);
                }
                Console.WriteLine();
            }
        }
    }
}
