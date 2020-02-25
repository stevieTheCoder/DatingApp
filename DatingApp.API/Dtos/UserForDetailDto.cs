using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using DatingApp.API.Helpers;
using DatingApp.API.Models;

namespace DatingApp.API.Dtos
{
    public class UserForDetailDto
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public string KnownAs { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastActive { get; set; }
        public string Introduction { get; set; }
        public string LookingFor { get; set; }
        public string Interests { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string PhotoUrl { get; set; }
        public ICollection<PhotoDto> Photos { get; set; }

        public static Expression<Func<User, UserForDetailDto>> Projection 
        {
            get 
            {
                return u => new UserForDetailDto
                {
                    Age = u.DateOfBirth.CalculateAge(),
                    City = u.City,
                    Country = u.Country, 
                    Created = u.Created, 
                    Gender = u.Gender,
                    Id = u.Id, 
                    Interests = u.Interests, 
                    Introduction = u.Introduction, 
                    KnownAs = u.KnownAs, 
                    LastActive = u.LastActive, 
                    LookingFor = u.LookingFor, 
                    Photos = u.Photos.AsQueryable().Select(PhotoDto.Projection).ToList(), 
                    PhotoUrl = u.Photos.Single(p => p.IsMain).Url,
                    Username = u.Username
                };
            }
        }        
    }
}