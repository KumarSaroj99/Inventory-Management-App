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
    internal class ProductManager
    {
        List<Supplier> products = new List<Supplier>();
        List<Transaction> transactions = new List<Transaction>();

        private readonly InventoryContext _context;

        public ProductManager(InventoryContext context)
        {
            _context = context;
        }

        public void AddProduct(string name , string desc , int quantity , double price , int inventoryId)
        {
            if (IsProductNameExists(name))
            {
                throw new DuplicateItemException("Product name already exists. Please use a different name.");
            }

            Product product = Product.CreateProduct(name , desc , quantity , price , inventoryId);
            _context.Products.Add(product);
            _context.SaveChanges();
        }

        public void DeleteProduct(int id)
        {
            var product = FindProductById(id);
            if (product == null)
            {
                throw new ItemNotFoundException("Product not found.");
            }

            _context.Products.Remove(product);
            _context.SaveChanges();
        }

        public Product FindProductById(int id)
        {
            try
            {
               
                var findProduct = _context.Products.Where(x => x.ProductId == id).FirstOrDefault();
                if (findProduct == null)
                {
                    throw new ItemNotFoundException("Product not found");
                }
                return findProduct;
            }
            catch
            {
                throw new InvalidIdException("Invalid Id");
            }
        }

        public List<Product> GetProducts() { 
            return _context.Products.ToList();
        }

        public bool IsProductNameExists(string name)
        {
            return _context.Products.Any(p => p.ProductName == name);
        }

        public void UpdateProduct(int id, int fieldChoice, string newValue)
        {

            var product = FindProductById(id);
            if (product == null)
            {
                throw new ItemNotFoundException("Product not found.");
            }
            switch (fieldChoice)
            {
                case 1:
                    if (IsProductNameExists(newValue))
                    {
                        throw new DuplicateItemException("Product name already exists. Please use a different name.");
                    }
                    product.ProductName = newValue;
                    break;
                case 2:
                    product.ProductDescription = newValue;
                    break;
                case 3:
                    if (double.TryParse(newValue, out double price))
                    {
                        product.ProductPrice = price;
                    }
                    else
                    {
                        throw new FormatException("Invalid price value.");
                    }
                    break;
                default:
                    throw new Exception("Invalid field choice.");
            }

            _context.Products.Update(product);
            _context.SaveChanges();
        }

        public void AddStock(int id, int newValue)
        {
            var product = FindProductById(id);
            if (product == null)
            {
                throw new ItemNotFoundException("Product not found.");
            }
            product.ProductQuantity += newValue;
            _context.Products.Update(product);
            
            Transaction transaction = Transaction.CreateTransaction(id, "Stock Added", newValue ,(int)product.InventoryId);
            _context.Transactions.Add(transaction);
            _context.SaveChanges();

        }

        public void RemoveStock(int id, int newValue)
        {
            var product = FindProductById(id);
            if (product == null)
            {
                throw new ItemNotFoundException("Product not found.");
            }
            product.ProductQuantity -= newValue;
            _context.Products.Update(product);
            Transaction transaction = Transaction.CreateTransaction(id, "Stock Removed", newValue , (int)product.InventoryId);
            _context.Transactions.Add(transaction);
            _context.SaveChanges();
        }

        public Product GetProductDetails(int id)
        {
            return _context.Products.FirstOrDefault(p => p.ProductId == id);

        }

        public List<Product> GetAllProducts()
        {
            return _context.Products.ToList();
        }

        public List<Transaction> GetTransactions()
        {
            return _context.Transactions.ToList();
        }


    }
}
