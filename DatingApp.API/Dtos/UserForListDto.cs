using System;
using System.Linq;
using System.Linq.Expressions;
using DatingApp.API.Helpers;
using DatingApp.API.Models;

namespace DatingApp.API.Dtos
{
    public class UserForListDto
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public string KnownAs { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastActive { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string PhotoUrl { get; set; }

        public static Expression<Func<User, UserForListDto>> Projection 
        {
            get 
            {
                return u => new UserForListDto 
                {
                    Age = u.DateOfBirth.CalculateAge(),
                    City = u.City, 
                    Country = u.Country, 
                    Created = u.Created, 
                    Gender = u.Gender, 
                    Id = u.Id, 
                    KnownAs = u.KnownAs, 
                    LastActive = u.LastActive, 
                    PhotoUrl = u.Photos.SingleOrDefault(p => p.IsMain).Url,
                    Username = u.Username
                };
            }
        }        
    }
}