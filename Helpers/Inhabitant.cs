namespace Cs7.Helpers
{
    public class Inhabitant
    {
        private static volatile int _population = 0;

        private double _mood = 0.5;

        public Inhabitant() => _population += 1;
        ~Inhabitant() => _population -= 1;

        public double Mood
        {
            get => _mood;
            set => _mood = value;
        }
    }
}
