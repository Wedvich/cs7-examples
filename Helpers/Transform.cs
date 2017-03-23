namespace Cs7.Helpers
{
    public class Transform
    {
        private double _x = 1;
        private double _y = 1.5;
        private double _z = 1;

        public void GetScale(out double x, out double y, out double z)
        {
            x = _x;
            y = _y;
            z = _z;
        }
    }
}
