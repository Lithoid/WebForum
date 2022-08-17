using Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    [Table("posts")]
    public class Post: DbEntity
    {

        [Column("message")]
        [MaxLength(1000)]
        public string Message { get; set; }

        [Column("dateCreated")]
        public DateTime DateCreated { get; set; }

        public Topic Topic { get; set; }
        public Guid TopicId { get; set; }

        public User User { get; set; }
        public Guid UserId { get; set; }
    }
}
