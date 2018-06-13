using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Model
{
    public class GeoLocation
    {
        public GeoLocation(decimal latitude, decimal longitude)
        {
            this.latitude = latitude;
            this.longitude = longitude;
        }

        private decimal latitude;
        private decimal longitude;

        public decimal Latitude { get => latitude; set => latitude = value; }
        public decimal Longitude { get => longitude; set => longitude = value; }
        public Double compare(GeoLocation that)
        {

            var radiusOfEarth = 6371; // Radius of the earth in km
            var dLat = deg2rad(that.latitude - this.latitude);  // deg2rad below
            var dLon = deg2rad(this.longitude - this.longitude);
            var a =
              squareOfSin(Convert.ToDouble(dLat)) +
              Math.Cos(Convert.ToDouble(deg2rad(this.latitude))) * Math.Cos(Convert.ToDouble(deg2rad(that.latitude))) *
              squareOfSin(Convert.ToDouble(dLon));
            var c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
            var d = radiusOfEarth * c; // Distance in km
            return d;
        }
        private Double squareOfSin(Double d) {
            return Math.Pow(Math.Sin(d / 2), 2);
                }
        private decimal deg2rad(decimal deg)
        {
            return Decimal.Multiply(deg, Convert.ToDecimal(Math.PI / 180));
        }
    }
}
