using System.Text.Json;
using System.Text.Json.Schema;
using Microsoft.AspNetCore.JsonPatch.SystemTextJson;
using Northwind.EntityModels;
using FastJson = System.Text.Json.JsonSerializer;

List<Category> categories = await QueryCategories();

if (categories is null)
{
    WriteLine("No categories found");
    return;
}

// foreach (var category in categories)
// {
//     WriteLine("{0} has {1} many products", category.CategoryName, category.Products.Count);
// }

//// Writing/serializing object to a json file
// var options = new JsonSerializerOptions
// {
//     WriteIndented = true,
//     ReferenceHandler = ReferenceHandler.IgnoreCycles,
// };
// string json = JsonSerializer.Serialize(categories, options);
// await File.WriteAllTextAsync("categories.json", json);

// WriteLine("Serialize complete");

// long fileSize = new FileInfo("categories.json").Length;

// WriteLine($"File size: {fileSize} bytes");

// Deserializing json to an object
await using (FileStream jsonLoad = File.Open("categories.json", FileMode.Open))
{
    List<Category>? loadedCategories =
        await JsonSerializer.DeserializeAsync(
            utf8Json: jsonLoad,
            returnType: typeof(List<Category>)
        ) as List<Category>;

    if (loadedCategories is not null)
    {
        foreach (var category in loadedCategories)
        {
            WriteLine("{0} has {1} products", category.CategoryName, category.Products.Count);
        }
    }

    WriteLine(
        JsonSchemaExporter.GetJsonSchemaAsNode(JsonSerializerOptions.Default, typeof(Category))
    );
}

