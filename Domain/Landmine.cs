
namespace Domain
{
    public class Landmine(Position position)
    {
        public Position Position { get; } = position;
        public bool HasDetonated { get; set; } = false;
    };
}
