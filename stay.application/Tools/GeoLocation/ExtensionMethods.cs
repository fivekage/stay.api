namespace stay.application.Tools.GeoLocation
{
    public static class ExtensionMethods
    {
        public static double ToRadian(this double d)
        {
            return d * (Math.PI / 180.0);
        }

        public static double DiffRadian(this double val1, double val2)
        {
            return val2.ToRadian() - val1.ToRadian();
        }

        public static double ToDegrees(this double r)
        {
            return r * 180.0 / Math.PI;
        }

        public static double ToBearing(this double r)
        {
            return (r.ToDegrees() + 360.0) % 360.0;
        }
    }
}