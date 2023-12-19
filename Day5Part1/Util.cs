using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day5Part1
{
    internal class Util
    {
        List<int> Seeds;
        Dictionary<int, int> SeedToSoil;
        Dictionary<int, int> SoilToFertilizer;
        Dictionary<int, int> FertilizerToWater;
        Dictionary<int, int> WaterToLight;
        Dictionary<int, int> LightToTemperature;
        Dictionary<int, int> TemperatureToHumidity;
        Dictionary<int, int> HumidityToLocation;


        public Util(string[] lines)
        {
            Seeds = new List<int>();
            SeedToSoil = new Dictionary<int, int>();
            SoilToFertilizer = new Dictionary<int, int>();
            FertilizerToWater = new Dictionary<int, int>();
            WaterToLight = new Dictionary<int, int>();
            LightToTemperature = new Dictionary<int, int>();
            TemperatureToHumidity = new Dictionary<int, int>();
            HumidityToLocation = new Dictionary<int, int>();
            int process = -1;
            foreach (string line in lines)
            {
                
            }
        }
    }
}
