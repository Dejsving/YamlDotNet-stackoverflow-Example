using System;
using Indusoft.PPS.StartSecondaryProcessesMiniSolver.Input;

namespace YamlDotNet_stackoverflow_Example
{
    class Program
    {
        static void Main(string[] args)
        {
            var settings = Settings.GetFromYamlFile("Settings.yaml");
            settings.SaveToYamlFile("Settings_output.yaml");
            Console.WriteLine("{0:U}", settings.InitialDateTime);
        }
    }
}
