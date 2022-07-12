using GeoCoordinatePortable;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace LoggingKata
{
    public static class GetDistances
    {
        const string csvPath = "TacoBell-US-AL.csv";

        public static string[] lines = File.ReadAllLines(csvPath);
        public static TacoParser parser = new TacoParser();
        public static ITrackable[] locations = lines.Select(parser.Parse).ToArray();

        public static ITrackable tacoBell1 = null;
        public static ITrackable tacoBell2 = null;

        public static void GetTwoFurthest()
        {
            double distance = 0;
            for (int i = 0; i < locations.Length; i++)
            {
                var locA = locations[i];
                var GeoA = new GeoCoordinate(locA.Location.Latitude, locA.Location.Longitude);
                for (int j = 0; j < locations.Length; j++)
                {
                    var locB = locations[j];
                    var GeoB = new GeoCoordinate(locB.Location.Latitude, locB.Location.Longitude);
                    var newDistance = GeoA.GetDistanceTo(GeoB);
                    if (newDistance > distance)
                    {
                        distance = newDistance;
                        tacoBell1 = locA;
                        tacoBell2 = locB;
                    }
                }
            }
            var distanceMiles = Math.Round(distance / 1609, 2);
            Console.WriteLine($"{tacoBell1.Name} and {tacoBell2.Name} are the furthest apart, and are {distanceMiles} miles apart.");
        }

        public static void GetTwoClosest()
        {
            double distance = 9999999;
            for (int i = 0; i < locations.Length; i++)
            {
                var locA = locations[i];
                var geoA = new GeoCoordinate(locA.Location.Latitude, locA.Location.Longitude);
                for (int j = 0; j < locations.Length; j++)
                {
                    var locB = locations[j];
                    var geoB = new GeoCoordinate(locB.Location.Latitude, locB.Location.Longitude);
                    var newDistance = geoA.GetDistanceTo(geoB);
                    if (newDistance < distance && newDistance != 0)
                    {
                        distance = newDistance;
                        tacoBell1 = locA;
                        tacoBell2 = locB;
                    }
                }
            }
            var distanceMiles = Math.Round(distance / 1609, 2);
            Console.WriteLine($"{tacoBell1.Name} and {tacoBell2.Name} are the closest together, and are {distanceMiles} miles apart.");
        }

        public static void GetShortestTotalDistance()
        {
            var visited = new List<ITrackable>();
            var visitedShortest = new List<ITrackable>();
            double totalDistance = 999999999;
            double currentTotalDistance = 0;

            for (int i = 0; i < locations.Length; i++)
            {
                var startingPoint = locations[i];
                var startingGeo = new GeoCoordinate(startingPoint.Location.Latitude, startingPoint.Location.Longitude);
                var currentGeo = startingGeo;
                currentTotalDistance = 0;
                visited.Clear();
                do
                {                    
                    double distance = 9999999;
                    ITrackable nextPoint = null;
                    for (int j = 0; j < locations.Length; j++)
                    {
                        var potential = locations[j];
                        var potentialGeo = new GeoCoordinate(potential.Location.Latitude, potential.Location.Longitude);
                        var newDistance = currentGeo.GetDistanceTo(potentialGeo);
                        if (newDistance < distance && !visited.Contains(potential))
                        {
                            nextPoint = potential;
                            distance = newDistance;
                        }
                    }
                    visited.Add(nextPoint);
                    currentTotalDistance += currentGeo.GetDistanceTo(new GeoCoordinate(nextPoint.Location.Latitude, nextPoint.Location.Longitude));                   
                    currentGeo = new GeoCoordinate(nextPoint.Location.Latitude, nextPoint.Location.Longitude);
                } while (visited.Count < 237);
                if (currentTotalDistance < totalDistance)
                {
                    totalDistance = currentTotalDistance;
                    visitedShortest = visited;
                }
            }
            foreach (var tb in visitedShortest)
            {
                Console.WriteLine(tb.Name);
            }
            Console.WriteLine(totalDistance / 1609);
        }
    }
}
