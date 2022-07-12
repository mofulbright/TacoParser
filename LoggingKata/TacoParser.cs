namespace LoggingKata
{
    /// <summary>
    /// Parses a POI file to locate all the Taco Bells
    /// </summary>
    public class TacoParser
    { 
        public ITrackable Parse(string line)
        {
            var cells = line.Split(',');


            var lat = cells[0];
            var lon = cells[1];
            var name = cells[2];

            var latNum = double.Parse(lat);
            var lonNum = double.Parse(lon);

            var tacoBell = new TacoBell(latNum, lonNum, name);
            return tacoBell;
        }
    }
}