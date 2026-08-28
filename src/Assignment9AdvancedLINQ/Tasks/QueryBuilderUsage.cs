using Assignment9AdvancedLINQ.Models;
using Assignment9AdvancedLINQ.Models.DTO;
using Assignment9AdvancedLINQ.Repository;
using ConsoleTables;

namespace Assignment9AdvancedLINQ.Tasks
{
    /// <summary>
    /// Query builder method
    /// </summary>
    public class QueryBuilderUsage
    {
        private readonly Database _database;

        /// <summary>
        /// Initializes a new instance of the <see cref="QueryBuilderUsage"/> class.
        /// </summary>
        /// <param name="database">Instance of the database</param>
        public QueryBuilderUsage(Database database)
        {
            this._database = database;
        }

        /// <summary>
        /// Sort the list
        /// </summary>
        public void SortList()
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
        }
    }
}
