namespace EatDomicile.Services;

using EatDomicile.Models;
using EatDomicile.Repositories;
using System;
using System.Globalization;
using System.Text.RegularExpressions;

public class ProductService
{
    private readonly IProductRepository<Product> _productRepository;

    public ProductService(IProductRepository<Product> productRepository)
    {
        _productRepository = productRepository;
    }

    public void AddProduct(Product product)
    {
        ValidateProduct(product);
        _productRepository.Add(product);
        _productRepository.Save();
    }
    
    public void UpdateProduct(Product product)
    {
        ValidateProduct(product);
        _productRepository.Update(product);
        _productRepository.Save();
    }

    public Product? GetProductByName(string name)
    {
        return _productRepository.GetProductByName(name);
    }

    public void DeleteProduct(string name)
    {
        var product = GetProductByName(name);
        if (product != null)
        {
            _productRepository.Delete(product);
            _productRepository.Save();
        }
    }
    
    public IEnumerable<Product> GetVegetarianProducts()
    {
        return _productRepository.GetVegetarian();
    }

    public IEnumerable<Product> SearchProductsByName(string name)
    {
        return _productRepository.SearchProductsByName(name);
    }

    public IEnumerable<Product> SearchProductsWithIngredients(ICollection<Ingredient> ingredients)
    {
        return _productRepository.SearchProductsWithIngredients(ingredients);
    }

    public IEnumerable<Product> SearchProductsWithoutAllergen(Allergen allergen)
    {
        return _productRepository.SearchProductWithoutAllergen(allergen);
    }
    
    private void ValidateProduct(Product product)
    {
        if (product == null)
            throw new ArgumentNullException(nameof(product));

        if (string.IsNullOrWhiteSpace(product.Name))
            throw new ArgumentException("Le nom du produit est requis.");

        if (product.Price <= 0)
            throw new ArgumentException("Le prix doit être supérieur à 0.");

        if (product.KCal < 0)
            throw new ArgumentException("Les calories (KCal) doivent être supérieures ou égales à 0.");
        
        switch (product) // RESPECT THE ORDER
        {
            case Pasta pasta:
                if (string.IsNullOrWhiteSpace(pasta.Type))
                    throw new ArgumentException("Le type de pâtes est requis.");
                break;

            case Pizza pizza:
                if (pizza.Dough == null)
                    throw new ArgumentException("Le type de pâte à pizza est requise.");
                break;

            case Drink:
                break;

            case Burger:
                break;
            
            case Food food:
                if (food.Ingredients == null || !food.Ingredients.Any())
                    throw new ArgumentException("Un plat doit contenir au moins un ingrédient.");
                break;
        }
    }

}