using System;
using System.Linq.Expressions;
using DatingApp.API.Models;

namespace DatingApp.API.Dtos
{
    public class PhotoDto
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public string Description { get; set; }
        public DateTime DateAdded { get; set; }
        public bool IsMain { get; set; }
        public int UserId { get; set; }

        public static Expression<Func<Photo, PhotoDto>> Projection 
        {
            get 
            {
                return p => new PhotoDto 
                {
                    DateAdded = p.DateAdded,
                    Description = p.Description, 
                    Id = p.Id, 
                    IsMain = p.IsMain, 
                    Url = p.Url, 
                    UserId = p.UserId
                };
            }
        }        
    }
}