using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DesignPatternsDemo.Model
{
    public class StepWiseBuilderModel : PageModel
    {
        public enum CarType
        {
            Sedan,
            Crossover,
            Sport,
            Truck
        };
        public class Car
        {
            public CarType Type;
            public int WheelSize;

            public String ToString()
            {
                return "Type: " + Type.ToString() + " Wheels: " + WheelSize;
            }
        }

        public interface ISpecifyCarType
        {
            public ISpecifyWheelSize OfType(CarType type);
        }

        public interface ISpecifyWheelSize
        {
            public IBuildCar WithWheels(int size);
        }

        public interface IBuildCar
        {
            public Car Build();
        }

        public class CarBuilder
        {
            public static ISpecifyCarType Create()
            {
                return new Impl();
            }

            private class Impl :
              ISpecifyCarType,
              ISpecifyWheelSize,
              IBuildCar
            {
                private Car car = new Car();

                public ISpecifyWheelSize OfType(CarType type)
                {
                    car.Type = type;
                    return this;
                }

                public IBuildCar WithWheels(int size)
                {
                    switch (car.Type)
                    {
                        case CarType.Truck when size < 19.5 || size > 24.5:
                        case CarType.Crossover when size < 15 || size > 22:
                        case CarType.Sport when size < 18 || size > 21:
                        case CarType.Sedan when size < 14 || size > 19:
                            throw new ArgumentException($"Wrong size of wheel for {car.Type}.");
                    }
                    car.WheelSize = size;
                    return this;
                }

                public Car Build()
                {
                    return car;
                }
            }
        }
    }
}
