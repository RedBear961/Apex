namespace Core.Entity
{
    public class StarSystem
    {
        public ICelestialBody Center;

        public StarSystem(ICelestialBody center)
        {
            this.Center = center;
        }
    }
}