
using Domain;

namespace Application
{
    public class Board(Position startingPosition, BoardDimensions boardDimensions, List<Landmine> landmines)
    {
        private Position playerPosition = startingPosition;
        private readonly BoardDimensions boardDimensions = boardDimensions;
        private readonly List<Landmine> landmines = landmines;
        private int detonations = 0;

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

            DetonateLandmine();
        }

        public void DetonateLandmine()
        {
            Landmine landmine = landmines.FirstOrDefault(x => x.Position.Equals(playerPosition) && !x.HasDetonated());
            if (landmine == null) return;
            landmine.Detonate();
            detonations++;
        }

        public int GetDetonations()
        {
            return detonations;
        }

        private bool WillPlayerMoveOutOfBounds(Direction direction)
        {
            switch (direction)
            {
                case Direction.Up:
                    return playerPosition.VerticalPosition >= boardDimensions.Height -1;
                case Direction.Down:
                    return playerPosition.VerticalPosition < 1;
                case Direction.Left:
                    return playerPosition.HorizontalPosition < 1;
                case Direction.Right:
                    return playerPosition.HorizontalPosition >= boardDimensions.Width - 1;
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
