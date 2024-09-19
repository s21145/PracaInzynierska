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
            Ranking = new UserGameRankingRepository(_db);
            Stats = new UserGameStatsRepository(_db);
            StatsName = new StatsNameRepository(_db);
            FriendLists = new FriendListRepository(_db);
            FriendListRequests = new FriendListRequestRepository(_db);
            Comments = new CommentsRepository(_db);
            Messages = new MessageRepository(_db);


        }
        public ICommentsRepository Comments { get; private set; }
        public IGameRepository Game { get; private set; }
        public IPostRepository Post { get; private set; }
        public IUserRepository User { get; private set; }
        public IUserGameRankingRepository Ranking { get; private set; }
        public IUserGameStatsRepository Stats { get; private set; }
        public IStatsNameRepository StatsName { get; private set; }
        public IFriendListRepository FriendLists { get; private set; }
        public IFriendListRequestRepository FriendListRequests { get; private set; }
        public IMessageRepository Messages { get; private set; }
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
