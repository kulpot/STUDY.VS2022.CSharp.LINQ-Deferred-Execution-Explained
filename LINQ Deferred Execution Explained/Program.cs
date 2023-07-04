using System;
using System.Collections;
using System.Collections.Generic;

// ref link:https://www.youtube.com/watch?v=fppy6TM79-c&list=PL90AF0EFFEF782D27&index=10
// Deferred Execution - exist because of Yield statement

static class MainClass
{
    static IEnumerable<T> Where<T>(this IEnumerable<T> items, Func<T, bool> gauntlet)
    {
        Console.WriteLine("Where");
        foreach (T item in items)
            if (gauntlet(item))
                yield return item;
    }
    static IEnumerable<R> Select<T, R>(this IEnumerable<T> items, Func<T, R> transform)
    {
        Console.WriteLine("Select");
        foreach (T item in items)
            yield return transform(item);
    }
    static void Main()
    {
        int[] stuff = { 4, 8, 1, 9 };
        
        IEnumerable<int> result2 =          
           stuff
                .Where(i => i < 5)
                .Select(i => i + 6);
        IEnumerable<int> result3 =                        
                Select(
                    Where(stuff, i => i < 5), 
                    i => i + 6);
        IEnumerable<int> rator = result2.GetEnumerator();
        while (rator.MoveNext())
            Console.WriteLine(rator.Current);
    }
}