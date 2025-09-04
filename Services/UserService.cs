namespace EatDomicile.Services;

using EatDomicile.Models;
using EatDomicile.Repositories;

public class UserService
{
    private readonly IUserRepository<User> _userRepository;

    public UserService(IUserRepository<User> userRepository)
    {
        _userRepository = userRepository;
    }

    public void RegisterUser(User user)
    {
        ValidateUser(user); 
        
        _userRepository.Add(user);
        _userRepository.Save();
    }

    public void UpdateUser(User user)
    {
        ValidateUser(user); 
        
        _userRepository.Update(user);
        _userRepository.Save();
    }

    public User GetUserByEmail(string email)
    {
        return _userRepository.GetUserByEmail(email);
    }

    public void DeleteUserByEmail(string email)
    {
        var user = this.GetUserByEmail(email);
        if (user != null)
        {
            _userRepository.Delete(user);
            _userRepository.Save();
        }
    }

    private void ValidateUser(User user)
    {
        if (string.IsNullOrEmpty(user.FirstName))
        {
            throw new ArgumentException("Le prénom est requis.");
        }

        if (string.IsNullOrEmpty(user.LastName))
        {
            throw new ArgumentException("Le nom est requis.");
        }

        if (string.IsNullOrEmpty(user.Phone))
        {
            throw new ArgumentException("Le numéro de téléphone est requis.");
        }

        if (string.IsNullOrEmpty(user.Email))
        {
            throw new ArgumentException("L'adresse e-mail est requise.");
        }
    }
}

