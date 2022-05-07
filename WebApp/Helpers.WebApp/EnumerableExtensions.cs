namespace Helpers.WebApp;

public static class EnumerableExtensions
{
    public static IEnumerable<T> ForEach<T>(this IEnumerable<T> source, Action<T> action)
    {
        var destination = source.ToArray().AsEnumerable();
        foreach (T element in destination)
        {
            action(element);
        }

        return destination;
    }
    
    // public static IEnumerable<T> Average<T>(this IEnumerable<T> source)
    // {
    //     foreach (T element in source)
    //     {
    //         action(element);
    //     }
    //
    //     return source;
    // }
}