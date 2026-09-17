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
            // Get all the product
            List<Product> products = this._database.GetAllProduct();
            List<Supplier> suppliers = this._database.GetAllSuppliers();

            // Initialize query builder.
            QueryBuilder<Product> queryBuilder = new QueryBuilder<Product>(products);

            // Find products more than 500.
            List<ProductSupplierName> expensiveProductsWithSuppliers = queryBuilder
                .Filter(product => product.Price > 500)
                .SortBy(product => product.Price)
                .Join(
                    suppliers,
                    product => product.Id,
                    supplier => supplier.ProductId,
                    (product, supplier) =>
                    new ProductSupplierName
                    {
                        ProductId = product.Id,
                        ProductName = product.ProductName,
                        ProductPrice = product.Price,
                        ProductCategory = product.Category,
                        SupplierName = supplier.SupplierName,
                    })
                .Execute();

            ConsoleTable table = new ConsoleTable("Product Id", "Supplier Name", "Product Name", "Product Price", "Product Category");
            foreach (var productItem in expensiveProductsWithSuppliers)
            {
                table.AddRow(productItem.ProductId, productItem.SupplierName, productItem.ProductName, productItem.ProductPrice, productItem.ProductCategory);
            }

            table.Options.EnableCount = false;
            table.Write();

            // Product with price less than or equal to 1000
            ConsoleIO.PrintInfo("Product price less than or equal to 1000");
            List<Product> affordableProducts = new QueryBuilder<Product>(products)
                .Filter(product => product.Price, FilterCondition.LessThanOrEqualTo, 1000)
                .Execute();

            ConsoleTable affordableProductTable = new ConsoleTable("Product Id", "Product Name", "Product Price", "Product Category");
            foreach (var productItem in affordableProducts)
            {
                affordableProductTable.AddRow(productItem.Id, productItem.ProductName, productItem.Price, productItem.Category);
            }

            affordableProductTable.Options.EnableCount = false;
            affordableProductTable.Write();

            // Product with price more than or equal to 1000
            ConsoleIO.PrintInfo("Product price more than or equal to 1000");
            List<Product> expensiveProducts = new QueryBuilder<Product>(products)
                .Filter(product => product.Price, FilterCondition.GreaterThanOrEqualTo, 1000)
                .Execute();

            ConsoleTable expensiveProductsTable = new ConsoleTable("Product Id", "Product Name", "Product Price", "Product Category");
            foreach (var productItem in expensiveProducts)
            {
                expensiveProductsTable.AddRow(productItem.Id, productItem.ProductName, productItem.Price, productItem.Category);
            }

            expensiveProductsTable.Options.EnableCount = false;
            expensiveProductsTable.Write();

            // Product starting with letter L
            ConsoleIO.PrintInfo("Product starting with letter L");
            List<Product> productsStartingWithL = new QueryBuilder<Product>(products)
                .Filter(p => p.ProductName, FilterCondition.StartsWith, "L")
                .Execute();

            ConsoleTable productsStartingWithLTable = new ConsoleTable("Product Id", "Product Name", "Product Price", "Product Category");
            foreach (var productItem in productsStartingWithL)
            {
                productsStartingWithLTable.AddRow(productItem.Id, productItem.ProductName, productItem.Price, productItem.Category);
            }

            productsStartingWithLTable.Options.EnableCount = false;
            productsStartingWithLTable.Write();

            // Product ending with letter t
            ConsoleIO.PrintInfo("Product ending with letter t");
            List<Product> productsEndingWithT = new QueryBuilder<Product>(products)
                .Filter(p => p.ProductName, FilterCondition.EndsWith, "t")
                .Execute();

            ConsoleTable productEndingWithTTable = new ConsoleTable("Product Id", "Product Name", "Product Price", "Product Category");
            foreach (var productItem in productsEndingWithT)
            {
                productEndingWithTTable.AddRow(productItem.Id, productItem.ProductName, productItem.Price, productItem.Category);
            }

            productEndingWithTTable.Options.EnableCount = false;
            productEndingWithTTable.Write();

            // Product containing "lap"
            ConsoleIO.PrintInfo("Product containing lap");
            List<Product> productContainingLap = new QueryBuilder<Product>(products)
                .Filter(p => p.ProductName, FilterCondition.Contains, "Lap")
                .Execute();

            ConsoleTable productContainingTable = new ConsoleTable("Product Id", "Product Name", "Product Price", "Product Category");
            foreach (var productItem in productContainingLap)
            {
                productContainingTable.AddRow(productItem.Id, productItem.ProductName, productItem.Price, productItem.Category);
            }

            productContainingTable.Options.EnableCount = false;
            productContainingTable.Write();
        }
    }
}