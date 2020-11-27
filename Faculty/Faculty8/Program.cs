using System;

namespace Faculty8
{
    class MainClass
    {
        static readonly Random rand = new Random();

        public static void Main(string[] args)
        {
            int[] vect1 =  { rand.Next(-10, 11), rand.Next(0, 10) };
            int[] vect2 =  { rand.Next(-10, 11), rand.Next(0, 10) };

            Vector v = new Vector();
            v.ScalarMult(vect1);
        }

    }
    class Vector
    {
        private static double x1;
        private static double x2;
        private static double y1;
        private static double y2;
        private double[] vector = { x2 - x1, y2 - y1 };

        public double GetAccess { get; set; }

        public double VectorLength
        {
            get
            {
                return Math.Sqrt(vector[0] * vector[0] + vector[1] * vector[1]);
            }     
        }

        public double ScalarMult(int[] vect)
        {
            return vector[0] * vect[0] + vector[1] * vect[1];
        }

    }
}
