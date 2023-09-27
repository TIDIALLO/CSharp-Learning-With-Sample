namespace SampleJoin;
public class CrossJoinWithGroupJoinExample
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

        var q =
            from c in categories
            join p in products on c equals p.Category into ps
            from p in ps
            select new { Category = c, p.ProductName };

        foreach (var v in q)
        {
            Console.WriteLine($"{v.ProductName}: {v.Category}");
        }
    }


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

        var q =
            categories.GroupJoin(products, c => c, p => p.Category, (c, ps) => new { c, ps })
                .SelectMany(@t => @t.ps, (@t, p) => new { Category = @t.c, p.ProductName });

        foreach (var v in q)
        {
            Console.WriteLine($"{v.ProductName}: {v.Category}");
        }
    }
}
