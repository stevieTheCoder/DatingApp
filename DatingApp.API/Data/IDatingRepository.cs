using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DatingApp.API.Dtos;
using DatingApp.API.Models;

namespace DatingApp.API.Data
{
    public interface IDatingRepository
    {
        void Add<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<Boolean> SaveAll();
        Task<IEnumerable<UserForListDto>> GetUsers();
        Task<UserForDetailDto> GetUser(int id);
    }
}