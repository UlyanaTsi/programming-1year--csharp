using System;

namespace Libra
{
    public class DoublePoint : Point<Double>
    {
        public override double SquareDistance => X * X + Y * Y;
    }
}
