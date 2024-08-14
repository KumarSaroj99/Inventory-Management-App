using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryManagementSystem.Exceptions;
using InventoryManagementSystem.Models;
using InventoryManagementSystem.Repository;

namespace InventoryManagementSystem.ViewControllers
{
    internal class TransactionStore
    {
        static bool exitTransactionMenu = true;
        static ProductManager productManager = new ProductManager(new Services.InventoryContext());
        public static void DisplayTransaction()
        {
            exitTransactionMenu = true;

            while (exitTransactionMenu)
            {
                Console.WriteLine("Transaction Management\n" +
                    "1.Add Stock\n" +
                    "2.Remove Stock\n" +
                    "3.View Transactions\n" +
                    "4.Back To Main Menu\n");

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

        static void DoTask(int choice)
        {
            try
            {
                
                switch (choice)
                {
                    case 1:
                        Add();
                        break;
                    case 2:
                        Remove();
                        break;
                    case 3:
                        ViewTransactions();
                        break;
                    case 4:
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

        static void Add()
        {
            Console.WriteLine("Enter Id : ");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Amount of Stock");
            int field = Convert.ToInt32(Console.ReadLine());
            try
            {
                productManager.AddStock(id, field);
                Console.WriteLine("Stock Updated Successfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void Remove()
        {
            Console.WriteLine("Enter Id : ");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Amount of Stock");
            int field = Convert.ToInt32(Console.ReadLine());
            try
            {
                productManager.RemoveStock(id, field);
                Console.WriteLine("Stock Updated Successfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void ViewTransactions()
        {
            var transactions = productManager.GetTransactions();
            foreach (var transaction in transactions)
            {
                Console.WriteLine(transaction);
            }
        }

        static void GoToMainMenu()
        {
            exitTransactionMenu = false;
        }

    }
}
