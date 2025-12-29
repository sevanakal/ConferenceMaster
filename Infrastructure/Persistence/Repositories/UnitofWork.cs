using ConferenceMaster.Application.Interfaces;
using ConferenceMaster.Persistence.Context;
using ConfereneceMaster.Application.Interfaces;


namespace ConferenceMaster.Persistence.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _context;

    public UnitOfWork(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public void Dispose() => _context.Dispose();
}