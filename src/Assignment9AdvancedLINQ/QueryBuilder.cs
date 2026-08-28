using System.Linq.Expressions;

namespace Assignment9AdvancedLINQ;

/// <summary>
/// Query builder class containing
/// </summary>
/// <typeparam name="T">Type parameter that contains the IQueryable</typeparam>
public class QueryBuilder<T>
{
    private IQueryable<T> _list;

    /// <summary>
    /// Initializes a new instance of the <see cref="QueryBuilder{T}"/> class.
    /// </summary>
    /// <param name="list">A list of elements</param>
    public QueryBuilder(IEnumerable<T> list)
    {
        this._list = list.AsQueryable();
    }

    /// <summary>
    /// Filters the collection
    /// </summary>
    /// <param name="predicate">Predicate</param>
    /// <returns>returns the predicate</returns>
    public QueryBuilder<T> Filter(Expression<Func<T, bool>> predicate)
    {
        this._list = this._list.Where(predicate);
        return this;
    }

    /// <summary>
    /// Sorts the collection
    /// </summary>
    /// <typeparam name="TKey">Type parameter</typeparam>
    /// <param name="keySelector">Key selector</param>
    /// <returns>A filtered result for sort</returns>
    public QueryBuilder<T> SortBy<TKey>(Expression<Func<T, TKey>> keySelector)
    {
        this._list = this._list.OrderBy(keySelector);
        return this;
    }

    public QueryBuilder<T> Contains(Expression<Func<T, bool>> predicate)
    {
        this._list.Contains()
    }

    /// <summary>
    /// Performs join operation
    /// </summary>
    /// <typeparam name="TInner">Type parameter that takes the inner table as input</typeparam>
    /// <typeparam name="TKey">Type parameter for giving the key</typeparam>
    /// <typeparam name="TResult">Type parameter to accept the resultant table</typeparam>
    /// <param name="inner">Table to be joined with</param>
    /// <param name="outerKeySelector">Key selector for the outer table</param>
    /// <param name="innerKeySelector">Key selector for the inner table to join with</param>
    /// <param name="resultSelector">The resultant selector</param>
    /// <returns>A table</returns>
    public QueryBuilder<TResult> Join<TInner, TKey, TResult>(IEnumerable<TInner> inner, Expression<Func<T, TKey>> outerKeySelector, Expression<Func<TInner, TKey>> innerKeySelector, Expression<Func<T, TInner, TResult>> resultSelector)
    {
        IQueryable<TResult> result = this._list.Join(inner.AsQueryable(), outerKeySelector, innerKeySelector, resultSelector);
        return new QueryBuilder<TResult>(result);
    }

    /// <summary>
    /// Executes and materialize the collections.
    /// </summary>
    /// <returns>A materialized collection</returns>
    public List<T> Execute()
    {
        return this._list.ToList();
    }
}