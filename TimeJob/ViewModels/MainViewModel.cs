using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeJob.Data.Models;

namespace TimeJob.ViewModels
{
    public class MainViewModel
    {
        public IEnumerable<TaskJob> AllTask { get; set; }
        public IEnumerable<Project> AllProject { get; set; }
        public IEnumerable<TaskComments> AllTaskComment { get; set; }
        public Guid ProjectFact { get; set; }
        public DateTime Start { get; set; }
        public Guid IdEditTask { get; set; }
        public TaskJob Task { get; set; }
        public TaskComments TaskComment { get; set; }
        public Project Project { get; set; }
        public IFormFile CommentFile { get; set; }
        public string CommentText { get; set; }

    }
    
}
