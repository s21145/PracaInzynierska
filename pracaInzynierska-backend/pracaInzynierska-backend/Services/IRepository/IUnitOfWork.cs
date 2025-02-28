﻿namespace pracaInzynierska_backend.Services.IRepository
{
    public interface IUnitOfWork
    {
        public IGameRepository Game { get; }
        public IPostRepository Post { get; }
        public IUserRepository User { get; }
        public IUserGameStatsRepository Stats { get;  }
        public IUserGameRankingRepository Ranking { get;  }
        public IStatsNameRepository StatsName { get; }
        public IFriendListRepository FriendLists { get; }
        public IFriendListRequestRepository FriendListRequests { get; }
        public ICommentsRepository Comments { get; }
        public IMessageRepository Messages { get; }
        public IPostLikes PostLikes { get; }
        public void Save();
        public Task SaveAsync();
    }
}
