using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace third_product_lab3
{
    public class CarContainer
    {
        public List<PassengerCar> PassengerCars { get; set; }
        public List<Truck> Trucks { get; set; }
        public List<Plane> Planes { get; set; }
        public CarContainer()
        {
            PassengerCars = new List<PassengerCar>();
            Trucks = new List<Truck>();
            Planes = new List<Plane>();
        }
    }
}
