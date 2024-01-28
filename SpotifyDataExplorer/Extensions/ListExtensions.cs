using System.Collections.Generic;

namespace SpotifyDataExplorer.Extensions;

public static class ListExtensions
{
    public static bool HasNextPage<T>(this IList<T[]>? chunks, int pageNumber)
    {
        if (chunks is null)
        {
            return false;
        }
        
        return (chunks.Count - 1) > pageNumber ;
    }
}