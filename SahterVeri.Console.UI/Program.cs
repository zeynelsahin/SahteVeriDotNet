// See https://aka.ms/new-console-template for more information

using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using Bogus;

Console.WriteLine("Hello, World!");

var category = new Faker<Category>("tr").RuleFor(i => i.CategoryId, i => i.Random.Guid()).RuleFor(i => i.CategoryName, i => i.Person.Random.String(5, 13)).Generate(1);

var product = new Faker<Product>("tr").RuleFor(i => i.Discontinued, i => i.Random.Bool()).RuleFor(i=>i.CategoryId,category[0].CategoryId).RuleFor(i=>i.ProductId,i=>i.Random.Guid()).RuleFor(i=>i.ProductName,i=>i.Commerce.ProductName()).RuleFor(i=>i.Discontinued,i=>i.Random.Bool()).RuleFor(i=>i.SupplierId,i=>i.Random.Int()).RuleFor(i=>i.UnitPrice,i=>i.Random.Int()).RuleFor(i=>i.UnitsInStock,i=>i.Random.Short()).RuleFor(i=>i.UnitsOnOrder,i=>i.Random.Short());
var generatedObject = product.Generate(10);

var options = new JsonSerializerOptions()
{
    WriteIndented = true,
    Encoder = JavaScriptEncoder.Create(UnicodeRanges.All)
};

var json = JsonSerializer.Serialize(generatedObject,options);

Console.WriteLine(json);

var deger = 1;
class Product
{
    public Guid ProductId { get; set; }
    public string ProductName { get; set; }
    public int SupplierId { get; set; }
    public Guid CategoryId { get; set; }
    public string QuantityPerUnit { get; set; }
    public decimal UnitPrice { get; set; }
    public short UnitsInStock { get; set; }
    public short UnitsOnOrder { get; set; }

    public bool Discontinued { get; set; }
}

class Category
{
    public Guid CategoryId { get; set; }
    public string CategoryName { get; set; }
}