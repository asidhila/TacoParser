using System;
using System.Linq;
using System.IO;
using GeoCoordinatePortable;

namespace LoggingKata
{
    class Program
    {
        static readonly ILog logger = new TacoLogger();
        
        const string csvPath ="TacoBell-US-AL.csv";

       

        static void Main(string[] args)
        {

            logger.LogInfo("Log initialized");

            var lines = File.ReadAllLines(csvPath);

            logger.LogInfo($"Lines: {lines[0]}");

           
            var parser = new TacoParser();
        
            var locations = lines.Select(parser.Parse).ToArray();

            ITrackable taco1 = null;
            ITrackable taco2 = null;

            double distance = 0;

            logger.LogInfo("Comparing locations");

            foreach (var locA in locations)
            {
                var geo = new GeoCoordinate(locA.Location.Latitude, locA.Location.Longitude);
                foreach(var locB in locations)
                {
                    var geo2 = new GeoCoordinate(locB.Location.Latitude, locB.Location.Latitude);

                    logger.LogInfo($"{locA.Name}, {locB.Name}");

                     if(geo.GetDistanceTo(geo2) > distance)
                    {
                        logger.LogInfo($"current highest distance is{locB.Name} to {locA.Name}");
                        distance = geo.GetDistanceTo(geo2);

                        taco1 = locA;
                        taco2 = locB;
                    } 
                }
            }

            Console.WriteLine($"{taco1.Name} is {distance}meters from {taco2.Name}");

            



        }

    }


}
       
    


