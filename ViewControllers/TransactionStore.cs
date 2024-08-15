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
                int userChoice = Convert.ToInt32(Console.ReadLine());
                DoTask(userChoice);
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
                    MainMenu();
                    break;

            }
        }
        catch (DuplicateItemException de)
        {   
            Console.WriteLine(de.Message);
        }
        catch (InvalidIdException ie)
        {
            Console.WriteLine(ie.Message);
        }
        catch (ItemNotFoundException ie)
        {
            Console.WriteLine(ie.Message);
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
        Console.WriteLine("Enter Quantity of Stock");
        int field = Convert.ToInt32(Console.ReadLine());
        try
        {
            productManager.AddStock(id, field);
            Console.WriteLine("Stock Updated Successfully!!!!");
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

    static void Remove()
    {
        Console.WriteLine("Enter Id : ");
        int id = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter quantity of Stock");
        int field = Convert.ToInt32(Console.ReadLine());
        try
        {
            productManager.RemoveStock(id, field);
            Console.WriteLine("Stock Updated Successfully!!!!");
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
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

    static void MainMenu()
    {
        exitTransactionMenu = false;
    }

  }
}
