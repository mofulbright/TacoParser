using System;
using Xunit;

namespace LoggingKata.Test
{
    public class TacoParserTests
    {
        //This ensures TacoParser will return a non-null ITrackable object.
        [Fact]
        public void ShouldReturnNull()
        {
            //Arrange
            var tacoParser = new TacoParser();

            //Act
            var actual = tacoParser.Parse("34.073638, -84.677017, Taco Bell Acwort...");

            //Assert
            Assert.NotNull(actual);

        }

        //This will test if Longitude is correctly parsed
        [Theory]
        [InlineData("34.073638, -84.677017, Taco Bell Acwort...", -84.677017)]
        [InlineData("32.503039,-87.821677,Taco Bell Demopoli...", -87.821677)]
        [InlineData("34.764965,-86.48607,Taco Bell Huntsvill...", -86.48607)]
        [InlineData("30.478469,-87.206052,Taco Bell Pensacola...", -87.206052)]
        [InlineData("33.810924,-86.820487,Taco Bell Warrio...", -86.820487)]
        [InlineData("34.872024,-86.571043,Taco Bell Meridianvill...", -86.571043)]
        public void ShouldParseLongitude(string line, double expected)
        {
            //Arrange

            var tacoParserLong = new TacoParser();

            //Act

            var actual = tacoParserLong.Parse(line);

            //Assert
            Assert.Equal(expected, actual.Location.Longitude);
        }
        


        //This will test if Latitude is correctly parsed
        [Theory]
        [InlineData("34.992219, -86.841402, Taco Bell Ardmore...", 34.992219)]
        [InlineData("32.503039,-87.821677,Taco Bell Demopoli...", 32.503039)]
        [InlineData("34.764965,-86.48607,Taco Bell Huntsvill...", 34.764965)]
        [InlineData("30.478469,-87.206052,Taco Bell Pensacola...", 30.478469)]
        [InlineData("33.810924,-86.820487,Taco Bell Warrio...", 33.810924)]
        [InlineData("34.872024,-86.571043,Taco Bell Meridianvill...", 34.872024)]

        public void ShouldParseLatitude(string line, double expected)
        {
            var tacoParserLat = new TacoParser();

            var actual = tacoParserLat.Parse(line);

            Assert.Equal(expected, actual.Location.Latitude);
        }

    }
}
