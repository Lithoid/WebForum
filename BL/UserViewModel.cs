using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Entities;
using Microsoft.EntityFrameworkCore;
using Repositories;

namespace BL
{
    public class UserViewModel
    {
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        public Guid RoleId { get; set; }
        public string RoleName { get; set; }

        public List<Guid> PostsIds { get; set; } = new List<Guid>();
        public List<Guid> TopicsIds { get; set; } = new List<Guid>();


        public UserViewModel()
        {
        }

        public bool IsEmpty
        {
            get => Name == null;
        }

        public UserViewModel(User user)
        {
            Id = user.Id;
            Name = user.Name;
            Email = user.Email;
            Password = user.Password;
            PostsIds = user.Posts.Select(a => a.Id).ToList();
            TopicsIds = user.Topics.Select(a => a.Id).ToList();
            RoleId = user.RoleId;
            RoleName = user.Role.RoleName;
        }

      

        public static implicit operator User(UserViewModel model)
        {
            return new User
            {
                Id = model.Id,
                Name = model.Name,
                Email = model.Email,
                Password = model.Password,
                RoleId = model.RoleId
                
                

            };
        }

        public static UserViewModel GetUserById(Guid id, IUserRepository repository)
        {
            return (repository.AllItems as DbSet<User>)
                .Where(p => p.Id == id)
                .Include(p => p.Posts)
                .Include(p => p.Topics)
                .Include(p => p.Role)
                .Select(p => new UserViewModel(p))
                .FirstOrDefault();
        }
        public static UserViewModel GetUserByName(string email, IUserRepository repository)
        {
            return (repository.AllItems as DbSet<User>)
                .Where(p => p.Email == email)
                .Include(p => p.Posts)
                .Include(p => p.Topics)
                .Include(p => p.Role)
                .Select(p => new UserViewModel(p))
                .FirstOrDefault();
        }
        public static UserViewModel GetUserByCred(IUserRepository repository, string email, string password)
        {
            //u => u.Email == model.Email && u.Password == model.Password
            return (repository.AllItems as DbSet<User>)
                .Where(u => u.Email == email && u.Password == password)
                .Include(p => p.Posts)
                .Include(p => p.Topics)
                .Include(p => p.Role)
                .Select(p => new UserViewModel(p))
                .FirstOrDefault();
        }
        public static async Task<bool> Delete(Guid id, IUserRepository repository)
        {
            return await repository.DeleteItemAsync(id);
        }

        public static async Task<bool> Edit(UserViewModel model, IUserRepository repository)
        {
            return await repository.ChangeItemAsync(model);
        }

        public static IQueryable<UserViewModel> GetUserList(IUserRepository repository)
        {

            return (repository.AllItems as DbSet<User>)
                .Include(p => p.Posts)
                .Include(p => p.Topics)
                .Select(p => new UserViewModel(p));
        }
        
    }
}