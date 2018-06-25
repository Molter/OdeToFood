using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OdeToFood.Data;
using OdeToFood.Models;

namespace OdeToFood.Services
{
    public class SqlRestaurantData : IRestaurantData
    {
        OdeToFoodDbContext _context;
        public SqlRestaurantData(OdeToFoodDbContext context)
        {
            _context = context;
        }

        public Restaurant Add(Restaurant r)
        {
            _context.Restaurants.Add(r);
            _context.SaveChanges();

            return r;
        }

        public Restaurant Get(int id)
        {
            return _context.Restaurants.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Restaurant> GetAll()
        {
            return _context.Restaurants.OrderBy(x => x.Name);
        }

        public Restaurant Update(Restaurant r)
        {
            _context.Attach(r).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();

            return r;
        }
    }
}
