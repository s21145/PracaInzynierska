﻿using pracaInzynierska_backend.Models;
using pracaInzynierska_backend.Models.Dto;

namespace pracaInzynierska_backend.Services.IRepository
{
    public interface IGameRepository : IGenericRepository<pracaInzynierska_backend.Models.Game>
    {
        public List<GetGamesDTO> GetUserGamesAsync(int userId);
        public List<GetGamesDTO> GetUserMissingGamesAsync(int userId);
    }
}
