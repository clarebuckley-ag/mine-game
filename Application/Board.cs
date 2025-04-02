
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
                    if (IsPlayerAtStartPosition()) break;
                    playerPosition--;
                    break;
            }

        }

        private bool IsPlayerAtStartPosition()
        {
            return playerPosition == 0;
        }


        public int GetPlayerPosition()
        {
            return playerPosition;
        }
    }
}
