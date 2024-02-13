
using LINQ_2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Web.Mvc;

public class ProductsController : Controller
{
    private List<Product> products;
    private  List<Inventory> inventory;


    public ProductsController()
    {
    // Initialize empty lists
        products = new List<Product>();
        inventory = new List<Inventory>();
    }

    public ProductsController(List<Product> products, List<Inventory> inventory)
    {
        products = products ?? throw new ArgumentNullException(nameof(products));
        inventory = inventory ?? throw new ArgumentNullException(nameof(inventory));

    }

    // Action to show all products
    public ActionResult Index()
    {
        // Retrieve user input from TempData
        var userInput = TempData["UserInput"] as ProductViewModel;

        // Get combined product and inventory data
        var viewModel = GetProductViewModels();

        // Add user input to the view model if available
        if (userInput != null)
        {
            viewModel.Add(userInput);
        }

        // Pass the data to the view
        return View(viewModel);
    }


    // Action to show the form to create a new product
    public ActionResult Create()
    {
        return View();
    }

    // Action to handle form submission and create a new product

    [HttpPost] 
    public ActionResult Create(Product product, int stockQuantity)
    {
        // Generate a unique ID for the new product
        product.ProductID = products.Any() ? products.Max(p => p.ProductID) + 1 : 1;

        // Add the new product to the list
        products.Add(product);

        // Add the inventory information for the new product
        inventory.Add(new Inventory { ProductID = product.ProductID, StockQuantity = stockQuantity });

        // Store user input in TempData
        TempData["UserInput"] = new ProductViewModel
        {
            ProductID = product.ProductID,
            Name = product.Name,
            Description = product.Description,
            Price = product.Price,
            StockQuantity = stockQuantity
        };

        // Redirect to the product list page
        return RedirectToAction("Index");
    }


    // Action to delete a product
  [HttpPost]  
    public ActionResult Delete(int id)
    {
        var product = products.FirstOrDefault(p => p.ProductID == id);
        if (product == null)
        {
            return HttpNotFound();
        }

        products.Remove(product);
        if (inventory.FirstOrDefault(i => i.ProductID == id) != null)
        {
            inventory.Remove(inventory.FirstOrDefault(i => i.ProductID == id));
        }

        return RedirectToAction("Index");
    }


    // Helper method to combine product and inventory data
    private List<ProductViewModel> GetProductViewModels()
    {
        var viewModel = new List<ProductViewModel>();
        foreach (var product in products)
        {
            var inventoryItem = inventory.FirstOrDefault(i => i.ProductID == product.ProductID);
            viewModel.Add(new ProductViewModel
            {
                ProductID = product.ProductID,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                StockQuantity = inventoryItem?.StockQuantity ?? 0
            });
        }
        return viewModel;
    }
}

 