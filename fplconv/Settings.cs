using System;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace fplconv
{
    class Settings
    {
        internal static Settings Read(string[] args)
        {
            IConfiguration config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: false)
                .AddCommandLine(args)
                .Build();

            var settings = new Settings
            {
                OutputDirectory = config.GetSection("Output Directory").Value,
                Cycle = config.GetSection("AIRAC Cycle").Value,
                Version = config.GetSection("X-Plane Version").Value,
                InputFile = config.GetSection("InputFile").Value
            };

            return settings;
        }

        public Settings()
        {
            Version = "1100 Version";
            Cycle = "CYCLE 1710";
        }

        public string InputFile { get; set; }

        public string OutputDirectory { get; set; }

        public string Version { get; set; }

        public string Cycle { get; set; }

        public void Validate()
        {
            if (string.IsNullOrEmpty(InputFile))
                throw new Exception("Input file not specified");

            if (!File.Exists(InputFile))
                throw new Exception($"Input file ({InputFile}) does not exist");

            if (!Directory.Exists(OutputDirectory))
                throw new Exception($"Output directory ({OutputDirectory}) does not exist");
        }
    }
}
