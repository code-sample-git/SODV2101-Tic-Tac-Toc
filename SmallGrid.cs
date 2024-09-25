namespace SODV2101_Tic_Tac_Toc
{
        public partial class SmallGrid : UserControl
    {
            private string currentPlayer; // Keeps track of whose turn it is (X or O)
            private string[,] gameBoard;  // A 3x3 array to represent the state of the board

            public SmallGrid()
            {

                InitializeComponent();
                InitializeGame();
            }

            // Initialize game logic
            private void InitializeGame()
            {
                gameBoard = new string[3, 3]; // Empty grid
                InitializePanels(); // Set up panels
        }

        // Initialize the panels for the 3x3 grid and attach click events
            private void InitializePanels()
            {
                for (int row = 0; row < 3; row++)
                {
                    for (int col = 0; col < 3; col++)
                    {
                        var panel = new Panel
                        {
                            Name = $"panel{row}{col}",
                            Dock = DockStyle.Fill,
                            BorderStyle = BorderStyle.FixedSingle // Optional
                        };
                        panel.Click += Panel_Click; // Attach click event
                        mainBoard.Controls.Add(panel, col, row);
                    }
                }
            }


        // Handle panel click events
            public Func<string> GetCurrentPlayer { get; set; } // Delegate to get current player
            public event EventHandler MoveMade; // Event to notify move made
            public event EventHandler<GridWonEventArgs> GridWon; // Event when grid is won
 
        private void Panel_Click(object sender, EventArgs e)
            {
                Panel clickedPanel = sender as Panel;
                if (clickedPanel != null)
                {
                    // Get current player from the main form
                    string currentPlayer = GetCurrentPlayer();

                    // Determine the row and column of the clicked panel
                    var row = mainBoard.GetRow(clickedPanel);
                    var col = mainBoard.GetColumn(clickedPanel);

                    // If the cell is already occupied, do nothing
                    if (!string.IsNullOrEmpty(gameBoard[row, col]))
                        return;

                    // Mark the board and update the clicked panel
                    gameBoard[row, col] = currentPlayer;
                    clickedPanel.Controls.Add(new Label
                    {
                        Text = currentPlayer,
                        Dock = DockStyle.Fill,
                        Font = new Font("Arial", 24),
                        TextAlign = ContentAlignment.MiddleCenter
                    });

                    // Check if the current player has won
                    if (CheckForWinner())
                    {
                        GridWon?.Invoke(this, new GridWonEventArgs { Winner = currentPlayer });
                        mainBoard.Enabled = false; // Disable further clicks
                        return;
                }

                    // Check for a draw
                    if (IsBoardFull())
                    {
                        // Optionally handle draw condition
                        mainBoard.Enabled = false;
                        return;
                    }

                    // Notify that a move has been made
                    MoveMade?.Invoke(this, EventArgs.Empty);
                }
            }


        // Check if the board is full (for a draw condition)
        private bool IsBoardFull()
            {
                foreach (var cell in gameBoard)
                {
                    if (string.IsNullOrEmpty(cell))
                    {
                        return false;
                    }
                }
                return true;
            }

            // Check if the current player has won the game
            private bool CheckForWinner()
            {
                // Check rows, columns, and diagonals for a win
                for (int i = 0; i < 3; i++)
                {
                    // Check rows
                    if (gameBoard[i, 0] == currentPlayer && gameBoard[i, 1] == currentPlayer && gameBoard[i, 2] == currentPlayer)
                    {
                        return true;
                    }

                    // Check columns
                    if (gameBoard[0, i] == currentPlayer && gameBoard[1, i] == currentPlayer && gameBoard[2, i] == currentPlayer)
                    {
                        return true;
                    }
                }

                // Check diagonals
                if (gameBoard[0, 0] == currentPlayer && gameBoard[1, 1] == currentPlayer && gameBoard[2, 2] == currentPlayer)
                {
                    return true;
                }

                if (gameBoard[0, 2] == currentPlayer && gameBoard[1, 1] == currentPlayer && gameBoard[2, 0] == currentPlayer)
                {
                    return true;
                }

                return false;
            }

        // Reset the game board to start a new game
            public void ResetGame()
            {
                gameBoard = new string[3, 3]; // Clear the board
                mainBoard.Enabled = true; // Enable the grid

                // Clear the controls from each panel
                foreach (Control control in mainBoard.Controls)
                {
                    control.Controls.Clear();
                }
            }

            public class GridWonEventArgs : EventArgs
            {
                public string Winner { get; set; }
            }

        // Paint event handler for the mainBoard (optional)
        private void mainBoard_Paint(object sender, PaintEventArgs e)
            {
                // Optional custom drawing code (can be left empty)
            }
        }
 }
