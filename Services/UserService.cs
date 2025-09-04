namespace EatDomicile.Services;

using EatDomicile.Models;
using EatDomicile.Repositories;
using System;
using System.Globalization;
using System.Text.RegularExpressions;

public class UserService
{
    private readonly IUserRepository<User> _userRepository;
    private readonly IRepository<Address> _addressRepository;

    public UserService(IUserRepository<User> userRepository, IRepository<Address> addressRepository)
    {
        _userRepository = userRepository;
        _addressRepository = addressRepository;
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
        var user = GetUserByEmail(email);
        if (user != null)
        {
            _userRepository.Delete(user);
            _userRepository.Save();
        }
    }

    private void ValidateUser(User user)
    {
        if (string.IsNullOrEmpty(user.FirstName))
            throw new ArgumentException("Le prénom est requis.");
        if (string.IsNullOrEmpty(user.LastName))
            throw new ArgumentException("Le nom est requis.");
        if (string.IsNullOrEmpty(user.Phone))
            throw new ArgumentException("Le numéro de téléphone est requis.");
        if (string.IsNullOrEmpty(user.Email))
            throw new ArgumentException("L'adresse e-mail est requise.");

        try
        {
            bool isValid = Regex.IsMatch(user.Email,
                @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
                RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));

            if (!isValid)
                throw new ArgumentException("L'adresse e-mail est invalide.");
        }
        catch (RegexMatchTimeoutException)
        {
            throw new ArgumentException("Impossible de valider l'adresse e-mail (timeout).");
        }
    }

    public void AddAddress(Address address)
    {
        ValidateAddress(address);
        _addressRepository.Add(address);
        _addressRepository.Save();
    }

    public void UpdateAddress(Address address)
    {
        ValidateAddress(address);
        _addressRepository.Update(address);
        _addressRepository.Save();
    }

    public Address GetAddressById(Guid id)
    {
        return _addressRepository.GetById(id);
    }

    public void DeleteAddress(Guid id)
    {
        var address = GetAddressById(id);
        if (address != null)
        {
            _addressRepository.Delete(address);
            _addressRepository.Save();
        }
    }

    private void ValidateAddress(Address address)
    {
        if (string.IsNullOrEmpty(address.Street))
            throw new ArgumentException("La rue est requise.");
        if (string.IsNullOrEmpty(address.City))
            throw new ArgumentException("La ville est requise.");
        if (string.IsNullOrEmpty(address.Zip))
            throw new ArgumentException("Le code postal est requis.");
        if (string.IsNullOrEmpty(address.Country))
            throw new ArgumentException("Le pays est requis.");
    }
    
    public void ChangeUserAddress(string email, Guid addressId)
    {
        var user = GetUserByEmail(email);
        if (user == null)
            throw new ArgumentException("Utilisateur introuvable.");

        var address = _addressRepository.GetById(addressId);
        if (address == null)
            throw new ArgumentException("Adresse introuvable.");

        user.Address = address;

        _userRepository.Update(user);
        _userRepository.Save();
    }
}