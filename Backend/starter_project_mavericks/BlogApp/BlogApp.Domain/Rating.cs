using BlogApp.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Domain;
public class Rating : BaseDomainEntity
{
    public int BlogId { get; set; }
    public int RaterId { get; set; }
    public int Rate { get; set; }
}
