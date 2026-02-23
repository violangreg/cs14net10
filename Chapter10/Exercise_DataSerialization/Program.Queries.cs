using Microsoft.EntityFrameworkCore;
using Northwind.EntityModels;

partial class Program
{
    private static async Task<List<Category>> QueryCategories()
    {
        using NorthwindDb db = new NorthwindDb();

        // already returns an empty list if it is null
        // category is never null, db checks for in DbSet
        return await db.Categories.Include(c => c.Products).ToListAsync();
    }
}
