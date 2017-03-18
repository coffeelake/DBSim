namespace SimServer
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
            this.lblCurenTime = new System.Windows.Forms.Label();
            this.gear = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblBestTime = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblCurenTime
            // 
            this.lblCurenTime.AutoSize = true;
            this.lblCurenTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 50F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurenTime.Location = new System.Drawing.Point(4, 34);
            this.lblCurenTime.Name = "lblCurenTime";
            this.lblCurenTime.Size = new System.Drawing.Size(55, 76);
            this.lblCurenTime.TabIndex = 1;
            this.lblCurenTime.Text = "-";
            // 
            // gear
            // 
            this.gear.AutoSize = true;
            this.gear.Font = new System.Drawing.Font("Microsoft Sans Serif", 180F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gear.Location = new System.Drawing.Point(487, 198);
            this.gear.Name = "gear";
            this.gear.Size = new System.Drawing.Size(288, 272);
            this.gear.TabIndex = 2;
            this.gear.Text = "N";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 25);
            this.label2.TabIndex = 3;
            this.label2.Text = "Current time";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 110);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 25);
            this.label3.TabIndex = 4;
            this.label3.Text = "Best time";
            // 
            // lblBestTime
            // 
            this.lblBestTime.AutoSize = true;
            this.lblBestTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 50F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBestTime.Location = new System.Drawing.Point(4, 135);
            this.lblBestTime.Name = "lblBestTime";
            this.lblBestTime.Size = new System.Drawing.Size(55, 76);
            this.lblBestTime.TabIndex = 1;
            this.lblBestTime.Text = "-";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 761);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.gear);
            this.Controls.Add(this.lblBestTime);
            this.Controls.Add(this.lblCurenTime);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCurenTime;
        private System.Windows.Forms.Label gear;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblBestTime;
        private System.Windows.Forms.Label label2;
    }
}

