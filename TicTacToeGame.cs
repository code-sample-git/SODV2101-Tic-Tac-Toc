
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

    // Method to check for a draw
    public bool IsDraw()
    {
        for (int row = 0; row < 3; row++)
        {
            for (int col = 0; col < 3; col++)
            {
                if (gameBoard.GetCell(row, col) == null) // If any cell is empty, it's not a draw
                {
                    return false;
                }
            }
        }
        return CheckWinner() == null; // Return true only if there's no winner and the board is full
    }
}
