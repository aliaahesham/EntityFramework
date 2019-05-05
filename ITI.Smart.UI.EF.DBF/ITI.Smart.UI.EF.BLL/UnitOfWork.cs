using ITI.Smart.UI.EF.BLL.Managers;
using ITI.Smart.UI.EF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.Smart.UI.EF.BLL
{
    public class UnitOfWork
    {
        private static Entities context = new Entities();
        private static UnitOfWork unitOfWork;
        private UnitOfWork()
        {
        }

        public static UnitOfWork Create()
        {
            if (unitOfWork == null)
            {
                unitOfWork = new UnitOfWork();
            }
            return unitOfWork;
        }
        public CityManager CityManager
        {
            get { return new CityManager(context); }
        }
        public CountryManager CountryManager
        {
            get { return new CountryManager(context); }
        }
    }
}
