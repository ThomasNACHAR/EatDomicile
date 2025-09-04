namespace EatDomicile.Repositories;

using EatDomicile.Models;
using EatDomicile.Data;

public class UserRepository<T> : Repository<T>, IUserRepository<T> where T : User
{
    public UserRepository(EatDomicileContext context) : base(context)
    {
        
    }

    public User? GetUserByEmail(string email)
    {
        return _context.Users.FirstOrDefault(u => u.Email == email);
    }
}