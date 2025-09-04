using EatDomicile.Data;
using EatDomicile.Models;
using EatDomicile.Repositories;

using (var context = new EatDomicileContext())
{
    var addressRepository = new Repository<Address>(context);
    var address1 = new Address { Street = "221B Baker Street", City = "London", Zip = "NW1 6XE", Country = "Uk" };
    addressRepository.Add(address1);
    addressRepository.Save();

}

