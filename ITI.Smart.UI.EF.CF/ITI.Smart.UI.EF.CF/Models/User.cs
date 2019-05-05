using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.Smart.UI.EF.CF.Models
{
    public class User
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public List<UserVisits> UserVisits { get; set; }
        public int Fk_DepartmentId { get; set; }
        public Department Department { get; set; }
        public List<Book> Books { get; set; }

    }
}
