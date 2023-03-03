namespace stay.application.Tools.GeoLocation
{
    public static class GeoCalculator
    {
        private static double EarthRadiusInMiles = 3959.0;

        private static double EarthRadiusInNauticalMiles = 3440.0;

        private static double EarthRadiusInKilometers = 6371.0;

        private static double EarthRadiusInMeters = 6371000.0;

        public static double GetDistance(double originLatitude, double originLongitude, double destinationLatitude, double destinationLongitude, int decimalPlaces = 1, DistanceUnit distanceUnit = DistanceUnit.Miles)
        {
            if (!CoordinateValidator.Validate(originLatitude, originLongitude))
            {
                throw new ArgumentException("Invalid origin coordinates supplied.");
            }

            if (!CoordinateValidator.Validate(destinationLatitude, destinationLongitude))
            {
                throw new ArgumentException("Invalid destination coordinates supplied.");
            }

            return Math.Round(GetRadius(distanceUnit) * 2.0 * Math.Asin(Math.Min(1.0, Math.Sqrt(Math.Pow(Math.Sin(originLatitude.DiffRadian(destinationLatitude) / 2.0), 2.0) + Math.Cos(originLatitude.ToRadian()) * Math.Cos(destinationLatitude.ToRadian()) * Math.Pow(Math.Sin(originLongitude.DiffRadian(destinationLongitude) / 2.0), 2.0)))), decimalPlaces);
        }

        public static double GetDistance(Coordinate originCoordinate, Coordinate destinationCoordinate, int decimalPlaces = 1, DistanceUnit distanceUnit = DistanceUnit.Miles)
        {
            return GetDistance(originCoordinate.Latitude, originCoordinate.Longitude, destinationCoordinate.Latitude, destinationCoordinate.Longitude, decimalPlaces, distanceUnit);
        }

        public static double GetBearing(double originLatitude, double originLongitude, double destinationLatitude, double destinationLongitude)
        {
            if (!CoordinateValidator.Validate(originLatitude, originLongitude))
            {
                throw new ArgumentException("Invalid origin coordinates supplied.");
            }

            if (!CoordinateValidator.Validate(destinationLatitude, destinationLongitude))
            {
                throw new ArgumentException("Invalid destination coordinates supplied.");
            }

            double num = (destinationLongitude - originLongitude).ToRadian();
            double x = Math.Log(Math.Tan(destinationLatitude.ToRadian() / 2.0 + Math.PI / 4.0) / Math.Tan(originLatitude.ToRadian() / 2.0 + Math.PI / 4.0));
            if (Math.Abs(num) > Math.PI)
            {
                num = ((num > 0.0) ? (0.0 - (Math.PI * 2.0 - num)) : (Math.PI * 2.0 + num));
            }

            return Math.Atan2(num, x).ToBearing();
        }

        public static double GetBearing(Coordinate originCoordinate, Coordinate destinationCoordinate)
        {
            return GetBearing(originCoordinate.Latitude, originCoordinate.Longitude, destinationCoordinate.Latitude, destinationCoordinate.Longitude);
        }

        public static string GetDirection(double originLatitude, double originLongitude, double destinationLatitude, double destinationLongitude)
        {
            if (!CoordinateValidator.Validate(originLatitude, originLongitude))
            {
                throw new ArgumentException("Invalid origin coordinates supplied.");
            }

            if (!CoordinateValidator.Validate(destinationLatitude, destinationLongitude))
            {
                throw new ArgumentException("Invalid destination coordinates supplied.");
            }

            double bearing = GetBearing(originLatitude, originLongitude, destinationLatitude, destinationLongitude);
            if (bearing >= 337.5 || bearing <= 22.5)
            {
                return "N";
            }

            if (bearing > 22.5 && bearing <= 67.5)
            {
                return "NE";
            }

            if (bearing > 67.5 && bearing <= 112.5)
            {
                return "E";
            }

            if (bearing > 112.5 && bearing <= 157.5)
            {
                return "SE";
            }

            if (bearing > 157.5 && bearing <= 202.5)
            {
                return "S";
            }

            if (bearing > 202.5 && bearing <= 247.5)
            {
                return "SW";
            }

            if (bearing > 247.5 && bearing <= 292.5)
            {
                return "W";
            }

            if (bearing > 292.5 && bearing < 337.5)
            {
                return "NW";
            }

            return string.Empty;
        }

        public static string GetDirection(Coordinate originCoordinate, Coordinate destinationCoordinate)
        {
            return GetDirection(originCoordinate.Latitude, originCoordinate.Longitude, destinationCoordinate.Latitude, destinationCoordinate.Longitude);
        }

        private static double GetRadius(DistanceUnit distanceUnit)
        {
            return distanceUnit switch
            {
                DistanceUnit.Kilometers => EarthRadiusInKilometers,
                DistanceUnit.Meters => EarthRadiusInMeters,
                DistanceUnit.NauticalMiles => EarthRadiusInNauticalMiles,
                _ => EarthRadiusInMiles,
            };
        }
    }
}
