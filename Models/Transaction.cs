using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystem.Models
{
    internal class Transaction
 {
    [Key]
    public int TransactionId { get; set; }
    public int ProductId { get; set; }
    public string TransactionType { get; set; }
    public int TransactionQuantity { get; set; }
    public DateTime TransactionDate { get; set; }

    [ForeignKey("Inventory")]
    public int? InventoryId { get; set; }
    public Inventory inventory { get; set; }

    public Transaction()
    {
        
    }

    public Transaction(int productid , string type , int quantity , DateTime date , int inventoryId)
    {
        ProductId = productid;
        TransactionType = type;
        TransactionQuantity = quantity;
        TransactionDate = date;
        InventoryId = inventoryId;

    }

    public static Transaction CreateTransaction(int productId, string type , int quantity , int inventoryId)
    {
        return new Transaction(productId , type , quantity , DateTime.Now , inventoryId);
    }

    public override string ToString() { 
        return $"\n=====Transaction Id : {TransactionId}======\n" +
            $"Product Id : {ProductId}\n" +
            $"Transaction Type : {TransactionType} \n" +
            $"Transaction Quantity : {TransactionQuantity}\n" +
            $"Transaction Date : {TransactionDate}\n";
    }
  }
}
