using Entities;
using Microsoft.EntityFrameworkCore;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class RoleViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }



        public RoleViewModel()
        {
        }
        public bool IsEmpty
        {
            get => Name == null;
        }


        public RoleViewModel(Role category)
        {
            Id = category.Id;
            Name = category.RoleName;

        }

        public static implicit operator Role(RoleViewModel model)
        {
            return new Role
            {
                Id = model.Id,
                RoleName = model.Name
            };
        }

        public static RoleViewModel GetModeratorRole(IRoleRepository repository)
        {
            return (repository.AllItems as DbSet<Role>)
                .Where(c => c.RoleName == "Moderator")
                .Select(c => new RoleViewModel(c))
                .FirstOrDefault();
        }
        public static RoleViewModel GetMemberRole(IRoleRepository repository)
        {
            return (repository.AllItems as DbSet<Role>)
                .Where(c => c.RoleName == "Member")
                .Select(c => new RoleViewModel(c))
                .FirstOrDefault();
        }
        public static async Task<bool> Delete(Guid id, IRoleRepository repository)
        {
            return await repository.DeleteItemAsync(id);
        }

        public static async Task<bool> Edit(RoleViewModel model, IRoleRepository repository)
        {
            return await repository.ChangeItemAsync(model);
        }

        public static IQueryable<RoleViewModel> GetRoleList(IRoleRepository repository)
        {
            return (repository.AllItems as DbSet<Role>)
                .Select(p => new RoleViewModel(p));
        }
    }
}
