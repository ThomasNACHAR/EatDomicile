namespace EatDomicile.Services;

public class UserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public void RegisterUser(User user)
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
        
        _userRepository.Add(user);
        _userRepository.Save();
    }
}
