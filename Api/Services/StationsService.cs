using Api.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Api.Services
{
    public class StationsService : IStationsService
    {
        StationsDataLoader dataLoader;
        public StationsService(IStationsDataLoader dataLoader)
        {
            this.dataLoader = (StationsDataLoader)dataLoader;
        }
        public double getDistanceBetweenStations(string start, string end)
        {
            if (String.IsNullOrEmpty(start) || String.IsNullOrEmpty(end)){
                throw new ArgumentNullException(String.IsNullOrEmpty(start) ? "start" : "end");
            }
            GeoLocation location1 = dataLoader.getStationLocation(start);
            GeoLocation location2 = dataLoader.getStationLocation(end);
            
            if (location2 != null && location1 != null)
            {
                return location1.compare(location2);
            }
            // error that input cities do not exists
            throw new Exception("Cities are either invalid or are not in repo"); 
        }
    }
}
