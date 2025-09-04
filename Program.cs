using EatDomicile.Data;
using EatDomicile.Models;
using EatDomicile.Repositories;

using (var context = new EatDomicileContext())
{
    var addressRepository = new Repository<Address>(context);
    var address1 = new Address { Street = "221B Baker Street", City = "London", Zip = "NW1 6XE", Country = "Uk" };
    // addressRepository.Add(address1);
    // addressRepository.Save();
    
    var productRepository = new ProductRepository<Product>(context);
    var drink1 = new Drink { Name = "Pepsi Max", KCal = 0.0, Price = 2.5, Fizzy = true };
    var burger1 = new Burger { Name = "Veggie Whopper", KCal = 800.0, Price = 10.0, Vegetarian = true };
    productRepository.Add(drink1);
    productRepository.Add(burger1);
    productRepository.Save();
    var vegetarians = productRepository.GetVegetarian();
    foreach (var vegetarian in vegetarians)
    {
        Console.WriteLine(vegetarian.Name);
    }

}

