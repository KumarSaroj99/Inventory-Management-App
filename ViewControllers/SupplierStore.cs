using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryManagementSystem.Exceptions;
using InventoryManagementSystem.Repository;

namespace InventoryManagementSystem.Controller
{
    internal class SupplierStore
    {
    static bool exitSupplierMenu = true;
    static SupplierManager supplierManager = new SupplierManager(new Services.InventoryContext());
    public static void DisplaySupplier()
    {
        exitSupplierMenu = true;

        while (exitSupplierMenu)
        {
            Console.WriteLine("Supplier Management\n" +
                "1.Add Supplier\n" +
                "2.Update Supplier\n" +
                "3.Delete Supplier\n" +
                "4.View Supplier Details\n" +
                "5.View All Suppliers\n" +
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
                    MainMenu();
                    break;

            }
        }
        catch (DuplicateItemException e)
        {
            Console.WriteLine(e.Message);
        }
        catch (InvalidIdException e)
        {
            Console.WriteLine(e.Message);
        }
        catch(ItemNotFoundException e)
        {
            Console.WriteLine(e.Message);
        }
        catch (FormatException)
        {
            Console.WriteLine("Invalid input.");
        }
    }

    static void Add()
    {
        Console.WriteLine("Enter Supplier Name : ");
        string name = Console.ReadLine();
        Console.WriteLine("Enter Supplier Contact Information : ");
        string contact = Console.ReadLine();
        Console.WriteLine("Enter Inventory Id : ");
        int inventoryId = Convert.ToInt32(Console.ReadLine());
        supplierManager.AddSupplier(
            name, 
            contact,
            inventoryId);
        Console.WriteLine("New Supplier Added Successfully!!");
    }
    static void Update()
    {
        Console.WriteLine("Enter Id : ");
        int id = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Which field do you want to update ?");
        Console.WriteLine("1. Name\n" +
            "2. Contact Information");
        int choice = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter Updated Field");
        var field = Console.ReadLine();
        try
        {
            supplierManager.UpdateSupplier(id, choice, field);
            Console.WriteLine("Supplier Updated Successfully");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    static void ViewDetails()
    {
        Console.WriteLine("Enter Supplier Id ");
        int input = Convert.ToInt32(Console.ReadLine());

        try
        {
            var supplier = supplierManager.GetSupplierDetails(input);
            if (supplier != null)
            {
                Console.WriteLine(supplier);
            }
            else
            {
                Console.WriteLine("Supplier not found.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    static void Delete()
    {
        Console.WriteLine("Enter Supplier ID: ");
        int id = Convert.ToInt32(Console.ReadLine());

        try
        {
            supplierManager.DeleteSupplier(id);
            Console.WriteLine("Supplier Deleted Successfully");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
    public static void ViewAllDetails()
    {
        var suppliers = supplierManager.GetAllSuppliers();
        foreach (var supplier in suppliers)
        {
            Console.WriteLine(supplier);
        }
    }

    static void MainMenu()
    {
        exitSupplierMenu = false;
    }


  }
}
