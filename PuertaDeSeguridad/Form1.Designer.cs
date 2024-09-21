
namespace PuertaDeSeguridad
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtbCamara = new System.Windows.Forms.TextBox();
            this.txtbLaser = new System.Windows.Forms.TextBox();
            this.txbRFID = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtbCamara
            // 
            this.txtbCamara.Enabled = false;
            this.txtbCamara.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbCamara.Location = new System.Drawing.Point(12, 160);
            this.txtbCamara.Name = "txtbCamara";
            this.txtbCamara.Size = new System.Drawing.Size(310, 26);
            this.txtbCamara.TabIndex = 0;
            // 
            // txtbLaser
            // 
            this.txtbLaser.Enabled = false;
            this.txtbLaser.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbLaser.Location = new System.Drawing.Point(12, 105);
            this.txtbLaser.Name = "txtbLaser";
            this.txtbLaser.Size = new System.Drawing.Size(310, 26);
            this.txtbLaser.TabIndex = 1;
            // 
            // txbRFID
            // 
            this.txbRFID.Location = new System.Drawing.Point(15, 38);
            this.txbRFID.Multiline = true;
            this.txbRFID.Name = "txbRFID";
            this.txbRFID.Size = new System.Drawing.Size(310, 27);
            this.txbRFID.TabIndex = 2;
            this.txbRFID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txbRFID_KeyDown);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Maroon;
            this.ClientSize = new System.Drawing.Size(337, 202);
            this.Controls.Add(this.txbRFID);
            this.Controls.Add(this.txtbLaser);
            this.Controls.Add(this.txtbCamara);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Seguridad";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtbCamara;
        private System.Windows.Forms.TextBox txtbLaser;
        private System.Windows.Forms.TextBox txbRFID;
    }
}

