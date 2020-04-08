namespace TessyRegisterConverter
{
    partial class RegConverterGUI
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
            this.lab_src = new System.Windows.Forms.Label();
            this.lab_dest = new System.Windows.Forms.Label();
            this.SourcePath = new System.Windows.Forms.TextBox();
            this.DestPath = new System.Windows.Forms.TextBox();
            this.replaceExisting = new System.Windows.Forms.CheckBox();
            this.btn_Convert = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lab_src
            // 
            this.lab_src.AutoSize = true;
            this.lab_src.Location = new System.Drawing.Point(12, 9);
            this.lab_src.Name = "lab_src";
            this.lab_src.Size = new System.Drawing.Size(44, 13);
            this.lab_src.TabIndex = 0;
            this.lab_src.Text = "Source:";
            // 
            // lab_dest
            // 
            this.lab_dest.AutoSize = true;
            this.lab_dest.Location = new System.Drawing.Point(12, 35);
            this.lab_dest.Name = "lab_dest";
            this.lab_dest.Size = new System.Drawing.Size(63, 13);
            this.lab_dest.TabIndex = 1;
            this.lab_dest.Text = "Destination:";
            // 
            // SourcePath
            // 
            this.SourcePath.Location = new System.Drawing.Point(81, 6);
            this.SourcePath.Name = "SourcePath";
            this.SourcePath.Size = new System.Drawing.Size(393, 20);
            this.SourcePath.TabIndex = 2;
            // 
            // DestPath
            // 
            this.DestPath.Location = new System.Drawing.Point(81, 32);
            this.DestPath.Name = "DestPath";
            this.DestPath.Size = new System.Drawing.Size(393, 20);
            this.DestPath.TabIndex = 3;
            // 
            // replaceExisting
            // 
            this.replaceExisting.AutoSize = true;
            this.replaceExisting.Location = new System.Drawing.Point(15, 58);
            this.replaceExisting.Name = "replaceExisting";
            this.replaceExisting.Size = new System.Drawing.Size(124, 17);
            this.replaceExisting.TabIndex = 4;
            this.replaceExisting.Text = "Replace Existing File";
            this.replaceExisting.UseVisualStyleBackColor = true;
            // 
            // btn_Convert
            // 
            this.btn_Convert.Location = new System.Drawing.Point(214, 86);
            this.btn_Convert.Name = "btn_Convert";
            this.btn_Convert.Size = new System.Drawing.Size(75, 49);
            this.btn_Convert.TabIndex = 5;
            this.btn_Convert.Text = "Convert";
            this.btn_Convert.UseVisualStyleBackColor = true;
            this.btn_Convert.Click += new System.EventHandler(this.bnt_Convert_Click);
            // 
            // RegConverterGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(486, 147);
            this.Controls.Add(this.btn_Convert);
            this.Controls.Add(this.replaceExisting);
            this.Controls.Add(this.DestPath);
            this.Controls.Add(this.SourcePath);
            this.Controls.Add(this.lab_dest);
            this.Controls.Add(this.lab_src);
            this.Name = "RegConverterGUI";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lab_src;
        private System.Windows.Forms.Label lab_dest;
        private System.Windows.Forms.TextBox SourcePath;
        private System.Windows.Forms.TextBox DestPath;
        private System.Windows.Forms.CheckBox replaceExisting;
        private System.Windows.Forms.Button btn_Convert;
    }
}

