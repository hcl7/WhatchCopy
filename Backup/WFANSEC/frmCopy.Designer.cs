namespace WFANSEC
{
    partial class Copy
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
            this.pbcompleted = new System.Windows.Forms.ProgressBar();
            this.lbl_source = new System.Windows.Forms.Label();
            this.lbl_nrfn = new System.Windows.Forms.Label();
            this.pbcurrent = new System.Windows.Forms.ProgressBar();
            this.btnlog = new System.Windows.Forms.Button();
            this.chkwatch = new System.Windows.Forms.CheckBox();
            this.lbl_dest = new System.Windows.Forms.Label();
            this.Copier = new System.ComponentModel.BackgroundWorker();
            this.btnCopy = new System.Windows.Forms.Button();
            this.lblkbps = new System.Windows.Forms.Label();
            this.gbinfo = new System.Windows.Forms.GroupBox();
            this.lblremaining = new System.Windows.Forms.Label();
            this.lblelapsed = new System.Windows.Forms.Label();
            this.lblcompleted = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.gbinfo.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pbcompleted
            // 
            this.pbcompleted.Location = new System.Drawing.Point(15, 46);
            this.pbcompleted.Name = "pbcompleted";
            this.pbcompleted.Size = new System.Drawing.Size(592, 20);
            this.pbcompleted.TabIndex = 1;
            // 
            // lbl_source
            // 
            this.lbl_source.AutoSize = true;
            this.lbl_source.Location = new System.Drawing.Point(15, 16);
            this.lbl_source.Name = "lbl_source";
            this.lbl_source.Size = new System.Drawing.Size(41, 13);
            this.lbl_source.TabIndex = 3;
            this.lbl_source.Text = "Source";
            // 
            // lbl_nrfn
            // 
            this.lbl_nrfn.AutoSize = true;
            this.lbl_nrfn.Location = new System.Drawing.Point(15, 74);
            this.lbl_nrfn.Name = "lbl_nrfn";
            this.lbl_nrfn.Size = new System.Drawing.Size(45, 13);
            this.lbl_nrfn.TabIndex = 4;
            this.lbl_nrfn.Text = "Nr_Files";
            // 
            // pbcurrent
            // 
            this.pbcurrent.Location = new System.Drawing.Point(15, 19);
            this.pbcurrent.Name = "pbcurrent";
            this.pbcurrent.Size = new System.Drawing.Size(592, 20);
            this.pbcurrent.TabIndex = 5;
            // 
            // btnlog
            // 
            this.btnlog.Location = new System.Drawing.Point(572, 41);
            this.btnlog.Name = "btnlog";
            this.btnlog.Size = new System.Drawing.Size(61, 25);
            this.btnlog.TabIndex = 7;
            this.btnlog.Text = "&Log";
            this.btnlog.UseVisualStyleBackColor = true;
            this.btnlog.Click += new System.EventHandler(this.btnlog_Click);
            // 
            // chkwatch
            // 
            this.chkwatch.AutoSize = true;
            this.chkwatch.ForeColor = System.Drawing.Color.Red;
            this.chkwatch.Location = new System.Drawing.Point(561, 75);
            this.chkwatch.Name = "chkwatch";
            this.chkwatch.Size = new System.Drawing.Size(58, 17);
            this.chkwatch.TabIndex = 8;
            this.chkwatch.Text = "Watch";
            this.chkwatch.UseVisualStyleBackColor = true;
            this.chkwatch.CheckedChanged += new System.EventHandler(this.chkwatch_CheckedChanged);
            // 
            // lbl_dest
            // 
            this.lbl_dest.AutoSize = true;
            this.lbl_dest.Location = new System.Drawing.Point(15, 34);
            this.lbl_dest.Name = "lbl_dest";
            this.lbl_dest.Size = new System.Drawing.Size(60, 13);
            this.lbl_dest.TabIndex = 9;
            this.lbl_dest.Text = "Destination";
            // 
            // btnCopy
            // 
            this.btnCopy.Location = new System.Drawing.Point(572, 12);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(61, 23);
            this.btnCopy.TabIndex = 10;
            this.btnCopy.Text = "&Copy";
            this.btnCopy.UseVisualStyleBackColor = true;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // lblkbps
            // 
            this.lblkbps.AutoSize = true;
            this.lblkbps.Location = new System.Drawing.Point(15, 53);
            this.lblkbps.Name = "lblkbps";
            this.lblkbps.Size = new System.Drawing.Size(30, 13);
            this.lblkbps.TabIndex = 11;
            this.lblkbps.Text = "kbps";
            // 
            // gbinfo
            // 
            this.gbinfo.Controls.Add(this.lblremaining);
            this.gbinfo.Controls.Add(this.lblelapsed);
            this.gbinfo.Controls.Add(this.lblcompleted);
            this.gbinfo.Controls.Add(this.lbl_source);
            this.gbinfo.Controls.Add(this.lblkbps);
            this.gbinfo.Controls.Add(this.lbl_dest);
            this.gbinfo.Controls.Add(this.lbl_nrfn);
            this.gbinfo.Location = new System.Drawing.Point(12, 6);
            this.gbinfo.Name = "gbinfo";
            this.gbinfo.Size = new System.Drawing.Size(543, 170);
            this.gbinfo.TabIndex = 12;
            this.gbinfo.TabStop = false;
            this.gbinfo.Text = "Information";
            // 
            // lblremaining
            // 
            this.lblremaining.AutoSize = true;
            this.lblremaining.Location = new System.Drawing.Point(15, 138);
            this.lblremaining.Name = "lblremaining";
            this.lblremaining.Size = new System.Drawing.Size(57, 13);
            this.lblremaining.TabIndex = 14;
            this.lblremaining.Text = "Remaining";
            // 
            // lblelapsed
            // 
            this.lblelapsed.AutoSize = true;
            this.lblelapsed.Location = new System.Drawing.Point(15, 115);
            this.lblelapsed.Name = "lblelapsed";
            this.lblelapsed.Size = new System.Drawing.Size(45, 13);
            this.lblelapsed.TabIndex = 13;
            this.lblelapsed.Text = "Elapsed";
            // 
            // lblcompleted
            // 
            this.lblcompleted.AutoSize = true;
            this.lblcompleted.Location = new System.Drawing.Point(15, 94);
            this.lblcompleted.Name = "lblcompleted";
            this.lblcompleted.Size = new System.Drawing.Size(57, 13);
            this.lblcompleted.TabIndex = 12;
            this.lblcompleted.Text = "Completed";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pbcurrent);
            this.groupBox1.Controls.Add(this.pbcompleted);
            this.groupBox1.Location = new System.Drawing.Point(12, 182);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(621, 83);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Progress";
            // 
            // Copy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(645, 279);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gbinfo);
            this.Controls.Add(this.btnCopy);
            this.Controls.Add(this.chkwatch);
            this.Controls.Add(this.btnlog);
            this.MaximizeBox = false;
            this.Name = "Copy";
            this.Text = "Copy";
            this.Load += new System.EventHandler(this.Copy_Load);
            this.gbinfo.ResumeLayout(false);
            this.gbinfo.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar pbcompleted;
        private System.Windows.Forms.Label lbl_source;
        private System.Windows.Forms.Label lbl_nrfn;
        private System.Windows.Forms.ProgressBar pbcurrent;
        private System.Windows.Forms.Button btnlog;
        private System.Windows.Forms.CheckBox chkwatch;
        private System.Windows.Forms.Label lbl_dest;
        private System.ComponentModel.BackgroundWorker Copier;
        private System.Windows.Forms.Button btnCopy;
        private System.Windows.Forms.Label lblkbps;
        private System.Windows.Forms.GroupBox gbinfo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblremaining;
        private System.Windows.Forms.Label lblelapsed;
        private System.Windows.Forms.Label lblcompleted;
    }
}

