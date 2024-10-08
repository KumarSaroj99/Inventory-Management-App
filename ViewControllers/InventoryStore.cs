﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryManagementSystem.Controller;
using InventoryManagementSystem.Exceptions;
using InventoryManagementSystem.Migrations;
using InventoryManagementSystem.Models;
using InventoryManagementSystem.Repository;

namespace InventoryManagementSystem.ViewControllers
{
    internal class InventoryStore
    {
    public static void DisplayMainMenu()
    {

        while (true)
        {

            Console.WriteLine("\nWelcome to Inventory Management App developed by :- Sarojkumar Panda\n" +
                "1. Product Management\n" +
                "2. Supplier Management\n" +
                "3. Transaction Management\n" +
                "4. Generate Report\n" +
                "5. Exit");
            try
            {
                int choice = Convert.ToInt32(Console.ReadLine());
                ChooseMenu(choice);

            }
            catch (DuplicateItemException de)
            {
                Console.WriteLine(de.Message);
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
    }

    static void ChooseMenu(int choice)
    {
        switch (choice)
        {
            case 1:
                ProductStore.DisplayProduct();
                break;
            case 2:
                SupplierStore.DisplaySupplier(); 
                break;
            case 3:
                TransactionStore.DisplayTransaction();
                break;
            case 4:
                Console.WriteLine("Enter inventory id to display");
                int inventoryId = Convert.ToInt32(Console.ReadLine());
                GenerateReport(inventoryId);
                break;

            case 5:
                Environment.Exit(0);
                break;
           
            default:
                throw new Exception("Please enter a valid input!");

        }
    }

   
    static void GenerateReport(int inventoryId)
    {
        InventoryManager inventoryManager = new InventoryManager(new Services.InventoryContext());
        inventoryManager.GetInventoryDetails(inventoryId);
        try
        {
            Inventory inventory = inventoryManager.GetInventoryDetails(inventoryId);
            DisplayInventory(inventory);
        }
        catch (ItemNotFoundException ie)
        {
            Console.WriteLine(ie.Message);
        }
    }
    static void DisplayInventory(Inventory inventory)
    {
        Console.WriteLine($"Inventory Id: {inventory.InventoryId}");
        Console.WriteLine($"Inventory Location: {inventory.InventoryLocation}");
        
        Console.WriteLine("\n############## Products ##############");
        if (inventory.Products != null && inventory.Products.Count > 0)
            inventory.Products.ForEach(product => Console.WriteLine(product));
        else
            throw new ItemNotFoundException("No Products in this Inventory");
       

        
        Console.WriteLine("############## Suppliers ##############");
        if (inventory.Suppliers != null && inventory.Suppliers.Count > 0)
            inventory.Suppliers.ForEach(supplier => Console.WriteLine(supplier));
        else
            throw new ItemNotFoundException("No Suppliers in this Inventory");
        

        Console.WriteLine("############## Transactions ##############");
        if (inventory.Transactions != null && inventory.Transactions.Count > 0)
            inventory.Transactions.ForEach(transaction => Console.WriteLine(transaction));
        else
            throw new ItemNotFoundException("No Transactions in this Inventory");

    }

  }
}
