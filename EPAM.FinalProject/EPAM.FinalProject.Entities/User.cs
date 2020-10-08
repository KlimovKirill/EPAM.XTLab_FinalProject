using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.FinalProject.Entities
{
    public class User
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public string Role { get; set; }

        public string Icon = "https://www.flaticon.com/svg/static/icons/svg/1077/1077012.svg";

    }
}
