using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace third_product_lab3
{
    public class Plane : ICar
    {
        public string Name { get; set; }
        public string Model { get; set; }
        public string Power { get; set; }
        public string MaxSpeed { get; set; }
        public CarType CarType { get; set; }
        public string RegNumber { get; set; }
        public int Capacity { get; set; }
        public int Wingspan {  get; set; }

        public Plane(string name, string model, string power, string maxSpeed)
        {
            Name = name;
            Model = model;
            Power = power;
            MaxSpeed = maxSpeed;
            CarType = CarType.Plane;
        }

        public Plane()
        {
            CarType = CarType.Plane;
        }

        public ICar Clone()
        {
            return new Plane
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
