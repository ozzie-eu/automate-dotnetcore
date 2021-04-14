using System;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace read_settings_file
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Going to display the setting on apsettings.json:");
            var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", true, true);

            var config = builder.Build();
            Console.WriteLine($"Hello Setting: {config["HelloSetting"]}");
            Console.WriteLine($"Email Property Setting: {config["SettingProperties:mail"]}");
        }
    }
}
