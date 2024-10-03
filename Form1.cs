namespace SODV2101_Tic_Tac_Toc
{
    public partial class Form1 : Form
    {
        private TicTacToeGame ticTacToeGame;

        public Form1()
        {
            InitializeComponent();
            InitializeGame();
        }

        // Initialize game logic and UI
        private void InitializeGame()
        {

            ticTacToeGame = new TicTacToeGame();
            ticTacToeGame.PlayerMoved += OnPlayerMoved;
            ticTacToeGame.ResetGame();
            InitializePanels();
            ResetPanels(); // Clear the UI after resetting the game
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
                        BorderStyle = BorderStyle.FixedSingle // Optional: for better visibility
                    };
                    panel.Click += Panel_Click; // Attach click event for each panel
                    this.mainBoard.Controls.Add(panel, col, row);
                }
            }
        }

        // Handle panel click events
        private void Panel_Click(object sender, EventArgs e)
        {
            Panel clickedPanel = sender as Panel;
            if (clickedPanel != null)
            {
                // Determine the row and column of the clicked panel
                var row = this.mainBoard.GetRow(clickedPanel);
                var col = this.mainBoard.GetColumn(clickedPanel);

                // Make a move using the TicTacToeGame class
                if (ticTacToeGame.MakeMove(row, col))
                {
                    // Move was successful, check if there's a winner
                    var winner = ticTacToeGame.CheckWinner();
                    if (winner != null)
                    {
                        MessageBox.Show($"{winner} wins!");
                        ticTacToeGame.ResetGame();
                        ResetPanels(); // Clear the board after the game ends
                    }
                    else if (ticTacToeGame.IsDraw())
                    {
                        MessageBox.Show("It's a draw!");
                        ticTacToeGame.ResetGame();
                        ResetPanels(); // Clear the board after the game ends
                    }
                }
            }
        }



        // Handle the PlayerMoved event to update the UI
        private void OnPlayerMoved(int row, int col, Player player)
        {
            // Find the corresponding panel and update its text to show the player's move
            foreach (Control control in mainBoard.Controls)
            {
                var panel = control as Panel;
                if (panel != null && this.mainBoard.GetRow(panel) == row && this.mainBoard.GetColumn(panel) == col)
                {
                    panel.Controls.Clear();
                    var label = new Label
                    {
                        Text = player.ToString(),
                        Dock = DockStyle.Fill,
                        TextAlign = ContentAlignment.MiddleCenter,
                        Font = new Font("Arial", 24, FontStyle.Bold)
                    };
                    panel.Controls.Add(label);
                }
            }
        }

        // Paint event handler for the mainBoard (optional)
        private void mainBoard_Paint(object sender, PaintEventArgs e)
        {
            // Optional custom drawing code (can be left empty)
        }





        // Clear the UI panels
        private void ResetPanels()
        {
            foreach (Control control in mainBoard.Controls)
            {
                var panel = control as Panel;
                if (panel != null)
                {
                    panel.Controls.Clear(); // Remove any label (X or O)
                }
            }
        }
    }
}
