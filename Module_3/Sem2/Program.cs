using System;

namespace Sem2
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Using delegates for events");

            Car c1 = new Car("Tod", 100, 10);

            c1.RegisterWithCarEngine(new Car.CarEngineHandler(OnCarEventHandler));
            Console.WriteLine("Speed");

            for (int i = 0; i < 6; i++)
            {
                c1.Accelerate(20);
                Console.ReadLine();

            }
        }
    }

    public class Car
    {
        public int CurrentSpeed { get; set; }
        public int MaxSpeed { get; set; }
        public string Name { get; set; }

        private bool carIsDead;

        private CarEngineHandler listOfHandlers;

        public Car() { MaxSpeed = 100; }

        public Car(string name, int maxSp, int currSp)
        {
            CurrentSpeed = currSp;
            MaxSpeed = maxSp;
            Name = name;
        }

        public void RegisterWithCarEngine(CarEngineHandler methodToCall)
        {
            listOfHandlers = methodToCall;
        }

        public void Accelerate(int delta)
        {
            if (!carIsDead)
            {
                CurrentSpeed += delta;

                if ((MaxSpeed - CurrentSpeed) <= 10 && listOfHandlers != null) 
                {
                    listOfHandlers("Be carefull!");
                }

                if (CurrentSpeed > MaxSpeed)
                {
                    carIsDead = true;
                }
                else
                {
                    listOfHandlers($"Current Speed: {CurrentSpeed}");
                }
            }
            else
            {
                listOfHandlers?.Invoke("Car is broken :(");
            }
        }
    }

    public delegate void CarEngineHandler(string msgForCaller);

    enum SuMEnum
    {
        A,
        B = 9,
        c
    }
}
