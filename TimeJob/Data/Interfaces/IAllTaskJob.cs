using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeJob.Data.Models;
using TimeJob.ViewModels;

namespace TimeJob.Data.Interfaces
{
   public interface IAllTaskJob
    {
        IEnumerable<Project> Project { get; }
        IEnumerable<TaskJob> Task { get; }
        IEnumerable<TaskComments> TaskComments { get; }
        void CreateTask(MainViewModel Main);
        void EditTask(TaskJob TaskJob);
    }
}
