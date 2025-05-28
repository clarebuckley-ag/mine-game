
using Domain;

namespace Application
{
    public class Board(Position startingPosition, BoardDimensions boardDimensions, List<Landmine> landmines)
    {
        private Player player = new Player(startingPosition);
        private readonly BoardDimensions boardDimensions = boardDimensions;
        private readonly List<Landmine> landmines = landmines;
        private bool hasWon = false;

        public enum Direction
        {
            Up,
            Down,
            Right,
            Left
        }
        
        public void MovePlayer(Direction direction)
        {
            if (!IsPlayerAlive())
            {
                return;
            }
            switch (direction)
            {
                case Direction.Up:
                    if (WillPlayerMoveOutOfBounds(Direction.Up)) break;
                    player.SetPosition(new Position(player.GetPosition().HorizontalPosition, player.GetPosition().VerticalPosition + 1));
                    break;
                case Direction.Down:
                    if (WillPlayerMoveOutOfBounds(Direction.Down)) break;
                    player.SetPosition(new Position(player.GetPosition().HorizontalPosition, player.GetPosition().VerticalPosition - 1));
                    break;
                case Direction.Right:
                    if (WillPlayerMoveOutOfBounds(Direction.Right)) break;
                    player.SetPosition(new Position(player.GetPosition().HorizontalPosition + 1, player.GetPosition().VerticalPosition));
                    break;
                case Direction.Left:
                    if (WillPlayerMoveOutOfBounds(Direction.Left)) break;
                    player.SetPosition(new Position(player.GetPosition().HorizontalPosition - 1, player.GetPosition().VerticalPosition));
                    break;
            }

            DetonateLandmine();
            CheckWinCondition();
        }

        public void DetonateLandmine()
        {
            Landmine landmine = landmines.FirstOrDefault(x => x.Position.Equals(player.GetPosition()) && !x.HasDetonated());
            if (landmine == null) return;
            player.StepOnLandmine(landmine);
        }

        public void CheckWinCondition()
        {
            if (!IsPlayerAlive()) return;
            if (GetPlayerPosition().VerticalPosition == boardDimensions.Height - 1) {
                hasWon = true;
            };
        }

        public int GetDetonations()
        {
            return landmines.Where(x => x.HasDetonated()).Count();
        }

        public bool IsPlayerAlive()
        {
            return player.IsAlive();
        }

        public bool HasWonGame()
        {
           return hasWon;
        }

        private bool WillPlayerMoveOutOfBounds(Direction direction)
        {
            switch (direction)
            {
                case Direction.Up:
                    return player.GetPosition().VerticalPosition >= boardDimensions.Height -1;
                case Direction.Down:
                    return player.GetPosition().VerticalPosition < 1;
                case Direction.Left:
                    return player.GetPosition().HorizontalPosition < 1;
                case Direction.Right:
                    return player.GetPosition().HorizontalPosition >= boardDimensions.Width - 1;
                default:
                    return false;
            }
        }

        public Position GetPlayerPosition()
        {
            return player.GetPosition();
        }

    }
}
