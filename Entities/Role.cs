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
    [Table("roles")]
    public class Role:DbEntity
    {

        [Column("roleName")]
        [MaxLength(200)]
        public string RoleName { get; set; }

        public List<User> Users { get; set; }
    }
}
