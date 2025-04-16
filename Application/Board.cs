
using Domain;

namespace Application
{
    public class Board(Position startingPosition)
    {
        private Position playerPosition = startingPosition;
        public enum Direction
        {
            Up,
            Down,
            Right,
            Left
        }

        public void MovePlayer(Direction direction)
        {
            switch (direction)
            {
                case Direction.Up:
                    playerPosition = new Position(playerPosition.HorizontalPosition, playerPosition.VerticalPosition + 1);
                    break;
                case Direction.Down:
                    if (IsPlayerAtStartPosition()) break;
                    playerPosition = new Position(playerPosition.HorizontalPosition, playerPosition.VerticalPosition - 1);
                    break;
                case Direction.Right:
                    playerPosition = new Position(playerPosition.HorizontalPosition + 1, playerPosition.VerticalPosition);
                    break;
                case Direction.Left:
                    playerPosition = new Position(playerPosition.HorizontalPosition -1, playerPosition.VerticalPosition);
                    break;
            }
        }

        private bool IsPlayerAtStartPosition()
        {
            return playerPosition == new Position(0,0);
        }

        public Position GetPlayerPosition()
        {
            return playerPosition;
        }
    }
}
