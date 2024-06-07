using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace third_product_lab3
{
    public class Truck : ICar
    {
        public string Name { get; set; }
        public string Model { get; set; }
        public string Power { get; set; }
        public string MaxSpeed { get; set; }
        public CarType CarType { get; set; }
        public string RegNumber { get; set; }
        public int NumOfWheels { get; set; }
        public int BodyCapacity { get; set; }

        public Truck(string name, string model, string power, string maxSpeed)
        {
            Name = name;
            Model = model;
            Power = power;
            MaxSpeed = maxSpeed;
            CarType = CarType.Truck;
        }

        public Truck(string name, string model, string power, string maxSpeed, CarType carType)
        {
            Name = name;
            Model = model;
            Power = power;
            MaxSpeed = maxSpeed;
            CarType = carType;
        }

        public Truck()
        {
            CarType = CarType.Truck;
        }

        public ICar Clone()
        {
            return new Truck
            {
                Name = this.Name,
                Model = this.Model,
                Power = this.Power,
                MaxSpeed = this.MaxSpeed,
                CarType = this.CarType
                
            };
        }
    }
}

