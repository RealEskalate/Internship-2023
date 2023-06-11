using CineFlex.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Domain
{
    public class Post : BaseDomainEntity
    {
        public string Title { get; set; }
        public string Content { get; set; }

        public int PostUserId { get; set; }

        [ForeignKey("PostUserId")]
        public PostUser Creator { get; set; }
    }
}
