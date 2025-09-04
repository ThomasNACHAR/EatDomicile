namespace EatDomicile.Repositories;

using EatDomicile.Data;

public class Repository<T> : IRepository<T> where T : class
{
    protected readonly EatDomicileContext _context;

    public Repository(EatDomicileContext context)
    {
        _context = context;
    }

    public IEnumerable<T> GetAll()
    {
        return _context.Set<T>().ToList();
    }

    public T? GetById(Guid id)
    {
        return _context.Set<T>().Find(id);
    }

    public void Add(T entity)
    {
        var result = _context.Set<T>().Add(entity);
    }

    public void Update(T entity)
    {
        _context.Set<T>().Update(entity);
    }

    public void Delete(T entity)
    {
        _context.Set<T>().Remove(entity);
    }

    public void Save()
    {
        int saved = _context.SaveChanges();
        if (saved == 0)
            throw new Exception("Aucune modification enregistrée.");
    }
}