namespace CaptureTranslatorApp
{
    partial class FormResult
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.labelOriginal = new System.Windows.Forms.Label();
            this.textBoxOriginal = new System.Windows.Forms.TextBox();
            this.labelTranslated = new System.Windows.Forms.Label();
            this.textBoxTranslated = new System.Windows.Forms.TextBox();

            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();

            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.splitContainer1.Size = new System.Drawing.Size(800, 450);
            this.splitContainer1.SplitterDistance = 400;
            this.splitContainer1.TabIndex = 0;

            // 
            // Panel1 - Original
            // 
            this.labelOriginal.AutoSize = true;
            this.labelOriginal.Location = new System.Drawing.Point(10, 10);
            this.labelOriginal.Name = "labelOriginal";
            this.labelOriginal.Size = new System.Drawing.Size(64, 15);
            this.labelOriginal.Text = "Original";

            this.textBoxOriginal.Location = new System.Drawing.Point(10, 30);
            this.textBoxOriginal.Multiline = true;
            this.textBoxOriginal.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxOriginal.ReadOnly = true;
            this.textBoxOriginal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxOriginal.Size = new System.Drawing.Size(380, 400);
            this.textBoxOriginal.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);

            this.splitContainer1.Panel1.Controls.Add(this.labelOriginal);
            this.splitContainer1.Panel1.Controls.Add(this.textBoxOriginal);

            // 
            // Panel2 - Translated
            // 
            this.labelTranslated.AutoSize = true;
            this.labelTranslated.Location = new System.Drawing.Point(10, 10);
            this.labelTranslated.Name = "labelTranslated";
            this.labelTranslated.Size = new System.Drawing.Size(64, 15);
            this.labelTranslated.Text = "Translated (Korean)";

            this.textBoxTranslated.Location = new System.Drawing.Point(10, 30);
            this.textBoxTranslated.Multiline = true;
            this.textBoxTranslated.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxTranslated.ReadOnly = true;
            this.textBoxTranslated.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxTranslated.Size = new System.Drawing.Size(380, 400);
            this.textBoxTranslated.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);

            this.splitContainer1.Panel2.Controls.Add(this.labelTranslated);
            this.splitContainer1.Panel2.Controls.Add(this.textBoxTranslated);

            // 
            // FormResult
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.splitContainer1);
            this.Name = "FormResult";
            this.Text = "번역 결과";
            this.BackColor = System.Drawing.Color.FromArgb(45, 45, 48); // 다크 테마
            this.ForeColor = System.Drawing.Color.White;

            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
        }


        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label labelOriginal;
        private System.Windows.Forms.TextBox textBoxOriginal;
        private System.Windows.Forms.Label labelTranslated;
        private System.Windows.Forms.TextBox textBoxTranslated;
    }
}