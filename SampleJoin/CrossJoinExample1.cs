namespace SampleJoin;

public static class CrossJoinExample1
{
    public static void QuerySyntaxExample()
    {
        string[] categories = new string[]
        {
            "Beverages",
            "Condiments",
            "Vegetables",
            "Dairy Products",
            "Seafood"
        };

        List<Product> products = Data.Products;
        //Query syntax example
        var q =
            from c in categories
            join p in products on c equals p.Category
            select new { Category = c, p.ProductName };

        foreach (var v in q)
        {
            Console.WriteLine($"{v.ProductName}::::::: {v.Category}");
        }
        //================================================================
        //Query syntax example
        var qm = categories.Join(
            products,
            c => c,
            p => p.Category,
            (c, p) => new { Category = c, p.ProductName }
        );
        foreach (var v in q)
        {
            Console.WriteLine($"{v.ProductName}::::::: {v.Category}");
        }
    }

        //================================================================
        //Query syntax example
        public static void MethodSyntaxExample()
    {
        string[] categories = new string[]
        {
            "Beverages",
            "Condiments",
            "Vegetables",
            "Dairy Products",
            "Seafood"
        };

        List<Product> products = Data.Products;

        var q = categories.Join(products, c => c, p => p.Category, (c, p) => new { Category = c, p.ProductName });

        // var qm = categories.Join(
        //     products,
        //     c => c,
        //     p => p.Category,
        //     (c, p) => new { Category = c, p.ProductName }
        // );
        foreach (var v in q)
        {
            Console.WriteLine($"{v.ProductName}::::::: {v.Category}");
        }
    }
}
