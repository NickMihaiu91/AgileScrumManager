using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainClasses
{
    public class Epic : BaseClass
    {
        public string Name { get; set; }

        public string ColorAdnotation { get; set; }

        [ForeignKey("Backlog")]
        public int? BacklogId { get; set; }

        public Backlog Backlog { get; set; }
    }
}
