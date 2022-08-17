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
    public class TopicViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public DateTime DateCreated { get; set; }

        public Guid UserId { get; set; }
        public string UserName { get; set; }

        public List<Guid> PostsIds { get; set; } = new List<Guid>();



        public TopicViewModel()
        {
        }
        public bool IsEmpty
        {
            get => Name == null;
        }


        public TopicViewModel(Topic topic)
        {
            Id = topic.Id;
            Name = topic.Name;
            DateCreated = topic.DateCreated;
            UserId = topic.UserId;
            UserName = topic.User.Name;
            PostsIds = topic.Posts.Select(a => a.Id).ToList();

        }

        public static implicit operator Topic(TopicViewModel model)
        {
            return new Topic
            {
                Id = model.Id,
                Name = model.Name,
                DateCreated = model.DateCreated,
                UserId = model.UserId,
                
            };
        }

  
        public static async Task<bool> Delete(Guid id, ITopicRepository repository)
        {
            return await repository.DeleteItemAsync(id);
        }

        public static async Task<bool> Edit(TopicViewModel model, ITopicRepository repository)
        {
            return await repository.ChangeItemAsync(model);
        }

        public static IQueryable<TopicViewModel> GetTopicList(ITopicRepository repository)
        {
            return (repository.AllItems as DbSet<Topic>)
                .Include(u=>u.User)
                .Include(p=>p.Posts)
                .Select(p => new TopicViewModel(p));
        }
    }
}
