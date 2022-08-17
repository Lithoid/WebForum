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

    [Table("topics")]
    public class Topic : DbEntity
    {
        [Column("name")]
        [MaxLength(200)]
        public string Name { get; set; }
        [Column("dateCreated")]
        public DateTime DateCreated { get; set; }

        public User User { get; set; }
        public Guid UserId { get; set; }


        public List<Post> Posts { get; set; }
    }
}
