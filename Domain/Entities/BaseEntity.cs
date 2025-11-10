using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public abstract class BaseEntity
    {
        protected BaseEntity() {
            IsActive = true;
        }
        public Guid Id { get; set; }
        public bool IsActive { get; set; }
    }
}
