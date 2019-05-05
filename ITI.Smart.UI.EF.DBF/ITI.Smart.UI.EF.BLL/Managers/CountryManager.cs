using ITI.Smart.UI.EF.Model;
using ITI.Smart.UI.EF.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.Smart.UI.EF.BLL.Managers
{
    public class CountryManager : Repository<Country, Entities>
    {
        public CountryManager(Entities context) : base(context)
        {
        }
    }
}
