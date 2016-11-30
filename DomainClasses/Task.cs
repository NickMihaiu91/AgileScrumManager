using DomainClasses.Enums;
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
    public class Task : BaseClass
    {
        private ICollection<Comment> _comments;
        private ICollection<WorkLoad> _workLoads;

        public Task()
        {
            _comments = new List<Comment>();
            _workLoads = new List<WorkLoad>();
        }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Title is required !")]
        public string Title { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Description is required !")]
        public string Description { get; set; }

        public User Assignee { get; set; }

        public User Reporter { get; set; }

        [DisplayName("Created at")]
        public DateTime CreatedAt { get; set; }

        [DisplayName("Edited at")]
        public DateTime EditedAt { get; set; }

        [DisplayName("Task priority")]
        public TaskPriority TaskPriority { get; set; }

        [DisplayName("Task type")]
        public TaskType TaskType { get; set; }

        [DisplayName("Task status")]
        public DomainClasses.Enums.TaskStatus TaskStatus { get; set; }

        [DisplayName("Story points")]
        public int? StoryPoints { get; set; }

        //public int Priority { get; set; }

        public virtual ICollection<Comment> Comments
        {
            get { return _comments; }
            set { _comments = value; }
        }

        [ForeignKey("Sprint")]
        public int? SprintId { get; set; }

        public Sprint Sprint { get; set; }

        public Backlog Backlog { get; set; }

        [ForeignKey("Backlog")]
        public int? BacklogId { get; set; }

        public Epic Epic { get; set; }

        [ForeignKey("Epic")]
        public int? EpicId { get; set; }

        public virtual ICollection<WorkLoad> WorkLoads
        {
            get { return _workLoads; }
            set { _workLoads = value; }
        }

        [DisplayName("Total work hours")]
        [NotMapped]
        public float TotalWorkHours { get; set; }

    }
}
