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

    [Table("users")]
    public class User : DbEntity
    {
        [Column("name")]
        [MaxLength(200)]
        public string Name { get; set; }

        [Column("email")]
        [MaxLength(200)]
        public string Email { get; set; }
        [Column("pass")]
        public string Password { get; set; }


        public Role Role { get; set; }
        public Guid RoleId { get; set; }

        public List<Post> Posts { get; set; }
        public List<Topic> Topics { get; set; }



    }
}
