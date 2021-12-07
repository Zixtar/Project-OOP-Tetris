
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
            this.panelTabla = new System.Windows.Forms.Panel();
            this.panelAlegere = new System.Windows.Forms.Panel();
            this.panelPiesa3 = new System.Windows.Forms.Panel();
            this.panelPiesa2 = new System.Windows.Forms.Panel();
            this.panelPiesa1 = new System.Windows.Forms.Panel();
            this.panelAlegere.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTabla
            // 
            this.panelTabla.BackColor = System.Drawing.Color.MediumOrchid;
            this.panelTabla.Location = new System.Drawing.Point(40, 17);
            this.panelTabla.Margin = new System.Windows.Forms.Padding(2);
            this.panelTabla.Name = "panelTabla";
            this.panelTabla.Size = new System.Drawing.Size(180, 325);
            this.panelTabla.TabIndex = 1;
            this.panelTabla.Paint += new System.Windows.Forms.PaintEventHandler(this.panelTabla_Paint);
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
            this.panelPiesa3.Location = new System.Drawing.Point(189, 36);
            this.panelPiesa3.Name = "panelPiesa3";
            this.panelPiesa3.Size = new System.Drawing.Size(48, 55);
            this.panelPiesa3.TabIndex = 2;
            this.panelPiesa3.MouseClick += new System.Windows.Forms.MouseEventHandler(this.panelPiesa3_MouseClick);
            // 
            // panelPiesa2
            // 
            this.panelPiesa2.Location = new System.Drawing.Point(116, 34);
            this.panelPiesa2.Name = "panelPiesa2";
            this.panelPiesa2.Size = new System.Drawing.Size(53, 58);
            this.panelPiesa2.TabIndex = 1;
            this.panelPiesa2.MouseClick += new System.Windows.Forms.MouseEventHandler(this.panelPiesa2_MouseClick);
            // 
            // panelPiesa1
            // 
            this.panelPiesa1.Location = new System.Drawing.Point(47, 41);
            this.panelPiesa1.Name = "panelPiesa1";
            this.panelPiesa1.Size = new System.Drawing.Size(54, 52);
            this.panelPiesa1.TabIndex = 0;
            this.panelPiesa1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.panelPiesa1_MouseClick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 390);
            this.Controls.Add(this.panelAlegere);
            this.Controls.Add(this.panelTabla);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.panelAlegere.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTabla;
        private System.Windows.Forms.Panel panelAlegere;
        private System.Windows.Forms.Panel panelPiesa3;
        private System.Windows.Forms.Panel panelPiesa2;
        private System.Windows.Forms.Panel panelPiesa1;
    }
}

