
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
                    if (WillPlayerMoveOutOfBounds(Direction.Up)) break;
                    playerPosition = new Position(playerPosition.HorizontalPosition, playerPosition.VerticalPosition + 1);
                    break;
                case Direction.Down:
                    if (WillPlayerMoveOutOfBounds(Direction.Down)) break;
                    playerPosition = new Position(playerPosition.HorizontalPosition, playerPosition.VerticalPosition - 1);
                    break;
                case Direction.Right:
                    if (WillPlayerMoveOutOfBounds(Direction.Right)) break;
                    playerPosition = new Position(playerPosition.HorizontalPosition + 1, playerPosition.VerticalPosition);
                    break;
                case Direction.Left:
                    if (WillPlayerMoveOutOfBounds(Direction.Left)) break;
                    playerPosition = new Position(playerPosition.HorizontalPosition - 1, playerPosition.VerticalPosition);
                    break;
            }
        }

        private bool WillPlayerMoveOutOfBounds(Direction direction)
        {
            switch (direction)
            {
                case Direction.Up:
                    return playerPosition.VerticalPosition >= 7;
                case Direction.Down:
                    return playerPosition.VerticalPosition < 1;
                case Direction.Left:
                    return playerPosition.HorizontalPosition < 1;
                case Direction.Right:
                    return playerPosition.HorizontalPosition >= 7;
                default:
                    return false;
            }
        }

        public Position GetPlayerPosition()
        {
            return playerPosition;
        }
    }
}
