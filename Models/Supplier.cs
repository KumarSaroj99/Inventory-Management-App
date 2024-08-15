﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystem.Models
{
    internal class Supplier
    {
    [Key]
    public int SupplierId { get; set; }
    public string SupplierName { get; set; }
    public string ContactInformation {  get; set; }

    [ForeignKey("Inventory")]
    public int? InventoryId { get; set; }
 
    public Inventory inventory { get; set; }

    public Supplier()
    {
        
    }

    public Supplier(string supplierName , string contactInfo , int inventoryId)
    {
        SupplierName = supplierName;
        ContactInformation = contactInfo;
        InventoryId = inventoryId;
    }
    public static Supplier CreateSupplier(string supplierName, string contactInfo , int inventoryId)
    {
        return new Supplier(supplierName,contactInfo , inventoryId);
    }
    public override string ToString()
    {
        return $"\n=====SupplierId : {SupplierId}======\n" +
            $"Supplier Name : {SupplierName}\n" +
            $"Supplier Contact : {ContactInformation}\n";
    }
  }
}
