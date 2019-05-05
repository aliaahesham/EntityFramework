using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITI.Smart.UI.EF.Repository;
using ITI.Smart.UI.EF.Model;
using System.Data.Entity;

namespace ITI.Smart.UI.EF.BLL.Managers
{
    public class CityManager : Repository<City, Entities>
    {
        public CityManager(Entities context) : base(context)
        {
        }
    }
}
