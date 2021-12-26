using DBFirst.Console.Data;

using (var db = new NorthwindContext())
{
    foreach (var produto in db.Products.Take(5))
    {
        Console.WriteLine($"{produto.ProductName}\t{produto.UnitPrice}");
    }
}
