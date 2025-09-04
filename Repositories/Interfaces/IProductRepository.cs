namespace EatDomicile.Repositories;

using EatDomicile.Models;

public interface IProductRepository<T> : IRepository<T> where T : Product
{
    IEnumerable<Product> SearchProductsByName(string name);
    IEnumerable<Product> GetVegetarian();
    IEnumerable<Product> SearchProductsWithIngredients(ICollection<Ingredient>  ingredients);
    IEnumerable<Product> SearchProductWithoutAllergen(Allergen allergen);
}