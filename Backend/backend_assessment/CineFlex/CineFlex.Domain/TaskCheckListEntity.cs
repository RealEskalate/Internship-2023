using CineFlex.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Domain
{
    public class TaskCheckListEntity: BaseDomainEntity
    {
        public int TaskId { get; set; }
        public TaskEntity TaskEntity { get; set; }

    }
}
