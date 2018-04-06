namespace BHopper
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
            this.btnEnabled = new System.Windows.Forms.Button();
            this.lblJumping = new System.Windows.Forms.Label();
            this.prgJumping = new System.Windows.Forms.ProgressBar();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // btnEnabled
            // 
            this.btnEnabled.Location = new System.Drawing.Point(12, 12);
            this.btnEnabled.Name = "btnEnabled";
            this.btnEnabled.Size = new System.Drawing.Size(94, 23);
            this.btnEnabled.TabIndex = 0;
            this.btnEnabled.TabStop = false;
            this.btnEnabled.Text = "Enable";
            this.btnEnabled.UseVisualStyleBackColor = true;
            this.btnEnabled.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btnEnabled_MouseClick);
            // 
            // lblJumping
            // 
            this.lblJumping.AutoSize = true;
            this.lblJumping.Location = new System.Drawing.Point(112, 17);
            this.lblJumping.Name = "lblJumping";
            this.lblJumping.Size = new System.Drawing.Size(52, 13);
            this.lblJumping.TabIndex = 1;
            this.lblJumping.Text = "Jumping: ";
            // 
            // prgJumping
            // 
            this.prgJumping.BackColor = System.Drawing.Color.White;
            this.prgJumping.ForeColor = System.Drawing.Color.Red;
            this.prgJumping.Location = new System.Drawing.Point(168, 12);
            this.prgJumping.Name = "prgJumping";
            this.prgJumping.Size = new System.Drawing.Size(40, 23);
            this.prgJumping.TabIndex = 2;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(220, 44);
            this.Controls.Add(this.prgJumping);
            this.Controls.Add(this.lblJumping);
            this.Controls.Add(this.btnEnabled);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.Text = "BHopper";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnEnabled;
        private System.Windows.Forms.Label lblJumping;
        private System.Windows.Forms.ProgressBar prgJumping;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}

