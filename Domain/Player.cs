
namespace Domain
{
    public class Player(Position position)
    {
        private Position position = position;
        private int lives = 3;

        public bool IsAlive()
        {
            return lives > 0;
        }

        public void StepOnLandmine(Landmine landmine)
        {
            landmine.Detonate();
            lives--;
        }

        public Position GetPosition()
        {
            return position;
        }

        public void SetPosition(Position newPosition)
        {
            position = newPosition;
        }

    };
}