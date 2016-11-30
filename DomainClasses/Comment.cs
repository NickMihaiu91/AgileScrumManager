using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainClasses
{
    public class Comment : BaseClass
    {
        public string Content { get; set; }

        public User PostedBy { get; set; }

        public DateTime PostedAt { get; set; }

        public Task Task { get; set; }
    }
}
