using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{

    public class PostRepository : DbRepository<Post>, IPostRepository
    {
        public PostRepository(DbContext context) : base(context)
        {

        }
    }
}
