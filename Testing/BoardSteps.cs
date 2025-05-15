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
            board = new Board(new Position(0,0), new BoardDimensions(8,8), []);
        }

        public void A_Board_With_Starting_Position(Position startingPosition)
        {
            board = new Board(startingPosition, new BoardDimensions(8, 8), []);
            this.startingPosition = startingPosition;
        }

        public void A_Board_With_Three_Landmines()
        {
            List<Landmine> landmines = [
                new Landmine(new Position(0, 1)),
                new Landmine(new Position(1, 1)),
                new Landmine(new Position(1, 0)),
             ];
            board = new Board(new Position(0, 0), new BoardDimensions(8, 8), landmines);
        }

        public void A_Board_With_Landmines()
        {
            board = new Board(new Position(0, 0), new BoardDimensions(8, 8), [new Landmine(new Position(0, 1))]);
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

        public void A_Landmine_Has_Detonated(int expectedDetonations)
        {
            board.GetDetonations().ShouldBe(expectedDetonations);
        }

        public void A_Player_Has_Died()
        {
            board.IsPlayerAlive().ShouldBeFalse();
        }
    }
}
