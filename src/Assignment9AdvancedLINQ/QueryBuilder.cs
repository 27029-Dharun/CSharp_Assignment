using System.Linq.Expressions;
using Assignment9AdvancedLINQ.Models.Enums;

namespace Assignment9AdvancedLINQ;

/// <summary>
/// A fluent query builder class containing methods to dynamically build and execute LINQ queries.
/// </summary>
/// <typeparam name="T">Type parameter of elements in the collection</typeparam>
public class QueryBuilder<T>
{
    private IQueryable<T> _list;

    /// <summary>
    /// Initializes a new instance of the <see cref="QueryBuilder{T}"/> class.
    /// </summary>
    /// <param name="list">The initial data source of the collection</param>
    public QueryBuilder(IEnumerable<T> list)
    {
        this._list = list.AsQueryable();
    }

    /// <summary>
    /// Filters the collection based on a specified condition.
    /// </summary>
    /// <param name="filter">The filter condition.</param>
    /// <returns>The current <see cref="QueryBuilder{T}"/> instance for method chaining.</returns>
    public QueryBuilder<T> Filter(Expression<Func<T, bool>> filter)
    {
        this._list = this._list.Where(filter);
        return this;
    }

    /// <summary>
    /// Dynamically builds and applies a filter expression to the collection based on a specified condition and value.
    /// </summary>
    /// <typeparam name="TProperty">The data type of the property being evaluated.</typeparam>
    /// <param name="property">A lambda expression resolving the member property to filter</param>
    /// <param name="condition">The comparison or string matching operator to evaluate.</param>
    /// <param name="value">The constant value compared against the resolved property.</param>
    /// <returns>The current <see cref="QueryBuilder{T}"/> instance for method chaining.</returns>
    /// <exception cref="ArgumentException">Thrown when an unsupported or invalid <see cref="FilterCondition"/> is provided.</exception>
    public QueryBuilder<T> Filter<TProperty>(Expression<Func<T, TProperty>> property, FilterCondition condition, TProperty value)
    {
        var parameter = property.Parameters[0];
        var propertyExpression = property.Body;
        var valueExpression = Expression.Constant(value);

        Expression filterExpression;

        switch (condition)
        {
            case FilterCondition.GreaterThanOrEqualTo:
                filterExpression = Expression.GreaterThanOrEqual(
                    propertyExpression,
                    valueExpression);
                break;

            case FilterCondition.LessThanOrEqualTo:
                filterExpression = Expression.LessThanOrEqual(
                    propertyExpression,
                    valueExpression);
                break;

            case FilterCondition.Contains:
                filterExpression = Expression.Call(
                    propertyExpression,
                    nameof(string.Contains),
                    null,
                    valueExpression);
                break;

            case FilterCondition.StartsWith:
                filterExpression = Expression.Call(
                    propertyExpression,
                    nameof(string.StartsWith),
                    null,
                    valueExpression);
                break;

            case FilterCondition.EndsWith:
                filterExpression = Expression.Call(
                    propertyExpression,
                    nameof(string.EndsWith),
                    null,
                    valueExpression);
                break;

            default:
                throw new ArgumentException("Invalid filter condition.");
        }

        var filter = Expression.Lambda<Func<T, bool>>(
            filterExpression,
            parameter);

        this._list = this._list.Where(filter);

        return this;
    }

    /// <summary>
    /// Sorts the collection based on the member property provided.
    /// </summary>
    /// <typeparam name="TKey">The data type of the property selected to sort the collection.</typeparam>
    /// <param name="keySelector">A lambda expression to extract the sorting key.</param>
    /// <returns>The current <see cref="QueryBuilder{T}"/> instance for method chaining.</returns>
    public QueryBuilder<T> SortBy<TKey>(Expression<Func<T, TKey>> keySelector)
    {
        this._list = this._list.OrderBy(keySelector);
        return this;
    }

    /// <summary>
    /// Join the elements of two collections based on a matching key and mapping the new result.
    /// </summary>
    /// <typeparam name="TInner">The type of the element in the inner collection to join with.</typeparam>
    /// <typeparam name="TKey">The type of the key used to match the elements from the two collection.</typeparam>
    /// <typeparam name="TResult">The type of the resultant collection.</typeparam>
    /// <param name="inner">The inner sequence to join with the current collection.</param>
    /// <param name="outerKeySelector">A lambda expression to extract the join key from each element of the current collection.</param>
    /// <param name="innerKeySelector">A lambda expression to extract the join key from each element of the inner collection.</param>
    /// <param name="resultSelector">A lambda expression that creates a result element from two matching elements.</param>
    /// <returns>A current <see cref="QueryBuilder{T}"/> instance for method chaining.</returns>
    public QueryBuilder<TResult> Join<TInner, TKey, TResult>(IEnumerable<TInner> inner, Expression<Func<T, TKey>> outerKeySelector, Expression<Func<TInner, TKey>> innerKeySelector, Expression<Func<T, TInner, TResult>> resultSelector)
    {
        IQueryable<TResult> result = this._list.Join(inner.AsQueryable(), outerKeySelector, innerKeySelector, resultSelector);
        return new QueryBuilder<TResult>(result);
    }

    /// <summary>
    /// Executes and materialize the collection into the list.
    /// </summary>
    /// <returns>A materialized collection.</returns>
    public List<T> Execute()
    {
        return this._list.ToList();
    }
}