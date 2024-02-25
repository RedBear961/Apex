using Core.Common;
using Core.Entity;

namespace Core.Generators
{
    public class StarSystemGenerator
    {
        public class Configuration
        {
            public ClosedRange Temperature;
            
            // public static Configuration Default()
            // {
            //     return new Configuration();
            // }
        }

        private Configuration _configuration;

        public StarSystemGenerator(Configuration configuration)
        {
            this._configuration = configuration;
        }
    
        public StarSystem Generate()
        {
            
            return new StarSystem(new Star());
        }
    }
}