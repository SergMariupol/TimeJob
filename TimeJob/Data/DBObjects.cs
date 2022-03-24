using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeJob.Data.Models;

namespace TimeJob.Data
{
    public class DBObjects
    {
        private readonly AppDbContent appDBContent;
        public DBObjects(AppDbContent appDBContent)
        {
            this.appDBContent = appDBContent;
        }
        public static void Initial(AppDbContent content)
        {

            if (!content.Task.Any())
            {
                content.AddRange(
                   new Project
                   {
                       ProjectName = "FirstProject",
                    });
            }

        
            } 

        }


    }
