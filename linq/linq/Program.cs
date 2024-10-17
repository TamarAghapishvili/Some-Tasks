using System;
using System.Collections.Generic;
using System.Linq;

List<int> list = new List<int> { 3, 23, 25, 16 };

// Find the first element matching the predicate
var first = list.MyFirst(x => x == 16);  // Use == for comparison
Console.WriteLine(first);

// Find all elements greater than 12 using MyWhere
var result = list.MyWhere(x => x > 12);

foreach (int x in result)
{
    Console.WriteLine(x);
}

// Other LINQ methods examples
var skipped = list.Skip(2);  // Skip the first 2 elements
Console.WriteLine("After Skipping 2:");
foreach (int x in skipped)
{
    Console.WriteLine(x);
}

public static class MyLinq
{

    public static T? MyLastOrDefault<T>(this IEnumerable<T> source, Func<T, bool> predicate)
    {
        if (source == null) throw new ArgumentNullException(nameof(source));
        if (predicate == null) throw new ArgumentNullException(nameof(predicate));

        var sourceReverse = source.Reverse();

        foreach (var item in sourceReverse)
        {
            if (predicate(item))
            {
                return item;
            }
        }

        return default;
    }


    public static T MyLast<T>(this IEnumerable<T> source, Func<T, bool> predicate)
    {
        if (source == null) throw new ArgumentNullException(nameof(source));
        if (predicate == null) throw new ArgumentNullException(nameof(predicate));

        var sourceReverse = source.Reverse();

        foreach (var item in sourceReverse)
        {
            if (predicate(item))
            {
                return item;
            }
        }

        throw new InvalidOperationException("Element Not Found");
    }


    public static T? MyFirstOrDefault<T>(this IEnumerable<T> source, Func<T, bool> predicate)
    {
        if (source == null) throw new ArgumentNullException(nameof(source));
        if (predicate == null) throw new ArgumentNullException(nameof(predicate));

        foreach (var item in source)
        {
            if (predicate(item))
            {
                return item;
            }
        }

        return default;
    }


    public static T MyFirst<T>(this IEnumerable<T> source, Func<T, bool> predicate)
    {
        if (source == null) throw new ArgumentNullException(nameof(source));
        if (predicate == null) throw new ArgumentNullException(nameof(predicate));

        foreach (var item in source)
        {
            if (predicate(item))
            {
                return item;
            }
        }

        throw new InvalidOperationException("Element Not Found");
    }

    public static IEnumerable<T> MyWhere<T>(this IEnumerable<T> source, Func<T, bool> predicate)
    {
        if (source == null) throw new ArgumentNullException(nameof(source));
        if (predicate == null) throw new ArgumentNullException(nameof(predicate));

        foreach (var item in source)
        {
            if (predicate(item))
            {
                yield return item;
            }
        }
    }
}
