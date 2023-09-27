namespace SampleJoin;

public class GroupJoinExample
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
           select new { Category = c, Products = ps };

        foreach (var g in q)
        {
            Console.WriteLine($"Category :=>: {g.Category}");
            foreach (var p in g.Products)
            {
                Console.WriteLine(p.ProductName);
            }
            Console.WriteLine("+++++++++++");

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

        var q = categories.GroupJoin(products, c => c, p => p.Category, (c, ps) => new { Category = c, Products = ps });


        foreach (var v in q)
        {
            Console.WriteLine($"{v.Category}   <====>");
            foreach (var p in v.Products)
            {
                Console.WriteLine($"   {p.ProductName}");
            }
        }

    }
}
