using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TimeJob.Data.Models
{
    public class TaskComments
    {
        public Guid id { get; set; }

        public Guid TaskId { get; set; }

        public string CommentType { get; set; }


        public byte[] Content { get; set; }

    }

}
