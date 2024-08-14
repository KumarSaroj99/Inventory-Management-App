using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryManagementSystem.Exceptions;
using InventoryManagementSystem.Models;
using InventoryManagementSystem.Services;

namespace InventoryManagementSystem.Repository
{
    internal class SupplierManager
    {
        List<Supplier> suppliers = new List<Supplier>();

        private readonly InventoryContext _context;

        public SupplierManager(InventoryContext context)
        {
            _context = context;
        }


        public void AddSupplier(string name , string description , int inventoryId)
        {
            if (IsSupplierNameExists(name))
            {
                throw new DuplicateItemException("Supplier name already exists. Please use a different name.");
            }
            Supplier supplier = new Supplier(name,description , inventoryId);
            _context.Suppliers.Add(supplier);
            _context.SaveChanges();
        }

        public void DeleteSupplier(int id)
        {
            
            var supplier = FindSupplierById(id);
            if (supplier == null)
            {
                throw new ItemNotFoundException("Supplier not found.");      
            }
            _context.Suppliers.Remove(supplier);
            _context.SaveChanges();

        }

        public Supplier FindSupplierById(int id)
        {
            try
            {

                var findSupplier = _context.Suppliers.Where(x => x.SupplierId == id).FirstOrDefault();
                if (findSupplier == null)
                {
                    throw new ItemNotFoundException("Supplier not found");
                }
                return findSupplier;
            }
            catch 
            {
                throw new InvalidIdException("Invalid Id");
            }
        }

        public List<Supplier> GetAllSuppliers()
        {
            return _context.Suppliers.ToList();
        }


        public bool IsSupplierNameExists(string name)
        {
            return _context.Suppliers.Any(p => p.SupplierName == name);
        }

        public void UpdateSupplier(int id, int fieldChoice, string newValue)
        {

            var supplier = FindSupplierById(id);
            if (supplier == null)
            {
                throw new ItemNotFoundException("Supplier not found.");
            }
            switch (fieldChoice)
            {
                case 1:
                    if (IsSupplierNameExists(newValue))
                    {
                        throw new DuplicateItemException("Supplier name already exists. Please use a different name.");
                    }
                    supplier.SupplierName = newValue;
                    break;
                case 2:
                    supplier.ContactInformation = newValue;
                    break;
              
                default:
                    throw new Exception("Invalid field choice.");
            }

            _context.Suppliers.Update(supplier);
            _context.SaveChanges();
        }

        public Supplier GetSupplierDetails(int id)
        {
            
            return _context.Suppliers.FirstOrDefault(p => p.SupplierId == id);

        }

    }
}
