using Application;
using Domain;
using Shouldly;

namespace Testing
{
    internal partial class BoardShould 
    {
        private Board board;
        private Position startingPosition;

        protected override void before_each()
        {
            base.before_each();
            board = null!;
            startingPosition = null!;
        }

        public void A_Board()
        {
            board = new Board(new Position(0,0));
        }

        public void A_Board_With_Starting_Position(Position startingPosition)
        {
            board = new Board(startingPosition);
            this.startingPosition = startingPosition;
        }

        public void Moving_A_Player(Board.Direction direction)
        {
            board.MovePlayer(direction);
        }

        public void The_Player_Moves_To(Position position)
        {
            board.GetPlayerPosition().ShouldBe(position);
        }

        public void Moving_A_Player_Up()
        {
            board.MovePlayer(Board.Direction.Up);
        }

        public void Moving_A_Player_Down()
        {
            board.MovePlayer(Board.Direction.Down);
        }

        public void Moving_A_Player_Right()
        {
            board.MovePlayer(Board.Direction.Right);
        }

        public void The_Player_Moves_Up_Twice()
        {
            board.GetPlayerPosition().VerticalPosition.ShouldBe(2);
        }

        public void The_Player_Does_Not_Move()
        {
            board.GetPlayerPosition().ShouldBe(this.startingPosition);
        }

    }
}
