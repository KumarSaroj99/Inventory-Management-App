using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryManagementSystem.Exceptions;
using InventoryManagementSystem.Repository;

namespace InventoryManagementSystem.Controller
{
    internal class ProductStore
    {
        static bool exitProductMenu = true;
        static ProductManager productManager = new ProductManager(new Services.InventoryContext());
        public static void DisplayProduct()
        {
            exitProductMenu = true;

            while (exitProductMenu)
            {
                Console.WriteLine("\nProduct Management\n" +
                    "1.Add Product\n" +
                    "2.Update Product\n" +
                    "3.Delete Product\n" +
                    "4.View Product Details\n" +
                    "5.View All Product\n" +
                    "6.Back To Main Menu\n");

                try
                {
                    int choice = Convert.ToInt32(Console.ReadLine());
                    DoTask(choice);
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input.");
                }

            }
        }

        static void DoTask(int choice) {
            try
            {
               
                switch (choice)
                {
                    case 1:
                        Add();
                        break;
                    case 2:
                        Update();
                        break;
                    case 3:
                        Delete();
                        break;
                    case 4:
                        ViewDetails();
                        break;
                    case 5:
                        ViewAllDetails();
                        break;
                    case 6:
                        GoToMainMenu();
                        break;

                }
            }
            catch (DuplicateItemException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (InvalidIdException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (ItemNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input.");
            }
        }

        static void Add() {
            Console.WriteLine("Enter Product Name : ");
            string name = Console.ReadLine();
            Console.WriteLine("Enter Product Description : ");
            string description = Console.ReadLine();
            Console.WriteLine("Enter Product Quantity: ");
            int productQuantity = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Product Price: ");
            double productPrice = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter Inventory To enter : ");
            int inventoryId = Convert.ToInt32(Console.ReadLine());
            try
            {
                productManager.AddProduct(name, description, productQuantity, productPrice , inventoryId);
                Console.WriteLine("New Product Added Successfully");
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
            
           
        }

        static void Update() {
            Console.WriteLine("Enter Id : ");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Which field do you want to update ?");
            Console.WriteLine("1. Name\n2. Description \n3. Price");
            int choice = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Updated Field");
            var field = Console.ReadLine();
            try
            {
                productManager.UpdateProduct(id, choice, field);
                Console.WriteLine("Product Updated Successfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void ViewDetails() {
            Console.WriteLine("Enter Product ID or Name: ");
            int input = Convert.ToInt32(Console.ReadLine());

            try
            {
                var product = productManager.GetProductDetails(input);
                if (product != null)
                {
                    Console.WriteLine(product);
                }
                else
                {
                    Console.WriteLine("Product not found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void Delete() {
            Console.WriteLine("Enter Product ID: ");
            int id = Convert.ToInt32(Console.ReadLine());

            try
            {
                productManager.DeleteProduct(id);
                Console.WriteLine("Product Deleted Successfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void ViewAllDetails()
        {
            var products = productManager.GetAllProducts();
            foreach (var product in products)
            {
                Console.WriteLine(product);
            }
        }



        static void GoToMainMenu()
        {
            exitProductMenu = false;
        }

    }
}
