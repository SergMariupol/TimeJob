using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeJob.Data.Interfaces;
using TimeJob.Data.Models;
using TimeJob.ViewModels;

namespace TimeJob.Data.Repository
{
    public class TaskJobRepository : IAllTaskJob
    {
        private readonly AppDbContent appDBContent;
        public TaskJobRepository(AppDbContent appDBContent)
        {
            this.appDBContent = appDBContent;
        }
        public IEnumerable<TaskJob> Task => appDBContent.Task;
        public IEnumerable<Project> Project => appDBContent.Project;
        public IEnumerable<TaskComments> TaskComments => appDBContent.TaskComments;

        public IEnumerable<Project> pro;

        public void CreateTask(MainViewModel Main)
        {
            Project Project = new Project();
            Project.ProjectName = Main.Project.ProjectName;
            Project.CreateDate = DateTime.Now;
            appDBContent.Project.Add(Project);
            appDBContent.SaveChanges();
            pro = appDBContent.Project.OrderBy(pro => Project.id);
            Project pros = pro.Last();                
            Main.Task.ProjectId = pros.id;
            Main.Task.CreateDate = DateTime.Now;
            appDBContent.Task.Add(Main.Task);
            appDBContent.SaveChanges();


            Main.TaskComment.TaskId = Main.Task.id;
            appDBContent.TaskComments.Add(Main.TaskComment);


            appDBContent.SaveChanges();

        }

        public void EditTask(TaskJob Task)
        {
            Task.UpdateDate = DateTime.Now;
            appDBContent.Task.Update(Task);
            appDBContent.SaveChanges();
        }
    }
}
