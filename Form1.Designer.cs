﻿namespace SODV2101_Tic_Tac_Toc
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
            mainBoard.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            mainBoard.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            mainBoard.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            mainBoard.Dock = DockStyle.Fill;
            mainBoard.Location = new Point(0, 0);
            mainBoard.Name = "mainBoard";
            mainBoard.RowCount = 3;
            mainBoard.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            mainBoard.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            mainBoard.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            mainBoard.Size = new Size(800, 450);
            mainBoard.TabIndex = 0;

            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(mainBoard);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel mainBoard;
    }
}