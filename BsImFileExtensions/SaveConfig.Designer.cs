
namespace BsImFileExtensions
{
    partial class SaveConfig
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
            this.bitDepth = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.resolutionLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.fileSize = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // bitDepth
            // 
            this.bitDepth.FormattingEnabled = true;
            this.bitDepth.Items.AddRange(new object[] {
            "32",
            "24"});
            this.bitDepth.Location = new System.Drawing.Point(84, 49);
            this.bitDepth.Name = "bitDepth";
            this.bitDepth.Size = new System.Drawing.Size(121, 24);
            this.bitDepth.TabIndex = 0;
            this.bitDepth.SelectedIndexChanged += new System.EventHandler(this.bitDepth_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(313, 165);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Save";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Bit Depth";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Image Resolution";
            // 
            // resolutionLabel
            // 
            this.resolutionLabel.AutoSize = true;
            this.resolutionLabel.Location = new System.Drawing.Point(144, 19);
            this.resolutionLabel.Name = "resolutionLabel";
            this.resolutionLabel.Size = new System.Drawing.Size(38, 17);
            this.resolutionLabel.TabIndex = 4;
            this.resolutionLabel.Text = "0 x 0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "File Size";
            // 
            // fileSize
            // 
            this.fileSize.AutoSize = true;
            this.fileSize.Location = new System.Drawing.Point(82, 87);
            this.fileSize.Name = "fileSize";
            this.fileSize.Size = new System.Drawing.Size(38, 17);
            this.fileSize.TabIndex = 6;
            this.fileSize.Text = "0 KB";
            // 
            // SaveConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 200);
            this.Controls.Add(this.fileSize);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.resolutionLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.bitDepth);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SaveConfig";
            this.Text = "SaveConfig";
            this.Load += new System.EventHandler(this.SaveConfig_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ComboBox bitDepth;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label resolutionLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label fileSize;
    }
}