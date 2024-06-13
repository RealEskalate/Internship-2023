using CineFlex.Application.Contracts.Persistence;
using CineFlex.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Persistence.Repositories
{
    public class TaskRepository : GenericRepository<TaskEntity>, ITaskRepository
    {
        public TaskRepository(CineFlexDbContex dbContext) : base(dbContext)
        {
        }
    }
}
