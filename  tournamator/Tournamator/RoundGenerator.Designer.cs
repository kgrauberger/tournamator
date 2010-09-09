namespace Tournamator
{
    partial class RoundGenerator
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
            this.matchupPanel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // matchupPanel
            // 
            this.matchupPanel.Location = new System.Drawing.Point(12, 12);
            this.matchupPanel.Name = "matchupPanel";
            this.matchupPanel.Size = new System.Drawing.Size(433, 576);
            this.matchupPanel.TabIndex = 0;
            // 
            // RoundGenerator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(457, 600);
            this.Controls.Add(this.matchupPanel);
            this.Name = "RoundGenerator";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RoundGenerator";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel matchupPanel;
    }
}