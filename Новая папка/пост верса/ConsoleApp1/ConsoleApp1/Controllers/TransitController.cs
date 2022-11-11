using ConsoleApp1.Interfaces;
using ConsoleApp1.Services;

namespace ConsoleApp1.Controllers
{
    public class TransitController
    {
        private readonly ITransit _transit;
        public TransitController()
        {
            _transit = new TransitServices();
        }

        public void Transit(Guid id)
        {
            _transit.Transit(id);
        }
            
    }
}
