using System;
using Libra;

namespace sem8
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Point<Int32>[] arr = new Point<int>[10];
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = new IntPoint();
            }
        }
    }
}
