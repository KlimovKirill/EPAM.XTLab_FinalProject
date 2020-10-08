using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.FinalProject.Entities
{
    public class Topic
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public DateTime CreationDate { get; set; }

        //public IEnumerable<Message> Messages { get; set; }
    }
}
