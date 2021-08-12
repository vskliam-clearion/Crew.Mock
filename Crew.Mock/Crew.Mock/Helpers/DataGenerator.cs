using System;
using System.Collections.Generic;

namespace Crew.Mock.Helpers
{
    public static class DataGenerator
    {
        public static Dictionary<string, string> FakeProperties { get; private set; }
        public static Dictionary<string, string> NewFakeProperties => GenerateFakeProperties();

        public static bool Chance50Percents => Random.Next(2) == 0;
        public static bool Chance33Percents => Random.Next(3) == 0;
        public static bool Chance25Percents => Random.Next(4) == 0;
        public static bool Chance10Percent => Random.Next(10) == 0;

        public static Random Random { get; } = new Random();
        static DataGenerator()
        {
            FakeProperties = GenerateFakeProperties();
        }

        private static Dictionary<string, string> GenerateFakeProperties()
        {
            var properties = new Dictionary<string, string>();

            if (Random.Next(2) == 0)
                properties.Add("networkType", "WiFi");
            else
                properties.Add("networkType", "Cellular");

            if (Random.Next(2) == 0)
                properties.Add("isFirstStart", "True");
            else
                properties.Add("isFirstStart", "False");

            return properties;
        }
    }
}
