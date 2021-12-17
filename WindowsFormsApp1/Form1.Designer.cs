
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
            this.btnReguli = new System.Windows.Forms.Button();
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
            this.panelAlegere.Location = new System.Drawing.Point(323, 246);
            this.panelAlegere.Margin = new System.Windows.Forms.Padding(4);
            this.panelAlegere.Name = "panelAlegere";
            this.panelAlegere.Size = new System.Drawing.Size(352, 175);
            this.panelAlegere.TabIndex = 2;
            this.panelAlegere.Paint += new System.Windows.Forms.PaintEventHandler(this.panelAlegere_Paint);
            // 
            // panelPiesa3
            // 
            this.panelPiesa3.Enabled = false;
            this.panelPiesa3.Location = new System.Drawing.Point(252, 46);
            this.panelPiesa3.Margin = new System.Windows.Forms.Padding(4);
            this.panelPiesa3.Name = "panelPiesa3";
            this.panelPiesa3.Size = new System.Drawing.Size(64, 68);
            this.panelPiesa3.TabIndex = 2;
            this.panelPiesa3.MouseClick += new System.Windows.Forms.MouseEventHandler(this.panelPiesa3_MouseClick);
            // 
            // panelPiesa2
            // 
            this.panelPiesa2.Enabled = false;
            this.panelPiesa2.Location = new System.Drawing.Point(155, 42);
            this.panelPiesa2.Margin = new System.Windows.Forms.Padding(4);
            this.panelPiesa2.Name = "panelPiesa2";
            this.panelPiesa2.Size = new System.Drawing.Size(71, 71);
            this.panelPiesa2.TabIndex = 1;
            this.panelPiesa2.MouseClick += new System.Windows.Forms.MouseEventHandler(this.panelPiesa2_MouseClick);
            // 
            // panelPiesa1
            // 
            this.panelPiesa1.Enabled = false;
            this.panelPiesa1.Location = new System.Drawing.Point(63, 50);
            this.panelPiesa1.Margin = new System.Windows.Forms.Padding(4);
            this.panelPiesa1.Name = "panelPiesa1";
            this.panelPiesa1.Size = new System.Drawing.Size(72, 64);
            this.panelPiesa1.TabIndex = 0;
            this.panelPiesa1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.panelPiesa1_MouseClick);
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(328, 181);
            this.btnConnect.Margin = new System.Windows.Forms.Padding(4);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(128, 38);
            this.btnConnect.TabIndex = 3;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // textConnect
            // 
            this.textConnect.Location = new System.Drawing.Point(328, 124);
            this.textConnect.Margin = new System.Windows.Forms.Padding(4);
            this.textConnect.Name = "textConnect";
            this.textConnect.Size = new System.Drawing.Size(127, 22);
            this.textConnect.TabIndex = 4;
            this.textConnect.Text = "127.0.0.1";
            // 
            // labelScore
            // 
            this.labelScore.AutoSize = true;
            this.labelScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelScore.Location = new System.Drawing.Point(324, 42);
            this.labelScore.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelScore.Name = "labelScore";
            this.labelScore.Size = new System.Drawing.Size(55, 17);
            this.labelScore.TabIndex = 5;
            this.labelScore.Text = "Score:";
            // 
            // player1Score
            // 
            this.player1Score.AutoSize = true;
            this.player1Score.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.player1Score.Location = new System.Drawing.Point(381, 42);
            this.player1Score.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.player1Score.Name = "player1Score";
            this.player1Score.Size = new System.Drawing.Size(17, 17);
            this.player1Score.TabIndex = 6;
            this.player1Score.Text = "0";
            // 
            // trackBar1
            // 
            this.trackBar1.LargeChange = 10;
            this.trackBar1.Location = new System.Drawing.Point(587, 42);
            this.trackBar1.Margin = new System.Windows.Forms.Padding(4);
            this.trackBar1.Maximum = 40;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(176, 56);
            this.trackBar1.TabIndex = 7;
            this.trackBar1.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // volumeLabel
            // 
            this.volumeLabel.AutoSize = true;
            this.volumeLabel.Location = new System.Drawing.Point(625, 21);
            this.volumeLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.volumeLabel.Name = "volumeLabel";
            this.volumeLabel.Size = new System.Drawing.Size(95, 17);
            this.volumeLabel.TabIndex = 8;
            this.volumeLabel.Text = "Music Volume";
            // 
            // panelTab
            // 
            this.panelTab.BackColor = System.Drawing.Color.MediumOrchid;
            this.panelTab.Location = new System.Drawing.Point(31, 21);
            this.panelTab.Margin = new System.Windows.Forms.Padding(4);
            this.panelTab.Name = "panelTab";
            this.panelTab.Size = new System.Drawing.Size(263, 385);
            this.panelTab.TabIndex = 9;
            this.panelTab.TabStop = true;
            this.panelTab.Paint += new System.Windows.Forms.PaintEventHandler(this.panelTab_Paint);
            // 
            // btnReguli
            // 
            this.btnReguli.Location = new System.Drawing.Point(523, 181);
            this.btnReguli.Name = "btnReguli";
            this.btnReguli.Size = new System.Drawing.Size(133, 38);
            this.btnReguli.TabIndex = 10;
            this.btnReguli.Text = "Rules";
            this.btnReguli.UseVisualStyleBackColor = true;
            this.btnReguli.Click += new System.EventHandler(this.btnReguli_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(832, 480);
            this.Controls.Add(this.btnReguli);
            this.Controls.Add(this.panelTab);
            this.Controls.Add(this.volumeLabel);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.player1Score);
            this.Controls.Add(this.labelScore);
            this.Controls.Add(this.textConnect);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.panelAlegere);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
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
        private System.Windows.Forms.Button btnReguli;
    }
}

