
namespace Domain
{
    public class Landmine(Position position)
    {
        public Position Position { get; } = position;
        private bool hasDetonated  = false;

        public void Detonate()
        {
            hasDetonated = true;
        }

        public bool HasDetonated()
        {
            return hasDetonated;
        }
    };
}
