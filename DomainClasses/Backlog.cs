using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainClasses
{
    public class Backlog :BaseClass
    {
        private ICollection<Task> _tasks;
        private ICollection<Epic> _epics;

        public Backlog()
        {
            _tasks = new List<Task>();
            _epics = new List<Epic>();
        }

        //[ForeignKey("Product")]
        //public int ProductId { get; set; }

        //public Product Product { get; set; }

        public ICollection<Task> Tasks
        {
            get { return _tasks; }
            set { _tasks = value; }
        }

        public ICollection<Epic> Epics
        {
            get { return _epics; }
            set { _epics = value; }
        }
    }
}
