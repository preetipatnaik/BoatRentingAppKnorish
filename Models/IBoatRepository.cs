using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;

namespace BoatRentingAppKnorish.Models
{
    public interface IBoatRepository
    {
        public string AddBoat(Boat boat);
        public List<Boat> GetBoat();
        public string RentRequest(RentBoatModel model);
    }
}
