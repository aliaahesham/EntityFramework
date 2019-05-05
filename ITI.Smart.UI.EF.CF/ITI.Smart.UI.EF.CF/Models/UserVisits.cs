using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.Smart.UI.EF.CF.Models
{
    public class UserVisits
    {
        public DateTime when { get; set; }
        public City City { get; set; }
        public User User { get; set; }
        [Key]
        [ForeignKey("User")]
        [Column(Order = 1)]
        public int Fk_UserId { get; set; }
        [Key]
        [ForeignKey("City")]
        [Column(Order = 2)]
        public int Fk_CityId { get; set; }
    }
}
