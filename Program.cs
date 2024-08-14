using InventoryManagementSystem.Controller;
using InventoryManagementSystem.Models;
using InventoryManagementSystem.Repository;
using InventoryManagementSystem.Services;
using InventoryManagementSystem.ViewControllers;

namespace InventoryManagementSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //ProductManager productManger = new ProductManager(new Services.InventoryContext());
            //SupplierManager supplierManger = new SupplierManager(new Services.InventoryContext());

            //Product product = new Product
            //{
            //    ProductId = 2,
            //    ProductName = "Bikes",
            //    ProductDescription = "Nice Bikes",
            //    ProductQuantity = 10,
            //    ProductPrice = 2100
            //};
            //productManger.UpdateProduct(product);

            //Supplier supplier = new Supplier
            //{
            // SupplierName= "Sam",
            // ContactInformation="1234567890"

            //};
            //supplierManger.AddSupplier(supplier);
            //productManger.DeleteProduct(1);
            //var products = productManger.GetProducts();
            //products.ForEach(p => Console.WriteLine(p));

            //Console.WriteLine(productManger.FindProductById(2));


            InventoryStore.DisplayMenu();

        }
    }
}
