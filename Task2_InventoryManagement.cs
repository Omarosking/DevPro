using System;
using System.Collections.Generic;
using System.Linq;

class InventoryManagement
{
    public static List<Dictionary<string, object>> SortProducts(List<Dictionary<string, object>> products, string sortKey, bool ascending)
    {
        switch (sortKey.ToLower())
        {
            case "name":
                products = ascending ? products.OrderBy(p => p["name"]).ToList() : products.OrderByDescending(p => p["name"]).ToList();
                break;
            case "price":
                products = ascending ? products.OrderBy(p => p["price"]).ToList() : products.OrderByDescending(p => p["price"]).ToList();
                break;
            case "stock":
                products = ascending ? products.OrderBy(p => p["stock"]).ToList() : products.OrderByDescending(p => p["stock"]).ToList();
                break;
            default:
                throw new ArgumentException("Invalid sort key");
        }

        return products;
    }
}

class Program
{
    static void Main()
    {
        List<Dictionary<string, object>> products = new List<Dictionary<string, object>>
        {
            new Dictionary<string, object> { {"name", "Product A"}, {"price", 100}, {"stock", 5} },
            new Dictionary<string, object> { {"name", "Product B"}, {"price", 200}, {"stock", 3} },
            new Dictionary<string, object> { {"name", "Product C"}, {"price", 50}, {"stock", 10} }
        };

        string sortKey = "price";
        bool ascending = false;

        List<Dictionary<string, object>> sortedProducts = InventoryManagement.SortProducts(products, sortKey, ascending);

        foreach (var product in sortedProducts)
        {
            Console.WriteLine($"Name: {product["name"]}, Price: {product["price"]}, Stock: {product["stock"]}");
        }
    }
}
