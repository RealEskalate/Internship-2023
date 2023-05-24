using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MBApp.Domain.Common
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime LastModifiedDate { get; set; }
    }
}