using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace Context
{
    public class AppDataContext : DbContext
    {
        public DbSet<Topic> Topics { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

        public AppDataContext(DbContextOptions<AppDataContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Post>(post =>
            {
                post.HasOne(p => p.User)
                              .WithMany(u => u.Posts)
                              .HasForeignKey(p => p.UserId)
                              .OnDelete(DeleteBehavior.NoAction);

                post.HasOne(p => p.Topic)
                             .WithMany(t => t.Posts)
                             .HasForeignKey(p => p.TopicId)
                             .OnDelete(DeleteBehavior.NoAction);

            });



            modelBuilder.Entity<Topic>(topic =>
            {
                topic.HasOne(t => t.User)
                              .WithMany(u => u.Topics)
                              .HasForeignKey(t => t.UserId)
                              .OnDelete(DeleteBehavior.NoAction);


            });

            modelBuilder.Entity<User>(user =>
            {
                user.HasOne(u => u.Role)
                              .WithMany(r => r.Users)
                              .HasForeignKey(u => u.RoleId);

            });


            var adminRole = new Role() { Id = Guid.NewGuid(), RoleName = "Admin" };
            var moderatorRole = new Role() { Id = Guid.NewGuid(), RoleName = "Moderator" };
            var memberRole = new Role() { Id = Guid.NewGuid(), RoleName = "Member" };

            var adminUser = new User() { Id = Guid.NewGuid(), Name = "admin", Email = "admin@gmail.com", Password = "Qwerty123", RoleId = adminRole.Id };
            var moderatorUser = new User() { Id = Guid.NewGuid(), Name = "moderator", Email = "moderator@gmail.com", Password = "Qwerty123", RoleId = moderatorRole.Id };
            var justUser = new User() { Id = Guid.NewGuid(), Name = "user", Email = "user@gmail.com", Password = "Qwerty123", RoleId = memberRole.Id };

            modelBuilder.Entity<Role>().HasData(
              adminRole,
              moderatorRole,
              memberRole

              );
            modelBuilder.Entity<User>().HasData(adminUser,moderatorUser, justUser);

            modelBuilder.Entity<Topic>().HasData(
                new Topic() { Id = Guid.NewGuid(), Name = "Games", DateCreated = DateTime.Now, UserId = adminUser.Id },
                new Topic() { Id = Guid.NewGuid(),Name = "Movies", DateCreated = DateTime.Now, UserId = adminUser.Id },
                new Topic() { Id = Guid.NewGuid(),Name = "Books", DateCreated = DateTime.Now, UserId = adminUser.Id }
                );

            base.OnModelCreating(modelBuilder);
        }
    }
}
