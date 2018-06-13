using Api.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Api.Services
{
    public class StationsDataLoader: IStationsDataLoader
    {
        private Dictionary<String, GeoLocation> stationLocationCache;
        public GeoLocation getStationLocation(String station)
        {
            if (stationLocationCache == null)
            {
                loadCache();

            }
            stationLocationCache.TryGetValue(station, out GeoLocation geoLocation);
            return geoLocation;
        }
        private const string MTAURI = "http://web.mta.info/developers/data/nyct/subway/google_transit.zip";

        public async Task loadCache()
        {

            using (WebClient webClient = new WebClient())
            {
                Stream data = webClient.OpenRead(MTAURI);
                
                using (var zipArchive = new ZipArchive(data))
                {
                    ZipArchiveEntry entry = zipArchive.GetEntry("stops.txt");
                    using (StreamReader sr = new StreamReader(entry.Open()))
                    {
                        string line;
                        var stationLocationMap = new Dictionary<string, GeoLocation>();
                        Boolean isHeaderLine = true;
                        while ((line = sr.ReadLine()) != null)
                        {
                            if (!isHeaderLine) {
                                addNewCityToDic(line, stationLocationMap);
                            }
                            isHeaderLine = false;
                        }
                        stationLocationCache = stationLocationMap;
                    }

                }

            }
        }


        private void addNewCityToDic(string line, Dictionary<string, GeoLocation> stationLocationMap)
        {
            //TODO: create a csv reader (fail safe)
            string[] fields = line.Split(',');
            if (!stationLocationMap.ContainsKey(fields[2]))
            {
                stationLocationMap.Add(fields[2], new GeoLocation(Convert.ToDecimal(fields[4]), Convert.ToDecimal(fields[5])));

            }
        }
    }
}