using System;
using System.Linq;
using System.IO;
using GeoCoordinatePortable;
using System.Collections.Generic;

namespace LoggingKata
{
    class Program
    {
        const string csvPath = "TacoBell-US-AL.csv";

        static void Main(string[] args)
        {
            //Console.WriteLine("Welcome to the TacoParser!");
            //Console.WriteLine("Select an option to begin:\n1. Get two Taco Bells that are the furthest apart" +
            //    "\n2. Get two Taco Bells that are the closest\n3.Get a list of taco bells ordered by lowest distace from previous taco bell" +
            //    "\n9. Exit ");
            //int response;
            //do
            //{
            //    response = int.Parse(Console.ReadLine());

            //    if (response == 1 || response == 2)
            //    {
            //        GetDistances.GetDistanceGeneral(response);
            //    }
            //    if (response == 3)
            //    {
            //        GetDistances.GetShortestTotalDistance();
            //    }
            //} while (response != 9);
            //GetDistances.GetTwoClosest();
            //GetDistances.GetTwoFurthest();
            GetDistances.GetShortestTotalDistance();
        }
    }
}
