namespace ApiBarberia;

public class Repository : IRepository
{
    internal readonly DbContextCR _context;
    public Repository(DbContextCR context)
    {
        _context = context;
    }

    public void SaveChanges()
    {
        _context.SaveChanges();
    }
}