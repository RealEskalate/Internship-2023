using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogApp.Domain;

namespace BlogApp.Application.Contracts.Persistence
{
    public interface IReviewRepository : IGenericRepository<Review>
    {
        
    }
}
