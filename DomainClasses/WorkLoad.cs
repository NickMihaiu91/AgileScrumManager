using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainClasses
{
    public class WorkLoad : BaseClass
    {
        public string Description { get; set; }

        [DisplayName("Working time(in hours)")]
        public float Amount { get; set; }

        [DisplayName("Work date")]
        public DateTime WorkDate { get; set; }

        public DateTime AddedAt { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }

        public User User { get; set; }

        [ForeignKey("Task")]
        public int TaskId { get; set; }

        public Task Task { get; set; }
    }
}
