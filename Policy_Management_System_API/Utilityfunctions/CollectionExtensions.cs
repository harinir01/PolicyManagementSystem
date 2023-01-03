using System.Linq.Expressions;
namespace Policy_Management_System_API;
public static class CollectionExtensions
{
    public static IQueryable<TSource> WhereIf<TSource>(
        this IQueryable<TSource> source,
        bool condition,
        Expression<Func<TSource, bool>> predicate)
        {
        if (condition)
            return source.Where(predicate);
        else
            return source;
        }
}