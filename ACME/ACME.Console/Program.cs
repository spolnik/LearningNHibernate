using ACME.Data;
using ACME.Model;
using ACME.Repository;

namespace ACME.Console
{
    class Program
    {
        static void Main()
        {
            SampleMethod(new ProductRepository());
        }

        private static void SampleMethod(IProductRepository productRepo)
        {
            SessionProvider.RebuildSchema();
            //Add a Unit of Measure
            var uomCrate = new UnitOfMeasure { UomDescription = "Crate" };
            productRepo.SaveUOM(uomCrate);
            //Add some categories
            var catA = new Category { CategoryName = "Metals" };
            var catB = new Category { CategoryName = "Plastics" };
            var catC = new Category { CategoryName = "Recycled Goods" };
            var catD = new Category { CategoryName = "New Materials" };

            productRepo.SaveCategory(catA);
            productRepo.SaveCategory(catB);
            productRepo.SaveCategory(catC);
            productRepo.SaveCategory(catD);

            //Add some products
            var prod01 = new Product { ProductName = "Copper Wire", UOM = uomCrate };
            var prod02 = new Product { ProductName = "Refurbished Sprockets", UOM = uomCrate };
            var prod03 = new Product { ProductName = "Plastic Housings", UOM = uomCrate };
            var prod04 = new Product { ProductName = "Used Bubble Wrap", UOM = uomCrate };
            //Assign some Categories
            prod01.Categories.Add(catA);
            prod01.Categories.Add(catD);
            prod02.Categories.Add(catA);
            prod02.Categories.Add(catC);
            prod03.Categories.Add(catB);
            prod03.Categories.Add(catD);
            prod04.Categories.Add(catB);
            prod04.Categories.Add(catC);
            //Persist our objects
            productRepo.Save(prod01);
            productRepo.Save(prod02);
            productRepo.Save(prod03);
            productRepo.Save(prod04);

            var prodTemp = productRepo.GetById(prod01.ProductId);
            prodTemp.Categories.RemoveAt(0);

            System.Console.WriteLine("Press any key to continue...");
            System.Console.Read();
        }
    }
}
