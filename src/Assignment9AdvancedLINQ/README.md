# Advanced LINQ Challenges - Learning

In this assignment, I learned how to use LINQ queries by considering the performance factor.
Implemented QueryBuilder with the Fluent API pattern to perform method chaining operations.

## Task 1 - Basic LINQ Queries

Performed basic LINQ operations listed below like

### Filter the product by category and price

- `Where` filters and returns the results which matches specific condition.

### Sort filtered products in descending order of price

- `OrderByDescending` arranges the product in the descending order based on the key value provides.

### Average price of the product

- `Average` calculates the average value for the numeric field in the collection.

## Task 2 - Complex LINQ Queries

### Group products by category and count the products in each category

- `GroupBy` groups the collection by the provided key.

### Perform an inner join with a list of supplier

- `Join` joins the collection with another collection by using a common key provided.
- The resultant table will contain all the properties from both the collection.

## Task 3 - LINQ to Objects

### Second highest number in the array

- `OrderByDescending` arranges the product in the descending order based on the key value provides.
- `Skip(n)` skips n number of the entities in the collection.

### All unique pairs of numbers in the array that add up to a specified target

- `SelectMany` - Projects each element of a sequence to an `IEnumerable<T>` and flattens the resulting sequences into one sequence.
- `Select` - Projects each element of a sequence to a new form.
- `Distinct` - Returns only the unique entries from the collection.

## Task 4 - Performance Considerations with LINQ

### Selects all products under the category "Books" and sorts them by price

- `Where` - filters and returns the results which matches specific condition.
- `OrderBy` - sorts all the product in ascending based on the key value provided.

### Performance Optimization

- Ordering after reducing the size of the collection improves the performance of the sorting algorithm.
- Materializing the collection also improves the performance of the sorting and printing them.
- Choosing the required fields alone before the sort operation also reduces the memory usage.

## Task 5 - Query Builder

- Implemented QueryBuilder in Fluent API pattern to support method chaining.
- Used `IQueryable<T>` to perform deferred execution and only the memory is created when we materialize by using `Execute` method.
- Used expression to store all the operations as tree and execute them dynamically.
- Implemented dynamic filtering option containing  'Contains', 'StartsWith', 'EndsWith', 'GreaterThanOrEqualTo', and 'LessThanOrEqualTo'.
- Used `Execute` method that call `ToList` to materialize the collection and return a materialized list.
