using Microsoft.EntityFrameworkCore;
// To use CollectionEntry.
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Northwind.EntityModels;

partial class Program
{
    private static void QueryingCategories()
    {
        using NorthwindDb db = new();
        SectionTitle("Categories and how many products they have");

        // This is a query definition. It doesn't execute until we enumerate it.
        IQueryable<Category>? categories; // = db.Categories; //?.Include(c => c.Products);
        db.ChangeTracker.LazyLoadingEnabled = false;

        WriteLine("Enable eager loading? (y/n): ");
        bool eagerLoading = (ReadKey().Key == ConsoleKey.Y);
        bool explicitLoading = false;
        WriteLine();
        if (eagerLoading)
        {
            categories = db.Categories?.Include(c => c.Products);
        }
        else
        {
            categories = db.Categories;
            WriteLine("Enable explicit loading? (y/n): ");
            explicitLoading = (ReadKey().Key == ConsoleKey.Y);
            WriteLine();
        }
        if (categories is null || !categories.Any())
        {
            Fail("No categories found.");
            return;
        }

        // Enumerating the query converts it to SQL and executes it against the database.
        foreach (Category c in categories)
        {
            if (explicitLoading)
            {
                Write($"Explicitly load products for {c.CategoryName}? (y/n): ");
                ConsoleKeyInfo key = ReadKey();
                WriteLine();
                if (key.Key == ConsoleKey.Y)
                {
                    CollectionEntry<Category, Product> products = db.Entry(c)
                        .Collection(c2 => c2.Products);
                    if (!products.IsLoaded)
                    {
                        products.Load();
                    }
                }
            }
            WriteLine($"{c.CategoryName} has {c.Products.Count} products.");
        }
    }

    private static void FilteredIncludes()
    {
        using NorthwindDb db = new();
        SectionTitle("Products with a minimum number of units in stock");
        string? input;
        int stock;
        do
        {
            Write("Enter minimum units in stock: ");
            input = ReadLine();
        } while (!int.TryParse(input, out stock));
        IQueryable<Category>? categories = db.Categories?.Include(c =>
            c.Products.Where(p => p.Stock >= stock)
        );
        if (categories is null || !categories.Any())
        {
            Fail("No categories found.");
            return;
        }
        Info($"ToQueryString: {categories.ToQueryString()}");
        foreach (Category c in categories)
        {
            WriteLine(
                "{0} has {1} products with at least {2} units in stock.",
                c.CategoryName,
                c.Products.Count,
                stock
            );
            foreach (Product p in c.Products)
            {
                WriteLine($"\t{p.ProductName} has {p.Stock} units in stock.");
            }
        }
    }

    private static void QueryingProducts()
    {
        using NorthwindDb db = new();
        SectionTitle("Products that cost more than a specified amount");
        string? input;
        decimal price;
        do
        {
            Write("Enter minimum price: ");
            input = ReadLine();
        } while (!decimal.TryParse(input, out price));
        IQueryable<Product>? products = db
            .Products?.TagWith("Products filtered by price and sorted.")
            .Where(p => p.Cost >= price)
            .OrderByDescending(p => p.Cost);
        if (products is null || !products.Any())
        {
            Fail("No products found.");
            return;
        }
        Info($"ToQueryString: {products.ToQueryString()}");
        foreach (Product p in products)
        {
            WriteLine(
                "{0}: {1} costs {2:$#,##0.00} and has {3} units in stock.",
                p.ProductId,
                p.ProductName,
                p.Cost,
                p.Stock
            );
        }
    }

    private static void GettingOneProduct()
    {
        using NorthwindDb db = new();
        WriteLine("Getting a single product by ID.");
        string? input;
        int id;
        do
        {
            Write("Enter product ID: ");
            input = ReadLine();
        } while (!int.TryParse(input, out id));
        Product? product = db.Products?.First(p => p.ProductId == id);
        Info($"First: {product?.ProductName}");
        if (product is null)
        {
            Fail("No product was found using .First().");
        }
        product = db.Products?.Single(product => product.ProductId == id);
        Info($"Single: {product?.ProductName}");
        if (product is null)
        {
            Fail("No product was found using .Single().");
        }
    }

    private static void QueryingWithLike()
    {
        using NorthwindDb db = new();
        SectionTitle("Pattern matching with LIKE");
        Write("Enter part of a product name: ");
        string? input = ReadLine();
        if (string.IsNullOrEmpty(input))
        {
            Fail("You did not enter part of a product name.");
            return;
        }
        IQueryable<Product>? products = db.Products?.Where(p =>
            EF.Functions.Like(p.ProductName, $"%{input}%")
        );
        if (products is null || !products.Any())
        {
            Fail("No products found.");
            return;
        }
        foreach (Product p in products)
        {
            WriteLine(
                "{0} has {1} units in stock. Discontinued: {2}",
                p.ProductName,
                p.Stock,
                p.Discontinued
            );
        }
    }

    private static void Take10RandomProducts()
    {
        using NorthwindDb db = new();
        SectionTitle("Take 10 random products");
        IQueryable<Product>? products = db.Products?.OrderBy(p => EF.Functions.Random()).Take(10);
        if (products is null || !products.Any())
        {
            Fail("No products found.");
            return;
        }
        foreach (Product p in products)
        {
            WriteLine(
                "{0} has {1} units in stock. Discontinued: {2}",
                p.ProductName,
                p.Stock,
                p.Discontinued
            );
        }
    }

    private static void GetProductUsingSql()
    {
        using NorthwindDb db = new();
        SectionTitle("Get product using SQL");
        int? rowCount = db.Products?.Count();
        if (rowCount is null)
        {
            Fail("Product table is empty.");
            return;
        }
        int productId = 1;
        Product? p = db
            .Products?.FromSql($"SELECT * FROM Products WHERE ProductId = {productId}")
            .FirstOrDefault();
        if (p is null)
        {
            Fail($"No product found with ID {productId}.");
            return;
        }
        WriteLine($"Product: {p.ProductId} - {p.ProductName}");
    }
}
