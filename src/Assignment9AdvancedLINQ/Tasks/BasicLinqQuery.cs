using Assignment9AdvancedLINQ.Models;
using Assignment9AdvancedLINQ.Models.Enums;
using Assignment9AdvancedLINQ.Repository;
using Assignment9AdvancedLINQ.Views;
using ConsoleTables;

namespace Assignment9AdvancedLINQ.Tasks
{
    /// <summary>
    /// Contains the basic linq operations.
    /// </summary>
    public class BasicLinqQuery
    {
        private readonly Database _database;

        /// <summary>
        /// Initializes a new instance of the <see cref="BasicLinqQuery"/> class.
        /// </summary>
        /// <param name="database">Instance of the database</param>
        public BasicLinqQuery(Database database)
        {
            this._database = database;
        }

        /// <summary>
        /// Gets the average price of the product
        /// </summary>
        public void GetAveragePrice()
        {
            List<Product> product = this._database.GetAllProduct();

            IEnumerable<(string ProductName, decimal Price)> filteredProduct = product
                .Where(product => product.Category == ProductCategory.Electronics && product.Price > 500)
                .Select(product => (product.ProductName, product.Price));
            List<(string ProductName, decimal Price)> orderedByPrice = filteredProduct.OrderByDescending(product => product.Price).ToList();

            ConsoleIO.PrintInfo($"Electronics product greater than 500:");
            ConsoleTable table = new ConsoleTable("Product Name", "Price");
            foreach (var electronics in orderedByPrice)
            {
                table.AddRow(electronics.ProductName, electronics.Price);
            }

            table.Options.EnableCount = false;
            table.Write();

            decimal averagePrice = orderedByPrice.Average(product => product.Price);
            ConsoleIO.PrintInfo($"The average price of the product: {averagePrice}");
        }
    }
}