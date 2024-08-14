using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryManagementSystem.Exceptions;
using InventoryManagementSystem.Models;
using InventoryManagementSystem.Services;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagementSystem.Repository
{
    internal class InventoryManager
    {
        private readonly InventoryContext _context;

        public InventoryManager(InventoryContext context)
        {
            _context = context;
        }
        public Inventory GetInventoryDetails(int inventoryId)
        {
           
            var inventory = _context.Inventories
                                    .Include(i => i.Products)
                                    .Include(i => i.Suppliers)
                                    .Include(i => i.Transactions)
                                    .FirstOrDefault(i => i.InventoryId == inventoryId);

            if (inventory == null)
            {
                throw new ItemNotFoundException("Inventory not found.");
            }

            return inventory;
        }

    }
}
