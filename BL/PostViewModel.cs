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
    public class PostViewModel
    {
        public Guid Id { get; set; }


        public string Message { get; set; }

        public DateTime DateCreated { get; set; }

        public Guid UserId { get; set; }
        public string UserName { get; set; }

        public Guid TopicId { get; set; }
        public string TopicName { get; set; }



        public PostViewModel()
        {

        }
        
    
        public bool IsEmpty
        {
            get => Message == null;
        }


        public PostViewModel(Post post)
        {
            Id = post.Id;
            Message = post.Message;
            DateCreated = post.DateCreated;
            UserId = post.UserId;
            UserName = post.User.Name;
            TopicId = post.TopicId;
            TopicName = post.Topic.Name;

        }

        public static implicit operator Post(PostViewModel model)
        {
            return new Post
            {
                Id = model.Id,
                Message = model.Message,
                DateCreated = model.DateCreated,
                UserId = model.UserId,
                TopicId = model.TopicId,

            };
        }

      

        public static async Task<bool> Delete(Guid id, IPostRepository repository)
        {
            return await repository.DeleteItemAsync(id);
        }

        public static async Task<bool> Edit(PostViewModel model, IPostRepository repository)
        {
            return await repository.ChangeItemAsync(model);
        }


        public static IQueryable<PostViewModel> GetPostList(IPostRepository repository,Guid? topicId)
        {
            if (topicId.HasValue)
            {
                return (repository.AllItems as DbSet<Post>)
                .Where(p=>p.TopicId==topicId)
                .Include(u => u.User)
                .Include(p => p.Topic)
                .Select(p => new PostViewModel(p));
            }
            return (repository.AllItems as DbSet<Post>)
                .Include(u => u.User)
                .Include(p => p.Topic)
                .Select(p => new PostViewModel(p));
        }

        public static PostViewModel GetPostById(Guid id, IPostRepository repository)
        {
            return (repository.AllItems as DbSet<Post>)
                .Where(p => p.Id == id)
                .Include(p => p.Topic)
                .Include(p => p.User)
                .Select(p => new PostViewModel(p))
                .FirstOrDefault();
        }
    }
}
