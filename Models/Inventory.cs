using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystem.Models
{
    internal class Inventory
    {
        [Key]
        public int InventoryId { get; set; }
        public string InventoryLocation { get; set; } 
        public List<Product> Products { get; set; }
        public List<Supplier> Suppliers { get; set; }
        public List<Transaction> Transactions { get; set; }


    }
}
