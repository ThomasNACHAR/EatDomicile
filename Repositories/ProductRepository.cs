namespace EatDomicile.Repositories;

using EatDomicile.Models;
using EatDomicile.Data;

public class ProductRepository<T> : Repository<T>, IProductRepository<T> where T : Product
{
    public ProductRepository(EatDomicileContext context) : base(context)
    {
        
    }

    public IEnumerable<Product> GetVegetarian()
    {
        return _context.Products
            .OfType<Food>()
            .Where(f => f.Vegetarian)
            .ToList();
    }

    public IEnumerable<Product> SearchProductsByName(string name)
    {
        return _context.Products.Where(p => p.Name.Contains(name)).ToList();
    }

    public IEnumerable<Product> SearchProductsWithIngredients(ICollection<Ingredient> ingredients)
    {
        return _context.Products
            .OfType<Food>()
            .Where(p => ingredients.All(i => p.Ingredients.Any(pi => pi.Id == i.Id)))
            .ToList();
    }

    public IEnumerable<Product> SearchProductWithoutAllergen(Allergen allergen)
    {
        return _context.Products
            .Where(p => !p.Allergens.Any(a => a.Id == allergen.Id))
            .ToList();
    }
}