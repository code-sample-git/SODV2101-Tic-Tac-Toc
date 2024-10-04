
public class GameBoard
{
    private Player?[,] board;

    public GameBoard()
    {
        board = new Player?[3, 3];
    }

    public void ResetBoard()
    {
        board = new Player?[3, 3];
    }

    public bool IsCellEmpty(int row, int col)
    {
        return board[row, col] == null;
    }

    public void SetCell(int row, int col, Player player)
    {
        board[row, col] = player;
    }

    public Player? GetCell(int row, int col)
    {
        return board[row, col];
    }

    public Player? CheckForWinner()
    {
        // Logic for checking rows, columns, and diagonals for a winner
        for (int i = 0; i < 3; i++)
        {
            // Check rows
            if (board[i, 0] != null && board[i, 0] == board[i, 1] && board[i, 1] == board[i, 2])
                return board[i, 0];
            // Check columns
            if (board[0, i] != null && board[0, i] == board[1, i] && board[1, i] == board[2, i])
                return board[0, i];
        }

        // Check diagonals
        if (board[0, 0] != null && board[0, 0] == board[1, 1] && board[1, 1] == board[2, 2])
            return board[0, 0];
        if (board[0, 2] != null && board[0, 2] == board[1, 1] && board[1, 1] == board[2, 0])
            return board[0, 2];

        return null;
    }
}
