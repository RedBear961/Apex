namespace Core.Entity
{
    public class Galaxy
    {
        public readonly StarSystem[] StarSystems;

        public Galaxy(StarSystem[] starSystems)
        {
            this.StarSystems = starSystems;
        }
    }
}