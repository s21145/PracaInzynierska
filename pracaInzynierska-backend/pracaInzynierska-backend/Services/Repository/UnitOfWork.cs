using pracaInzynierska_backend.Models;
using pracaInzynierska_backend.Services.IRepository;

namespace pracaInzynierska_backend.Services.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private DatabaseContext _db;
        public UnitOfWork(DatabaseContext db)
        {
            _db = db;
            Game = new GameRepository(_db);
            Post = new PostRepository(_db);
            User = new UserRepository(_db);

        }
        public IGameRepository Game { get; private set; }
        public IPostRepository Post { get; private set; }
        public IUserRepository User { get; private set; }
        public void Save()
        {
            _db.SaveChanges();
        }
        public async Task SaveAsync()
        {
            await _db.SaveChangesAsync();
        }
    }
}
