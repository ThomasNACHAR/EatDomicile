namespace EatDomicile.Repositories;

using EatDomicile.Models;

public interface IUserRepository<T> : IRepository<T> where T : User
{
    User? GetUserByEmail(string email);
}