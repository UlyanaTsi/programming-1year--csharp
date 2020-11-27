using System;

namespace Libra
{
    public class IntPoint : Point<Int32>
    {
        public override int SquareDistance => X * X + Y * Y;
    }
}
