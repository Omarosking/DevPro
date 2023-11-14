using System;
using System.Collections.Generic;
using Xunit;

public class InventoryManagementTests
{
    [Fact]
    public void SortProducts_ShouldSortByNameInAscendingOrder()
    {
        // Arrange
        List<Dictionary<string, object>> products = new List<Dictionary<string, object>>
        {
            new Dictionary<string, object> { {"name", "Product B"}, {"price", 200}, {"stock", 3} },
            new Dictionary<string, object> { {"name", "Product A"}, {"price", 100}, {"stock", 5} },
            new Dictionary<string, object> { {"name", "Product C"}, {"price", 50}, {"stock", 10} }
        };

        // Act
        List<Dictionary<string, object>> sortedProducts = InventoryManagement.SortProducts(products, "name", true);

        // Assert
        Assert.Equal("Product A", sortedProducts[0]["name"]);
        Assert.Equal("Product B", sortedProducts[1]["name"]);
        Assert.Equal("Product C", sortedProducts[2]["name"]);
    }

    [Fact]
    public void SortProducts_ShouldSortByPriceInDescendingOrder()
    {
        // Arrange
        List<Dictionary<string, object>> products = new List<Dictionary<string, object>>
        {
            new Dictionary<string, object> { {"name", "Product A"}, {"price", 100}, {"stock", 5} },
            new Dictionary<string, object> { {"name", "Product B"}, {"price", 200}, {"stock", 3} },
            new Dictionary<string, object> { {"name", "Product C"}, {"price", 50}, {"stock", 10} }
        };

        // Act
        List<Dictionary<string, object>> sortedProducts = InventoryManagement.SortProducts(products, "price", false);

        // Assert
        Assert.Equal(200, sortedProducts[0]["price"]);
        Assert.Equal(100, sortedProducts[1]["price"]);
        Assert.Equal(50, sortedProducts[2]["price"]);
    }

    [Fact]
    public void SortProducts_ShouldSortByStockInAscendingOrder()
    {
        // Arrange
        List<Dictionary<string, object>> products = new List<Dictionary<string, object>>
        {
            new Dictionary<string, object> { {"name", "Product A"}, {"price", 100}, {"stock", 5} },
            new Dictionary<string, object> { {"name", "Product B"}, {"price", 200}, {"stock", 3} },
            new Dictionary<string, object> { {"name", "Product C"}, {"price", 50}, {"stock", 10} }
        };

        // Act
        List<Dictionary<string, object>> sortedProducts = InventoryManagement.SortProducts(products, "stock", true);

        // Assert
        Assert.Equal(3, sortedProducts[0]["stock"]);
        Assert.Equal(5, sortedProducts[1]["stock"]);
        Assert.Equal(10, sortedProducts[2]["stock"]);
    }
}
