namespace PlantHere.Persistence.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public bool Commit()
        {
            _context.SaveChanges();
            return true;
        }

        public async Task<bool> CommitAsync()
        {
            await _context.SaveChangesAsync();
            return true;
        }

        public void Dispose()
        {
        }

        public async ValueTask DisposeAsync() { }
    }
}
