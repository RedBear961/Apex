namespace Core.Generators
{
    using StarSystemConfiguration = StarSystemGenerator.Configuration;
    
    public class GenerationConfigurator
    {
        public StarSystemConfiguration GetStarSystemConfiguration()
        {
            return new StarSystemConfiguration();
        }
    }
}