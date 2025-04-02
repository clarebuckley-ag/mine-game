using Application;
using Shouldly;

namespace Testing
{
    internal partial class BoardShould 
    {
        private Board board;
        protected override void before_each()
        {
            base.before_each();
            board = null!;
        }

        public void A_Board()
        {
            board = new Board();
        }

        public void Moving_A_Player_Up()
        {
            board.MovePlayerUp();
        }

        public void Moving_A_Player_Down()
        {
            board.MovePlayerDown();
        }

        public void The_Player_Moves_Up()
        {
            board.GetPlayerPosition().ShouldBe(1);
        }

        public void The_Player_Moves_Up_Twice()
        {
            board.GetPlayerPosition().ShouldBe(2);
        }


        public void The_Player_Does_Not_Move()
        {
            board.GetPlayerPosition().ShouldBe(0);
        }
    }
}
