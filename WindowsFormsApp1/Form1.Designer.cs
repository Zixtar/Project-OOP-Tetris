﻿
namespace WindowsFormsApp1
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
            this.panelAlegere = new System.Windows.Forms.Panel();
            this.panelPiesa3 = new System.Windows.Forms.Panel();
            this.panelPiesa2 = new System.Windows.Forms.Panel();
            this.panelPiesa1 = new System.Windows.Forms.Panel();
            this.btnConnect = new System.Windows.Forms.Button();
            this.textConnect = new System.Windows.Forms.TextBox();
            this.labelScore = new System.Windows.Forms.Label();
            this.player1Score = new System.Windows.Forms.Label();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.volumeLabel = new System.Windows.Forms.Label();
            this.panelTab = new WindowsFormsApp1.SelectablePanel();
            this.panelAlegere.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelAlegere
            // 
            this.panelAlegere.BackColor = System.Drawing.SystemColors.MenuText;
            this.panelAlegere.Controls.Add(this.panelPiesa3);
            this.panelAlegere.Controls.Add(this.panelPiesa2);
            this.panelAlegere.Controls.Add(this.panelPiesa1);
            this.panelAlegere.Location = new System.Drawing.Point(242, 200);
            this.panelAlegere.Name = "panelAlegere";
            this.panelAlegere.Size = new System.Drawing.Size(264, 142);
            this.panelAlegere.TabIndex = 2;
            this.panelAlegere.Paint += new System.Windows.Forms.PaintEventHandler(this.panelAlegere_Paint);
            // 
            // panelPiesa3
            // 
            this.panelPiesa3.Enabled = false;
            this.panelPiesa3.Location = new System.Drawing.Point(189, 37);
            this.panelPiesa3.Name = "panelPiesa3";
            this.panelPiesa3.Size = new System.Drawing.Size(48, 55);
            this.panelPiesa3.TabIndex = 2;
            this.panelPiesa3.MouseClick += new System.Windows.Forms.MouseEventHandler(this.panelPiesa3_MouseClick);
            // 
            // panelPiesa2
            // 
            this.panelPiesa2.Enabled = false;
            this.panelPiesa2.Location = new System.Drawing.Point(116, 34);
            this.panelPiesa2.Name = "panelPiesa2";
            this.panelPiesa2.Size = new System.Drawing.Size(53, 58);
            this.panelPiesa2.TabIndex = 1;
            this.panelPiesa2.MouseClick += new System.Windows.Forms.MouseEventHandler(this.panelPiesa2_MouseClick);
            // 
            // panelPiesa1
            // 
            this.panelPiesa1.Enabled = false;
            this.panelPiesa1.Location = new System.Drawing.Point(47, 41);
            this.panelPiesa1.Name = "panelPiesa1";
            this.panelPiesa1.Size = new System.Drawing.Size(54, 52);
            this.panelPiesa1.TabIndex = 0;
            this.panelPiesa1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.panelPiesa1_MouseClick);
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(246, 147);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(96, 31);
            this.btnConnect.TabIndex = 3;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // textConnect
            // 
            this.textConnect.Location = new System.Drawing.Point(246, 101);
            this.textConnect.Name = "textConnect";
            this.textConnect.Size = new System.Drawing.Size(96, 20);
            this.textConnect.TabIndex = 4;
            this.textConnect.Text = "127.0.0.1";
            // 
            // labelScore
            // 
            this.labelScore.AutoSize = true;
            this.labelScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelScore.Location = new System.Drawing.Point(243, 34);
            this.labelScore.Name = "labelScore";
            this.labelScore.Size = new System.Drawing.Size(44, 13);
            this.labelScore.TabIndex = 5;
            this.labelScore.Text = "Score:";
            // 
            // player1Score
            // 
            this.player1Score.AutoSize = true;
            this.player1Score.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.player1Score.Location = new System.Drawing.Point(286, 34);
            this.player1Score.Name = "player1Score";
            this.player1Score.Size = new System.Drawing.Size(14, 13);
            this.player1Score.TabIndex = 6;
            this.player1Score.Text = "0";
            // 
            // trackBar1
            // 
            this.trackBar1.LargeChange = 10;
            this.trackBar1.Location = new System.Drawing.Point(440, 34);
            this.trackBar1.Maximum = 40;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(132, 45);
            this.trackBar1.TabIndex = 7;
            this.trackBar1.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // volumeLabel
            // 
            this.volumeLabel.AutoSize = true;
            this.volumeLabel.Location = new System.Drawing.Point(469, 17);
            this.volumeLabel.Name = "volumeLabel";
            this.volumeLabel.Size = new System.Drawing.Size(73, 13);
            this.volumeLabel.TabIndex = 8;
            this.volumeLabel.Text = "Music Volume";
            // 
            // panelTab
            // 
            this.panelTab.BackColor = System.Drawing.Color.MediumOrchid;
            this.panelTab.Location = new System.Drawing.Point(23, 17);
            this.panelTab.Name = "panelTab";
            this.panelTab.Size = new System.Drawing.Size(197, 313);
            this.panelTab.TabIndex = 9;
            this.panelTab.TabStop = true;
            this.panelTab.Paint += new System.Windows.Forms.PaintEventHandler(this.panelTab_Paint);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 390);
            this.Controls.Add(this.panelTab);
            this.Controls.Add(this.volumeLabel);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.player1Score);
            this.Controls.Add(this.labelScore);
            this.Controls.Add(this.textConnect);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.panelAlegere);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseClick);
            this.panelAlegere.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panelAlegere;
        private System.Windows.Forms.Panel panelPiesa3;
        private System.Windows.Forms.Panel panelPiesa2;
        private System.Windows.Forms.Panel panelPiesa1;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.TextBox textConnect;
        private System.Windows.Forms.Label labelScore;
        private System.Windows.Forms.Label player1Score;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Label volumeLabel;
        private SelectablePanel panelTab;
    }
}

