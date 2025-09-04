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
    var vegetarians = productRepository.GetVegetarian();
    Console.WriteLine("--------------------------------------------- \n Végétarien");
    foreach (var vegetarian in vegetarians)
    {
        Console.WriteLine(vegetarian.Name);
    }
    
    var burgers = productRepository.SearchProductsByName("burger");
    Console.WriteLine("--------------------------------------------- \n Burger");
    foreach (var burger in burgers)
    {
        Console.WriteLine(burger.Name);
    }

    var ingredientsRepository = new Repository<Ingredient>(context);
    var mozzarella = ingredientsRepository.GetById(Guid.Parse("27d71948-eb73-4b54-92a5-12240d1ad653"));
    var mozzaFoods = productRepository.SearchProductsWithIngredients(new List<Ingredient> { mozzarella });
    foreach (var mozzaFood in mozzaFoods)
    {
        Console.WriteLine(mozzaFood.Name);
    }




}

