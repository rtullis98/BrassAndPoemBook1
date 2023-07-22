
//create a "products" variable here to include at least five Product instances. Give them appropriate ProductTypeIds.

using System.Xml;
using System.Linq;
using System.Collections.Generic;

List<Product> products = new List<Product>()
{
    new Product()
    {
        Name = "Tuba",
        Price = 899.99M,
        ProductTypeId = 1
    },
    new Product()
    {
        Name = "Trombone",
        Price = 655.00M,
        ProductTypeId = 1
    },
    new Product()
    {
        Name = "The Balloon Man",
        Price = 2.00M,
        ProductTypeId = 2
    },
    new Product()
    {
        Name = "The Rime of the Ancient Mariner",
        Price = 6.99M,
        ProductTypeId = 2
    },
    new Product()
    {
        Name = "Horse Latitudes",
        Price = 3.99M,
        ProductTypeId = 2
    }
};

//create a "productTypes" variable here with a List of ProductTypes, and add "Brass" and "Poem" types to the List. 

List<ProductType> productTypes = new List<ProductType>()
{
    new ProductType()
    {
        Title = "Brass",
        Id = 1,
    },
    new ProductType()
    {
        Title = "Poem",
        Id = 2,
    }
};

//put your greeting here

Console.WriteLine("Welcome to B&P Inc. Check out some of our amazing products!");


//implement your loop here

string choice = null;
while (choice != "5")
{
    DisplayMenu();
    choice = Console.ReadLine();

    if (choice == "1")
    {
        DisplayAllProducts(products, productTypes);
    }
    else if (choice == "2")
    {
        DeleteProduct(products, productTypes);
    }
    else if (choice == "3")
    {
        AddProduct(products, productTypes);
    }
    else if (choice == "4")
    {
        UpdateProduct(products, productTypes);
    }
    else if (choice == "5")
    {
        Console.WriteLine("Goodbye, we hope to see you again!");
    }
}

//main menu 
void DisplayMenu()
{
    Console.WriteLine(@"Main Menu:
1. Display all products
2. Delete a product
3. Create a product
4. Update a product
5. Exit");
}

//menu commands
void DisplayAllProducts(List<Product> products, List<ProductType> productTypes)
{
    for (int i = 0; i < products.Count; i++)
    {
        Product product = products[i];
        ProductType productType = productTypes.FirstOrDefault(pt => pt.Id == product.ProductTypeId);
        Console.WriteLine($"{i + 1}. {product.Name}, Product type: {productType.Id}");
    }
}

void DeleteProduct(List<Product> products, List<ProductType> productTypes)
{
    for (int i = 0; i < products.Count; i++)
    {
        Product product = products[i];
        ProductType productType = productTypes.FirstOrDefault(pt => pt.Id == product.ProductTypeId);
        Console.WriteLine($"{i + 1}. {product.Name}, Product type: {productType.Id}");
    }
    int response = int.Parse(Console.ReadLine().Trim());

    if (response >= 1 && response <= products.Count)
    {
        products.RemoveAt(response - 1);
        Console.WriteLine("Product deleted");
    }
}

void AddProduct(List<Product> products, List<ProductType> productTypes)
{
    Console.WriteLine("Name: ");

    string Name = Console.ReadLine();

    Console.WriteLine("Price: ");

    decimal Price = decimal.Parse(Console.ReadLine());

    Console.WriteLine("Choose your product type: 1. Brass, 2. Poem");

    int Id = int.Parse(Console.ReadLine());

    Product newProduct = new Product
    {
        Name = Name,
        Price = Price,
        ProductTypeId = Id,
    };
    products.Add(newProduct);
}


    void UpdateProduct(List<Product> products, List<ProductType> productTypes)
    {
        for (int i = 0; i < products.Count; i++)
        {
            Product product = products[i];
            ProductType productType = productTypes.FirstOrDefault(pt => pt.Id == product.ProductTypeId);
            Console.WriteLine($"{i + 1}. {product.Name}, Product type {productType.Id}");
        }

        Console.WriteLine("Which product would you like to update?");

        int userChoice = int.Parse(Console.ReadLine().Trim());
        int productToUpdate = userChoice - 1;

        Product selectedProduct = products[productToUpdate];

        Console.WriteLine($"Name: {selectedProduct.Name} Price: {selectedProduct.Price} Prodocut Type: {selectedProduct.ProductTypeId}");

        Console.WriteLine("Write a new name for this product. ");

        string response1 = Console.ReadLine();

        Console.WriteLine("List a different price for this product. ");

        string response2 = Console.ReadLine();

        Console.WriteLine("Choose a new product type for this product. ");

        string response3 = Console.ReadLine();

        //null responses to each menu command
        if (!string.IsNullOrEmpty(response1))
        {
            selectedProduct.Name = response1;
        }
        else
        {
            selectedProduct.Name = selectedProduct.Name;
        }

        if (!string.IsNullOrEmpty(response2))
        {
            selectedProduct.Price = decimal.Parse(response2);

        }
        else
        {
            selectedProduct.Price = selectedProduct.Price;
        }

        if (!string.IsNullOrEmpty(response3))
        {
            int productTypeId = int.Parse(response3);
            selectedProduct.ProductTypeId = productTypeId;

        }
        else
        {
            selectedProduct.ProductTypeId = selectedProduct.ProductTypeId;
        }

        Product updatedProduct = new Product
        {
            Name = response1,
            Price = decimal.Parse(response2),
            ProductTypeId = int.Parse(response3),
        };

        selectedProduct = updatedProduct;

        Console.WriteLine("Thank you. Your product has been updated!");
    }

// don't move or change this!
public partial class Program { }