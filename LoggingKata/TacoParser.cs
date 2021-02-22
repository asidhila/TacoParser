namespace LoggingKata
{
    /// <summary>
    /// Parses a POI file to locate all the Taco Bells
    /// </summary>
    public class TacoParser
    {
        readonly ILog logger = new TacoLogger();
        
        public ITrackable Parse(string line)
        {
            string x = "34.073638,-84.677017,Taco Bell Acwort...";

            //cells[0] = "34.073638";
            //cells[1] = "-84.677017";
            //cells[2] = "Taco Bell Acwort...";

            // double lat = 34.073638;

            //double longitude = -84.677017;

            //string name = "Taco Bell Acwort";

            var taco = new TacoBell();

            taco.Name = "Taco Bell Acwort";

            //taco.Location.Longitude =-84.677017;

            //taco.Location.Longitude = 34.073638;

            logger.LogInfo("Begin parsing");
            var cells = line.Split(',');

           
            if (cells.Length < 3)
            {
                logger.LogError("Array Length is less than 3");
               
                return null; 
            }
            
            
            double lat = 0;

            if(!double.TryParse(cells[0], out lat))
            {
                logger.LogInfo($"{cells[0]} was unable to be converted to a double");
            }
           
            double longitude = 0;

            if(!double.TryParse(cells[1],out longitude))
            {
                logger.LogInfo($"{cells[1]} was unable to covenverted to a double");
            }
           
            string name = cells[2];

            
            var point = new Point();

            point.Latitude = lat;
            point.Longitude = longitude;
            taco.Name = name;
            taco.Location = point;
            return taco;
        }
    }
}