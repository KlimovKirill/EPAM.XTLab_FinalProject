using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.FinalProject.Entities
{
    public class Message
    {
        public int ID { get; set; }

        public DateTime CreationDate { get; set; }

        public string Text { get; set; }

        public string Author { get; set; } //int AutorID

        public int TopicID { get; set; }

        public override string ToString()
        {
            return $"{ID} {Text} {Author} {CreationDate}";
        }
    }
}
