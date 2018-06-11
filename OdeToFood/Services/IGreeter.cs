using Microsoft.Extensions.Configuration;

namespace OdeToFood.Services
{
    public interface IGreeter
    {
        string MessageOfTheDay();
    }

    public class Greeter : IGreeter
    {
        private IConfiguration _c;

        public Greeter(IConfiguration configuration)
        {
            _c = configuration;
        }
        public string MessageOfTheDay()
        {
            return _c["Greeting"];
            //return "Hasta La Manhana";
        }
    }
}