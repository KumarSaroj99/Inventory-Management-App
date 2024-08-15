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
                                .Include(item => item.Products)
                                .Include(item => item.Suppliers)
                                .Include(item => item.Transactions)
                                .FirstOrDefault(item => item.InventoryId == inventoryId);

        if (inventory == null)
        {
            throw new ItemNotFoundException("Inventory can not found.");
        }

        return inventory;
    }

  }
}
