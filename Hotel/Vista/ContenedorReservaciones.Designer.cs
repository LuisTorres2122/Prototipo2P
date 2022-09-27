
namespace Vista
{
    partial class ContenedorReservaciones
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.reservacionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manteniminetosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reservacionToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.clienteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.reservacionToolStripMenuItem,
            this.manteniminetosToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1418, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // reservacionToolStripMenuItem
            // 
            this.reservacionToolStripMenuItem.Name = "reservacionToolStripMenuItem";
            this.reservacionToolStripMenuItem.Size = new System.Drawing.Size(82, 20);
            this.reservacionToolStripMenuItem.Text = "Reservacion";
            this.reservacionToolStripMenuItem.Click += new System.EventHandler(this.reservacionToolStripMenuItem_Click);
            // 
            // manteniminetosToolStripMenuItem
            // 
            this.manteniminetosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.reservacionToolStripMenuItem1,
            this.clienteToolStripMenuItem});
            this.manteniminetosToolStripMenuItem.Name = "manteniminetosToolStripMenuItem";
            this.manteniminetosToolStripMenuItem.Size = new System.Drawing.Size(106, 20);
            this.manteniminetosToolStripMenuItem.Text = "Manteniminetos";
            // 
            // reservacionToolStripMenuItem1
            // 
            this.reservacionToolStripMenuItem1.Name = "reservacionToolStripMenuItem1";
            this.reservacionToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.reservacionToolStripMenuItem1.Text = "Reservacion";
            this.reservacionToolStripMenuItem1.Click += new System.EventHandler(this.reservacionToolStripMenuItem1_Click);
            // 
            // clienteToolStripMenuItem
            // 
            this.clienteToolStripMenuItem.Name = "clienteToolStripMenuItem";
            this.clienteToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.clienteToolStripMenuItem.Text = "Cliente";
            this.clienteToolStripMenuItem.Click += new System.EventHandler(this.clienteToolStripMenuItem_Click);
            // 
            // ContenedorReservaciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1418, 770);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "ContenedorReservaciones";
            this.Text = "ContenedorReservaciones";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem reservacionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manteniminetosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reservacionToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem clienteToolStripMenuItem;
    }
}