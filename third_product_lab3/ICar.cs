using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace third_product_lab3
{
    public interface ICar
    {
        string Name { get; }
        string Model { get; set; }
        string Power { get; }
        string MaxSpeed { get; }
        CarType CarType { get; }

        ICar Clone();
    }

    public enum CarType
    {
        PassengerCar, Truck, Plane
    }

}
