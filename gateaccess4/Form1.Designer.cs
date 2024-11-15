namespace gateaccess4
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
            this.pbFrame = new System.Windows.Forms.PictureBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.pbCropped = new System.Windows.Forms.PictureBox();
            this.pbCamera = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pbFrame)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCropped)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCamera)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pbFrame
            // 
            this.pbFrame.Location = new System.Drawing.Point(13, 9);
            this.pbFrame.Name = "pbFrame";
            this.pbFrame.Size = new System.Drawing.Size(420, 356);
            this.pbFrame.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbFrame.TabIndex = 2;
            this.pbFrame.TabStop = false;
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(577, 304);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(188, 38);
            this.btnBrowse.TabIndex = 3;
            this.btnBrowse.Text = "Browse Image";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // pbCropped
            // 
            this.pbCropped.Location = new System.Drawing.Point(15, 430);
            this.pbCropped.Name = "pbCropped";
            this.pbCropped.Size = new System.Drawing.Size(203, 57);
            this.pbCropped.TabIndex = 4;
            this.pbCropped.TabStop = false;
            // 
            // pbCamera
            // 
            this.pbCamera.Location = new System.Drawing.Point(528, 33);
            this.pbCamera.Name = "pbCamera";
            this.pbCamera.Size = new System.Drawing.Size(292, 254);
            this.pbCamera.TabIndex = 5;
            this.pbCamera.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 404);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "License Plate:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(15, 493);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(203, 28);
            this.textBox1.TabIndex = 7;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.pbFrame);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(448, 376);
            this.panel1.TabIndex = 8;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(850, 540);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.pbCamera);
            this.Controls.Add(this.pbCropped);
            this.Controls.Add(this.btnBrowse);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pbFrame)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCropped)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCamera)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pbFrame;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.PictureBox pbCropped;
        private System.Windows.Forms.PictureBox pbCamera;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Panel panel1;
    }
}

