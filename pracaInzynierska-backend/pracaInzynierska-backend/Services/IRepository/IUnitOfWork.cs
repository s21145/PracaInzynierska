﻿namespace pracaInzynierska_backend.Services.IRepository
{
    public interface IUnitOfWork
    {
        public IGameRepository Game { get; }
        public IPostRepository Post { get; }
        public void Save();
        public Task SaveAsync();
    }
}
