using Assignment9AdvancedLINQ.Models;
using Assignment9AdvancedLINQ.Models.DTO;
using Assignment9AdvancedLINQ.Models.Enums;
using Assignment9AdvancedLINQ.Repository;
using Assignment9AdvancedLINQ.Views;
using ConsoleTables;

namespace Assignment9AdvancedLINQ.Tasks
{
    /// <summary>
    /// Contains method chaining operation by using QueryBuilder
    /// </summary>
    public class MethodChaining
    {
        private readonly Database _database;

        /// <summary>
        /// Initializes a new instance of the <see cref="MethodChaining"/> class.
        /// </summary>
        /// <param name="database">Instance of the database</param>
        public MethodChaining(Database database)
        {
            this._database = database;
        }

        /// <summary>
        /// Implements the method chaining operations.
        /// </summary>
        public void HandleMethodChaining()
        {
            List<Product> products = this._database.GetAllProduct();
            List<Supplier> suppliers = this._database.GetAllSuppliers();
            QueryBuilder<Product> queryBuilder = new QueryBuilder<Product>(products);
            List<ProductSupplierName> result = queryBuilder
                .Filter(p => p.Price > 500)
                .SortBy(p => p.Price)
                .Join(suppliers, x => x.Id, s => s.ProductId, (product, supplier) => new ProductSupplierName
                {
                    ProductId = product.Id,
                    ProductName = product.ProductName,
                    ProductPrice = product.Price,
                    ProductCategory = product.Category,
                    SupplierName = supplier.SupplierName,
                }).Execute();

            ConsoleTable table = new ConsoleTable("Product Id", "Supplier Name", "Product Name", "Product Price", "Product Category");
            foreach (var productItem in result)
            {
                table.AddRow(productItem.ProductId, productItem.SupplierName, productItem.ProductName, productItem.ProductPrice, productItem.ProductCategory);
            }

            table.Options.EnableCount = false;
            table.Write();

            // Product price less than or equal to 1000
            ConsoleIO.PrintInfo("Product price less than or equal to 1000");
            List<Product> productLessThan1000 = new QueryBuilder<Product>(products)
                .Filter(p => p.Price, FilterCondition.LessThanOrEqualTo, 1000)
                .Execute();

            ConsoleTable productLessThan1000Table = new ConsoleTable("Product Id", "Product Name", "Product Price", "Product Category");
            foreach (var productItem in productLessThan1000)
            {
                productLessThan1000Table.AddRow(productItem.Id, productItem.ProductName, productItem.Price, productItem.Category);
            }

            productLessThan1000Table.Options.EnableCount = false;
            productLessThan1000Table.Write();

            // Product price more than or equal to 1000
            ConsoleIO.PrintInfo("Product price more than or equal to 1000");
            List<Product> productGreaterThan1000 = new QueryBuilder<Product>(products)
                .Filter(p => p.Price, FilterCondition.GreaterThanOrEqualTo, 1000)
                .Execute();

            ConsoleTable productGreaterThan1000Table = new ConsoleTable("Product Id", "Product Name", "Product Price", "Product Category");
            foreach (var productItem in productGreaterThan1000)
            {
                productGreaterThan1000Table.AddRow(productItem.Id, productItem.ProductName, productItem.Price, productItem.Category);
            }

            productGreaterThan1000Table.Options.EnableCount = false;
            productGreaterThan1000Table.Write();

            // Product starting with letter L
            ConsoleIO.PrintInfo("Product starting with letter L");
            List<Product> productStartingWithL = new QueryBuilder<Product>(products)
                .Filter(p => p.ProductName, FilterCondition.StartsWith, "L")
                .Execute();

            ConsoleTable productStartingWithLTable = new ConsoleTable("Product Id", "Product Name", "Product Price", "Product Category");
            foreach (var productItem in productStartingWithL)
            {
                productStartingWithLTable.AddRow(productItem.Id, productItem.ProductName, productItem.Price, productItem.Category);
            }

            productStartingWithLTable.Options.EnableCount = false;
            productStartingWithLTable.Write();

            // Product ending with letter t
            ConsoleIO.PrintInfo("Product ending with letter t");
            List<Product> productEndingWithT = new QueryBuilder<Product>(products)
                .Filter(p => p.ProductName, FilterCondition.EndsWith, "t")
                .Execute();

            ConsoleTable productEndingWithTTable = new ConsoleTable("Product Id", "Product Name", "Product Price", "Product Category");
            foreach (var productItem in productEndingWithT)
            {
                productEndingWithTTable.AddRow(productItem.Id, productItem.ProductName, productItem.Price, productItem.Category);
            }

            productEndingWithTTable.Options.EnableCount = false;
            productEndingWithTTable.Write();

            // Product containing "lap"
            ConsoleIO.PrintInfo("Product containing lap");
            List<Product> productContaining = new QueryBuilder<Product>(products)
                .Filter(p => p.ProductName, FilterCondition.Contains, "Lap")
                .Execute();

            ConsoleTable productContainingTable = new ConsoleTable("Product Id", "Product Name", "Product Price", "Product Category");
            foreach (var productItem in productContaining)
            {
                productContainingTable.AddRow(productItem.Id, productItem.ProductName, productItem.Price, productItem.Category);
            }

            productContainingTable.Options.EnableCount = false;
            productContainingTable.Write();
        }
    }
}