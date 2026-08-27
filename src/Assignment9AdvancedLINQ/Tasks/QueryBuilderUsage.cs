using Assignment9AdvancedLINQ.Models;
using Assignment9AdvancedLINQ.Models.Enums;
using Assignment9AdvancedLINQ.Repository;
using Assignment9AdvancedLINQ.Views;
using ConsoleTables;

namespace Assignment9AdvancedLINQ.Tasks
{
    /// <summary>
    /// Query builder method
    /// </summary>
    public class QueryBuilderUsage
    {
        private readonly Database _database;
        private readonly ConsoleView _view;

        /// <summary>
        /// Initializes a new instance of the <see cref="QueryBuilderUsage"/> class.
        /// </summary>
        /// <param name="database">Instance of the database</param>
        /// <param name="view">Instance of the view</param>
        public QueryBuilderUsage(Database database, ConsoleView view)
        {
            this._database = database;
            this._view = view;
        }

        /// <summary>
        /// Sort the list
        /// </summary>
        public void SortList()
        {
            List<Product> products = this._database.GetAllProduct();
            QueryBuilder<Product> product = new QueryBuilder<Product>(products);

            var res = product.Filter(x => x.Category == ProductCategory.Electronics).Sort(x => x.Price).Execute();
            this._view.PrintInfo($"{res.Count()}");

            ConsoleTable table = new ConsoleTable("Product Id", "Product Name", "Product Price", "Product Category");
            foreach (var productItem in res)
            {
                table.AddRow(productItem.Id, productItem.ProductName, productItem.Price, productItem.Category);
            }

            table.Write();
        }
    }
}
