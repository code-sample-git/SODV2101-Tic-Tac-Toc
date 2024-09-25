using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace SODV2101_Tic_Tac_Toc
{
    public partial class Form1 : Form
    {
        private SmallGrid[,] smallGrids;       // Array to hold the small grids
        private string[,] mainGameBoard;       // Represents the main game board state
        private string currentPlayer;          // Keeps track of whose turn it is (X or O)

        public Form1()
        {
            InitializeComponent();
            InitializeMainBoard();
        }

        // Initialize the main game board with small grids
        private void InitializeMainBoard()
        {
            currentPlayer = "X";                      // X always starts
            mainGameBoard = new string[3, 3];         // Main board state
            smallGrids = new SmallGrid[3, 3];         // Array of small grids

            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    SmallGrid smallGrid = new SmallGrid();
                    smallGrid.Dock = DockStyle.Fill;
                    smallGrid.GetCurrentPlayer = () => currentPlayer;
                    smallGrid.MoveMade += SmallGrid_MoveMade;
                    smallGrid.GridWon += SmallGrid_GridWon;
                    smallGrids[row, col] = smallGrid;
                    mainBoard.Controls.Add(smallGrid, col, row);
                }
            }
        }

        // Event handler when a move is made in any small grid
        private void SmallGrid_MoveMade(object sender, EventArgs e)
        {
            // Switch turns
            currentPlayer = currentPlayer == "X" ? "O" : "X";
        }

        // Event handler when a small grid is won
        private void SmallGrid_GridWon(object sender, SmallGrid.GridWonEventArgs e)
        {
            SmallGrid wonGrid = sender as SmallGrid;

            // Find the position of the won grid
            int row = -1, col = -1;
            for (int r = 0; r < 3; r++)
            {
                for (int c = 0; c < 3; c++)
                {
                    if (smallGrids[r, c] == wonGrid)
                    {
                        row = r;
                        col = c;
                        break;
                    }
                }
                if (row != -1) break;
            }

            // Mark the main game board
            mainGameBoard[row, col] = e.Winner;

            // Overlay a label to indicate the winner
            Label winnerLabel = new Label
            {
                Text = e.Winner,
                Dock = DockStyle.Fill,
                Font = new Font("Arial", 48),
                TextAlign = ContentAlignment.MiddleCenter,
                BackColor = Color.FromArgb(128, Color.White),
                ForeColor = Color.Red
            };
            wonGrid.Controls.Add(winnerLabel);
            winnerLabel.BringToFront();

            // Disable the SmallGrid
            wonGrid.Enabled = false;

            // Check if the current player has won the main game
            if (CheckForMainWinner())
            {
                MessageBox.Show($"{e.Winner} wins the game!");
                ResetMainGame();
            }
            else if (IsMainBoardFull())
            {
                MessageBox.Show("It's a draw!");
                ResetMainGame();
            }
        }

        // Check if the current player has won the main game
        private bool CheckForMainWinner()
        {
            string player = currentPlayer == "X" ? "O" : "X"; // Since we already switched player

            // Check rows
            for (int i = 0; i < 3; i++)
            {
                if (mainGameBoard[i, 0] == player &&
                    mainGameBoard[i, 1] == player &&
                    mainGameBoard[i, 2] == player)
                    return true;
            }

            // Check columns
            for (int i = 0; i < 3; i++)
            {
                if (mainGameBoard[0, i] == player &&
                    mainGameBoard[1, i] == player &&
                    mainGameBoard[2, i] == player)
                    return true;
            }

            // Check diagonals
            if (mainGameBoard[0, 0] == player &&
                mainGameBoard[1, 1] == player &&
                mainGameBoard[2, 2] == player)
                return true;

            if (mainGameBoard[0, 2] == player &&
                mainGameBoard[1, 1] == player &&
                mainGameBoard[2, 0] == player)
                return true;

            return false;
        }

        // Check if the main board is full (for a draw condition)
        private bool IsMainBoardFull()
        {
            foreach (var cell in mainGameBoard)
            {
                if (string.IsNullOrEmpty(cell))
                    return false;
            }
            return true;
        }

        // Reset the main game to start a new game
        private void ResetMainGame()
        {
            // Reset the main game board
            mainGameBoard = new string[3, 3];
            currentPlayer = "X";

            // Reset all SmallGrids
            for (int r = 0; r < 3; r++)
            {
                for (int c = 0; c < 3; c++)
                {
                    smallGrids[r, c].ResetGame();
                    smallGrids[r, c].Enabled = true;

                    // Remove any overlay labels
                    foreach (Control control in smallGrids[r, c].Controls)
                    {
                        if (control is Label)
                        {
                            smallGrids[r, c].Controls.Remove(control);
                            control.Dispose();
                            break;
                        }
                    }
                }
            }
        }
    }
}
