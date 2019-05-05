using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.Smart.UI.EF.CF.Models
{
    public class City
    {
        public int Id { get; set; }
        public String Name { get; set; }
        //[ForeignKey("Country")]
        public int Fk_CountryId { get; set; }
        public Country Country { get; set; }
        public List<UserVisits> UserVisits { get; set; }
        public Book Book { get; set; }
    }
}
