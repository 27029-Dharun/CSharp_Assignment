using AdvancedFeatures.IO;
using AdvancedFeatures.Models;

namespace AdvancedFeatures.Tasks;

/// <summary>
/// Contains the logic to sort the products using delegates.
/// </summary>
internal class SortingWithDelegates
{
    /// <summary>
    /// Represents the delegate method used to compare two product instances.
    /// </summary>
    /// <param name="first">The first product to compare</param>
    /// <param name="second">The second product to compare</param>
    /// <returns>A signed integer indicating the relative values: less than 0 if first is less than second, 0 if equal, or greater than 0 if first is greater than second.</returns>
    internal delegate int SortDelegate(Product first, Product second);

    /// <summary>
    /// Sorts and prints the list of products based on the given comparison logic.
    /// </summary>
    /// <param name="products">The collection of products to sort.</param>
    /// <param name="sort">The delegate strategy used to determine the sort order.</param>
    internal void SortProducts(List<Product> products, SortDelegate sort)
    {
        products.Sort((first, second) => sort(first, second));

        foreach (var product in products)
        {
            ConsoleIO.PrintInfo($"{product.Name}, {product.Category}, {product.Price}");
        }

        Console.WriteLine();
    }

    /// <summary>
    /// Compares two products by their name alphabetically, ignoring case.
    /// </summary>
    /// <param name="first">The first product to compare.</param>
    /// <param name="second">The second product to compare.</param>
    /// <returns>A comparison value indicating the alphabetical order of the product category.</returns>
    internal int SortByName(Product first, Product second)
    {
        return string.Compare(first.Name, second.Name, StringComparison.OrdinalIgnoreCase);
    }

    /// <summary>
    /// Compares two products by their category alphabetically, ignoring case.
    /// </summary>
    /// <param name="first">The first product to compare.</param>
    /// <param name="second">The second product to compare.</param>
    /// <returns>A comparison value indicating the alphabetical order of the product category.</returns>
    internal int SortByCategory(Product first, Product second)
    {
        return string.Compare(first.Category, second.Category, StringComparison.OrdinalIgnoreCase);
    }

    /// <summary>
    /// Compares two products by their price of the product.
    /// </summary>
    /// <param name="first">The first product to compare.</param>
    /// <param name="second">The second product to compare.</param>
    /// <returns>A comparison value indicating the numeric order of the product prices.</returns>
    internal int SortByPrice(Product first, Product second)
    {
        return first.Price.CompareTo(second.Price);
    }
}
