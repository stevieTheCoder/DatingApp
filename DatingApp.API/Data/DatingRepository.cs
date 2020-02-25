using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatingApp.API.Dtos;
using DatingApp.API.Models;
using Microsoft.EntityFrameworkCore;

namespace DatingApp.API.Data
{
    public class DatingRepository : IDatingRepository
    {
        private readonly DataContext _context;

        public DatingRepository(DataContext context)
        {
            _context = context;
        }

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public async Task<UserForDetailDto> GetUser(int id)
        {
            var user = await _context.Users.Include(u => u.Photos)
            .Select(UserForDetailDto.Projection)
            .SingleOrDefaultAsync(u => u.Id == id);

            return user;
        }

        public async Task<IEnumerable<UserForListDto>> GetUsers()
        {
            var users = await _context.Users.Include(u => u.Photos)
            .Select(UserForListDto.Projection)
            .ToListAsync();

            return users;
        }

        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}