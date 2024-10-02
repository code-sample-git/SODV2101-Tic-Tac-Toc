
using System;

public delegate void PlayerMovedEventHandler(int row, int col, Player player);

public class TicTacToeGame
{
    private GameBoard gameBoard;
    private Player currentPlayer;

    public event PlayerMovedEventHandler PlayerMoved;

    public TicTacToeGame()
    {
        gameBoard = new GameBoard();
        currentPlayer = Player.X;
    }

    public void ResetGame()
    {
        gameBoard.ResetBoard();
        currentPlayer = Player.X;
    }

    public Player GetCurrentPlayer()
    {
        return currentPlayer;
    }

    public bool MakeMove(int row, int col)
    {
        if (gameBoard.IsCellEmpty(row, col))
        {
            gameBoard.SetCell(row, col, currentPlayer);
            PlayerMoved?.Invoke(row, col, currentPlayer);
            currentPlayer = currentPlayer == Player.X ? Player.O : Player.X;
            return true;
        }
        return false;
    }

    public Player? CheckWinner()
    {
        return gameBoard.CheckForWinner();
    }
}
