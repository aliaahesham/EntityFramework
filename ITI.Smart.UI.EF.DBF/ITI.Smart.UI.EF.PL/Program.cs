
using ITI.Smart.UI.EF.BLL;
using ITI.Smart.UI.EF.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.Smart.UI.EF.PL
{
    class Program
    {
        static void Main(string[] args)
        {
            App_Start.EntityFrameworkProfilerBootstrapper.PreStart();

            //Entities context = new Entities();
            //User u1 = new User
            //{
            //    Name = "Aliaa",
            //};
            //context.Users.Add(u1);

            //List<User> users = context.Users.ToList();
            //List<City> cities = context.Cities.ToList();
            //users[0].Cities.Add(cities[0]);
            //context.SaveChanges();

            //changing the default Remove
            //Country c = context.Countries.Find(1);
            //context.Countries.Remove(c);
            //context.SaveChanges();


            //////////////////////////////////////////


            UnitOfWork u = UnitOfWork.Create();
            // Add << throws An unhandled exception!!
            u.CountryManager.Add(new Country { Name = "UK" });

            //GetById and Remove
            //Country c = u.CountryManager.GetById(2);
            //u.CountryManager.Remove(c);

            //update << throws An unhandled exception!!
            //Country c = u.CountryManager.GetById(3);
            //c.Name = "the States";
            //u.CountryManager.Update(c);
        }
    }
}

