using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystem.Models
{
    internal class Product
    {
        [Key]
public int ProductId {  get; set; }
public string ProductName { get; set; }

public string ProductDescription { get; set; }

public int ProductQuantity { get; set; }

public double ProductPrice { get; set; }

[ForeignKey("Inventory")]

public int? InventoryId { get; set; }
public Inventory inventory { get; set; }
public Product() { }
public Product(string name, string desc, int quantity, double price , int inventoryId)
{
    ProductName = name;
    ProductDescription = desc;
    ProductQuantity = quantity;
    ProductPrice = price;
    InventoryId = inventoryId;
}
public static Product CreateProduct(string name, string desc , int quantity , double price , int inventoryId)
{
    return new Product(name,desc , quantity , price , inventoryId);
}
public override string ToString()
{
    return $"\n=====Product Id : {ProductId}======\n" +
        $"Product Name : {ProductName}\n" +
        $"Product Desc : {ProductDescription}\n" +
        $"Product Quantiy : {ProductQuantity}\n" +
        $"Product Price : {ProductPrice}\n";

        }
    }
}
