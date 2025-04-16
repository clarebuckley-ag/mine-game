﻿using System.Security.Cryptography;
using Application;
using Domain;
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
            board = new Board(new Position(0,0));
        }

        public void A_Board_With_Starting_Position_1_1()
        {
            board = new Board(new Position(1,1));
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
            board.GetPlayerPosition().VerticalPosition.ShouldBe(0);
            board.GetPlayerPosition().HorizontalPosition.ShouldBe(0);
        }

    }
}
