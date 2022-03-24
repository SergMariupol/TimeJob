using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TimeJob.Data.Models
{
    public class Project
    {
        public Guid id { get; set; }
        public string ProjectName { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateTime { get; set; }
    }

}
