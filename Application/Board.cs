
namespace Application
{
    public class Board
    {
        private int playerPosition = 0;
        public enum Direction
        {
            Up,
            Down
        }

        public void MovePlayer(Direction direction)
        {
            switch (direction)
            {
                case Direction.Up:
                    playerPosition++;
                    break;
                case Direction.Down:
                    playerPosition--;
                    break;

            }

        }

        public int GetPlayerPosition()
        {
            return playerPosition;
        }
    }
}
