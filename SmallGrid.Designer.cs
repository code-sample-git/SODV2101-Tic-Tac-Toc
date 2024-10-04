namespace SODV2101_Tic_Tac_Toc
{
    partial class SmallGrid
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            mainBoard = new TableLayoutPanel();
            SuspendLayout();
            // 
            // mainBoard
            // 
            mainBoard.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            mainBoard.ColumnCount = 3;
            mainBoard.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33F));
            mainBoard.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33F));
            mainBoard.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33F));
            mainBoard.Dock = DockStyle.Fill;
            mainBoard.Location = new Point(0, 0);
            mainBoard.Name = "mainBoard";
            mainBoard.RowCount = 3;
            mainBoard.RowStyles.Add(new RowStyle(SizeType.Percent, 33.33F));
            mainBoard.RowStyles.Add(new RowStyle(SizeType.Percent, 33.33F));
            mainBoard.RowStyles.Add(new RowStyle(SizeType.Percent, 33.33F));
            mainBoard.Size = new Size(700, 750);
            mainBoard.TabIndex = 0;
            mainBoard.Paint += mainBoard_Paint;
            // 
            // SmallGrid
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(mainBoard);
            Name = "SmallGrid";
            Size = new Size(700, 750);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel mainBoard;
    }
}


