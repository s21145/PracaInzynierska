﻿using Microsoft.EntityFrameworkCore;
using pracaInzynierska_backend.Models;
using pracaInzynierska_backend.Services.IRepository;

namespace pracaInzynierska_backend.Services.Repository
{
    public class UserGameRankingRepository : GenericRepository<UserGameRanking>, IUserGameRankingRepository
    {
        public UserGameRankingRepository(DatabaseContext context) : base(context)
        {

        }

        public async Task<List<UserGameRanking>> GetSimilarUsersAsync(int userScore,int IdGame, int page)
        {
            var findBetter = await _context.UserGameRakings
                .Include(x => x.User)
                .Where(x => x.score > userScore)
                .OrderBy(x => x.score)
                .Skip(page*5)
                .Take(5)
                .ToListAsync();
            var findWorse = await _context.UserGameRakings
                .Include(x => x.User)
                .Where(x => x.score <= userScore)
                .OrderByDescending(x => x.score)
                .Skip(page * 5)
                .Take(5)
                .ToListAsync();

            if(findBetter.Count() < 5 && findWorse.Count() < 5)
            {
                findBetter.AddRange(findWorse);
                return findBetter;

            }
            


            if (findBetter.Count() < 5)
            {
                findWorse = await _context.UserGameRakings
               .Include(x => x.User)
               .Where(x => x.score <= userScore)
               .OrderByDescending(x => x.score)
               .Skip(page * 5)
               .Take(10)
               .ToListAsync();
                return findWorse;
            }
            else if(findWorse.Count() < 5)
            {
                findBetter = await _context.UserGameRakings
                                .Include(x => x.User)
                                .Where(x => x.score > userScore)
                                .OrderBy(x => x.score)
                                .Skip(page * 5)
                                .Take(10)
                                .ToListAsync();
                return findBetter;
            }

            findBetter.AddRange(findWorse);



            return findBetter;

        }
    }
}
