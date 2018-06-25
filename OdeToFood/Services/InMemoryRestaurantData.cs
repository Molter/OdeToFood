using OdeToFood.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OdeToFood.Services
{
    public class InMemoryRestaurantData : IRestaurantData
    {
        List<Restaurant> restaurants;

        public InMemoryRestaurantData()
        {
            restaurants = new List<Restaurant> {
                new Restaurant{Id = 1, Name = "Pizza Place"},
                new Restaurant{Id = 2, Name = "Burrito's Palace"},
                new Restaurant{Id = 3, Name = "Swarma Factory"},

            };
        }

        public IEnumerable<Restaurant> GetAll()
        {
            return restaurants.OrderBy( x => x.Name);
        }

        public Restaurant Get(int id)
        {
            return restaurants.FirstOrDefault(x => x.Id == id);
        }

        public Restaurant Add(Restaurant r)
        {
            r.Id = restaurants.Max(x => x.Id) + 1;
            restaurants.Add(r);

            return r;
        }

        public Restaurant Update(Restaurant r)
        {
            throw new NotImplementedException();
        }
    }
}
