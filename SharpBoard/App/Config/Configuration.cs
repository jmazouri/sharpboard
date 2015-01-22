using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using Newtonsoft.Json;
using NLog;
using SharpBoard.App.Models;

namespace SharpBoard.App.Config
{
    public class Configuration
    {
        protected static Logger logger = LogManager.GetCurrentClassLogger();
        private static readonly Lazy<Configuration> LazyConfig = new Lazy<Configuration>(() => new Configuration());

        public static Configuration Instance { get { return LazyConfig.Value; } }

        protected virtual string JsonPath
        {
            get { return ""; }
        }
        protected string JsonData { get; set; }

        protected virtual Configuration Default
        {
            get
            {
                throw new NotImplementedException("Can't get a default from the base configuration class.");
            }
        }

        public virtual void Load()
        {
            if (!File.Exists(JsonPath))
            {
                logger.Error("Path \"{0}\" doesn't exist for the config file. Generating.", JsonPath);
                var newData = Default;

                string tempJsonData = JsonConvert.SerializeObject(newData);

                try
                {
                    File.WriteAllText(tempJsonData, JsonPath);
                }
                catch (Exception ex)
                {
                    logger.ErrorException("Couldn't save the generated config file! Check your paths!", ex);
                    throw;
                }
            }

            try
            {
                JsonData = File.ReadAllText(JsonPath);
            }
            catch (Exception ex)
            {
                logger.Error("Couldn't load the configuration file at \"{0}\"", JsonPath);
                logger.ErrorException("Exception thrown while loading configuration file.", ex);
                throw;
            }
        }
    }
}
