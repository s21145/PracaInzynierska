﻿using pracaInzynierska_backend.Models;
using pracaInzynierska_backend.Models.Dto;

namespace pracaInzynierska_backend.Services.IRepository
{
    public interface IPostRepository : IGenericRepository<Post>
    {
        public Task<GetPostDto> GetPostWithCommentsAsync(int postId,int userId);
        public Task<List<GetPostDto>> GetPostsAsync(string gameName,int page,int userId);
        Task<List<GetPostDto>> GetMainPagePostsAsync(int page, int userId);
    }
}
