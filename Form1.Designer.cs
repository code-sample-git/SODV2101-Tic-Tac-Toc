namespace SODV2101_Tic_Tac_Toc
{
    partial class Form1
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
            mainBoard.ColumnCount = 3;
            mainBoard.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33F));
            mainBoard.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33F));
            mainBoard.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33F));
            mainBoard.Dock = DockStyle.Fill;
            mainBoard.Location = new Point(0, 0);
            mainBoard.Margin = new Padding(3, 4, 3, 4);
            mainBoard.Name = "mainBoard";
            mainBoard.RowCount = 3;
            mainBoard.RowStyles.Add(new RowStyle(SizeType.Percent, 33.33F));
            mainBoard.RowStyles.Add(new RowStyle(SizeType.Percent, 33.33F));
            mainBoard.RowStyles.Add(new RowStyle(SizeType.Percent, 33.33F));
            mainBoard.Size = new Size(800, 1000);
            mainBoard.TabIndex = 0;
            mainBoard.Paint += mainBoard_Paint;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 1000);
            Controls.Add(mainBoard);
            Margin = new Padding(3, 4, 3, 4);
            Name = "Form1";
            Text = "Ultimate Tic Tac Toe";
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel mainBoard;
    }
}


