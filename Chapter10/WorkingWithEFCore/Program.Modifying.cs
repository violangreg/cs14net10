using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Storage;
using Northwind.EntityModels;

partial class Program
{
    public static void ListProducts(int[]? productIdsToHighlight = null)
    {
        using NorthwindDb db = new();

        if (db.Products is null || !db.Products.Any())
        {
            Fail("No products found.");
            return;
        }

        WriteLine(
            "| {0,-3} | {1,-35} | {2,8} | {3,5} | {4} |",
            "Id",
            "Product Name",
            "Cost",
            "Stock",
            "Disc"
        );

        foreach (Product p in db.Products)
        {
            ConsoleColor previousColor = ForegroundColor;

            if (productIdsToHighlight is not null && productIdsToHighlight.Contains(p.ProductId))
            {
                ForegroundColor = ConsoleColor.Green;
            }

            WriteLine(
                "| {0:000} | {1,-35} | {2,8:$#,##0.00} | {3,5} | {4} |",
                p.ProductId,
                p.ProductName,
                p.Cost,
                p.Stock,
                p.Discontinued
            );

            ForegroundColor = previousColor;
        }
    }

    private static (int affected, int productId) AddProduct(
        int categoryId,
        string productName,
        decimal? price,
        short? stock
    )
    {
        using NorthwindDb db = new();

        if (db.Products is null)
            return (0, 0);

        Product p = new()
        {
            CategoryId = categoryId,
            ProductName = productName,
            Cost = price,
            Stock = stock,
        };

        // Set product as added in the change tracking.
        EntityEntry<Product> entity = db.Products.Add(p);

        // Alternatively, call Add<Product> on the data context.
        // EntityEntry<Product> entity = db.Add(p);

        WriteLine($"State: {entity.State}, ProductId: {p.ProductId}");

        // Save tracked change to database
        int affected = db.SaveChanges();
        WriteLine($"State: {entity.State}, ProductId: {p.ProductId}");
        return (affected, p.ProductId);
    }

    private static (int affected, int productId) IncreaseProductPrice(
        string productNameStartsWith,
        decimal amount
    )
    {
        using NorthwindDb db = new();

        if (db.Products is null)
            return (0, 0);

        Product? updateProduct = db.Products?.FirstOrDefault(p =>
            p.ProductName.StartsWith(productNameStartsWith)
        );
        if (updateProduct is null)
        {
            Fail("No product found.");
            return (0, 0);
        }

        updateProduct.Cost += amount;

        int affected = db.SaveChanges();
        return (affected, updateProduct.ProductId);
    }

    private static int DeleteProducts(string productNameStartsWith)
    {
        using (NorthwindDb db = new())
        {
            using (IDbContextTransaction t = db.Database.BeginTransaction())
            {
                WriteLine("Transaction isolation level: {0}", t.GetDbTransaction().IsolationLevel);
                IQueryable<Product>? products = db.Products?.Where(p =>
                    p.ProductName.StartsWith(productNameStartsWith)
                );

                if (products is null || !products.Any())
                {
                    Fail("No products found.");
                    return 0;
                }
                else
                {
                    if (db.Products is null)
                        return 0;
                    db.Products.RemoveRange(products);
                }

                int affected = db.SaveChanges();
                t.Commit();
                return affected;
            }
        }
    }

    private static (int affected, int[]? products) IncreaseProductPricesBetter(
        string productNameStartsWith,
        decimal amount
    )
    {
        using NorthwindDb db = new();

        if (db.Products is null)
            return (0, null);

        IQueryable<Product>? products = db.Products.Where(p =>
            p.ProductName.StartsWith(productNameStartsWith)
        );

        int affected = products.ExecuteUpdate(s =>
            s.SetProperty(p => p.Cost, p => p.Cost + amount)
        );

        int[] productIds = products.Select(p => p.ProductId).ToArray();
        return (affected, productIds);
    }

    private static int DeleteProductsBetter(string productNameStartsWith)
    {
        using NorthwindDb db = new();

        int affected = 0;

        IQueryable<Product>? products = db.Products?.Where(p =>
            p.ProductName.StartsWith(productNameStartsWith)
        );

        if (products is null || !products.Any())
        {
            Fail("No products found.");
            return 0;
        }
        else
        {
            affected = products.ExecuteDelete();
        }

        return affected;
    }
}
