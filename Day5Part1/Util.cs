using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day5Part1
{
    internal class Util
    {
        long lowest;
        List<long> Seeds;
        List<long[]> SeedsToSoil;
        List<long[]> SoilToFert;
        List<long[]> FertToWater;
        List<long[]> WaterToLight;
        List<long[]> LightToTemp;
        List<long[]> TempToHumid;
        List<long[]> HumidToLoc;
        List<long[]> Location;
        List<string> commands;
        public Util(string[] lines)
        {
            lowest = 0x7fffffffffffffff;
            Seeds = new();
            SeedsToSoil = new();
            SoilToFert = new();
            FertToWater = new();
            WaterToLight = new();
            LightToTemp = new();
            TempToHumid = new();
            HumidToLoc = new();
            Location = new();
            commands = "seed-to-soil map,soil-to-fertilizer map,fertilizer-to-water map,water-to-light map,light-to-temperature map,temperature-to-humidity map,humidity-to-location map".Split(',').ToList();
            int process = -1;
            foreach (string line in lines)
            {
                int comDel = line.IndexOf(':');
                if (comDel > -1)
                {
                    // command line
                    string[] lineItems = line.Split(':', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
                    if (lineItems[0] == "seeds")
                    {
                        string[] values = lineItems[1].Split(' ', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
                        foreach (string value in values)
                        {
                            Seeds.Add(Convert.ToInt64(value));
                        }
                    }
                    else
                    {
                        process = commands.IndexOf(lineItems[0]);
                    }
                }
                else
                {
                    // number line
                    if (line != "")
                    {
                        string[] lineValues = line.Split(' ', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
                        long dest = Convert.ToInt64(lineValues[0]);
                        long source = Convert.ToInt64(lineValues[1]);
                        long range = Convert.ToInt64(lineValues[2]);
                        switch (process)
                        {
                            case 0:
                                SeedsToSoil.Add(new long[] { source, dest, range });
                                break;
                            case 1:
                                SoilToFert.Add(new long[] { source, dest, range });
                                break;
                            case 2:
                                FertToWater.Add(new long[] { source, dest, range });
                                break;
                            case 3:
                                WaterToLight.Add(new long[] { source, dest, range });
                                break;
                            case 4:
                                LightToTemp.Add(new long[] { source, dest, range });
                                break;
                            case 5:
                                TempToHumid.Add(new long[] { source, dest, range });
                                break;
                            case 6:
                                HumidToLoc.Add(new long[] { source, dest, range });
                                break;
                            default:
                                break;
                        }
                    }
                }
            }
            Console.WriteLine("Input file processing completed.");
        }
        public long ProcessSeeds()
        {
            long retValue = 0;

            foreach (long seed in Seeds)
            {
                long soil = -1;
                long fert = -1;
                long water = -1;
                long light = -1;
                long temp = -1;
                long humid = -1;
                long loc = -1;
                foreach (long[] seedsToSoil in SeedsToSoil)
                {
                    long soilMax = seedsToSoil[0] + seedsToSoil[2];
                    if (seed >= seedsToSoil[0] && seed < soilMax)
                    {
                        long diff = seed - seedsToSoil[0];
                        soil = seedsToSoil[1] + diff;
                    }
                }
                soil = soil > -1 ? soil : seed;
                foreach (long[] soilToFert in SoilToFert)
                {
                    long fertMax = soilToFert[0] + soilToFert[2];
                    if (soil >= soilToFert[0] && soil < fertMax)
                    {
                        long diff = soil - soilToFert[0];
                        fert = soilToFert[1] + diff;
                    }
                }
                fert = fert > -1 ? fert : soil;
                foreach (long[] fertToWater in FertToWater)
                {
                    long waterMax = fertToWater[0] + fertToWater[2];
                    if (fert >= fertToWater[0] && fert < waterMax)
                    {
                        long diff = fert - fertToWater[0];
                        water = fertToWater[1] + diff;
                    }
                }
                water = water > -1 ? water : fert;
                foreach (long[] waterToLight in WaterToLight)
                {
                    long lightMax = waterToLight[0] + waterToLight[2];
                    if (water >= waterToLight[0] && water < lightMax)
                    {
                        long diff = water - waterToLight[0];
                        light = waterToLight[1] + diff;
                    }
                }
                light = light > -1 ? light : water;
                foreach (long[] lightToTemp in LightToTemp)
                {
                    long tempMax = lightToTemp[0] + lightToTemp[2];
                    if (light >= lightToTemp[0] && light < tempMax)
                    {
                        long diff = light - lightToTemp[0];
                        temp = lightToTemp[1] + diff;
                    }
                }
                temp = temp > -1 ? temp : light;
                foreach (long[] tempToHumid in TempToHumid)
                {
                    long humidMax = tempToHumid[0] + tempToHumid[2]; ;
                    if (temp >= tempToHumid[0] && temp < humidMax)
                    {
                        long diff = temp - tempToHumid[0];
                        humid = tempToHumid[1] + diff;
                    }
                }
                humid = humid > -1 ? humid : temp;
                foreach (long[] humidToLoc in HumidToLoc)
                {
                    long locMax = humidToLoc[0] + humidToLoc[2];
                    if (humid >= humidToLoc[0] && humid < locMax)
                    {
                        long diff = humid - humidToLoc[0];
                        loc = humidToLoc[1] + diff;
                    }
                }
                loc = loc > -1 ? loc : humid;
                lowest = loc < lowest ? loc : lowest;
            }
            retValue = lowest;

            return retValue;
        }
    }
}
