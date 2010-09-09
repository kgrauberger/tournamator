namespace Tournamator
{
    partial class Main
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.playerStatsView = new System.Windows.Forms.DataGridView();
            this.printDialog = new System.Windows.Forms.PrintDialog();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printToFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.btnGenerateRound = new System.Windows.Forms.Button();
            this.ckRandom = new System.Windows.Forms.CheckBox();
            this.playerPointsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.playerInfoDataSet = new Tournamator.PlayerInfoDataSet();
            this.playerInfoDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.iDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.playerNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.round1DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.round2DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.round3DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.round4DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.round5DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sportsmanshipDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.paintingDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.compDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OnTime = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.playerStatsView)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.playerPointsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.playerInfoDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.playerInfoDataSetBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // playerStatsView
            // 
            this.playerStatsView.AllowUserToResizeColumns = false;
            this.playerStatsView.AllowUserToResizeRows = false;
            this.playerStatsView.AutoGenerateColumns = false;
            this.playerStatsView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.playerStatsView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDDataGridViewTextBoxColumn,
            this.playerNameDataGridViewTextBoxColumn,
            this.round1DataGridViewTextBoxColumn,
            this.round2DataGridViewTextBoxColumn,
            this.round3DataGridViewTextBoxColumn,
            this.round4DataGridViewTextBoxColumn,
            this.round5DataGridViewTextBoxColumn,
            this.sportsmanshipDataGridViewTextBoxColumn,
            this.paintingDataGridViewTextBoxColumn,
            this.compDataGridViewTextBoxColumn,
            this.OnTime,
            this.Total});
            this.playerStatsView.DataSource = this.playerPointsBindingSource;
            this.playerStatsView.Location = new System.Drawing.Point(37, 42);
            this.playerStatsView.Name = "playerStatsView";
            this.playerStatsView.Size = new System.Drawing.Size(1146, 251);
            this.playerStatsView.TabIndex = 0;
            this.playerStatsView.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.playerStatsView_CellLeave);
            // 
            // printDialog
            // 
            this.printDialog.UseEXDialog = true;
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1194, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.BackColor = System.Drawing.SystemColors.Control;
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.printToolStripMenuItem,
            this.printToFileToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.fileToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(38, 20);
            this.fileToolStripMenuItem.Text = "File";
            this.fileToolStripMenuItem.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.BackColor = System.Drawing.SystemColors.Control;
            this.newToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.newToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("newToolStripMenuItem.Image")));
            this.newToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.White;
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.newToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.newToolStripMenuItem.Text = "New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.BackColor = System.Drawing.SystemColors.Control;
            this.openToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.openToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("openToolStripMenuItem.Image")));
            this.openToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.White;
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.BackColor = System.Drawing.SystemColors.Control;
            this.saveToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.saveToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripMenuItem.Image")));
            this.saveToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Fuchsia;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.BackColor = System.Drawing.SystemColors.Control;
            this.saveAsToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.saveAsToolStripMenuItem.Text = "Save As...";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // printToolStripMenuItem
            // 
            this.printToolStripMenuItem.BackColor = System.Drawing.SystemColors.Control;
            this.printToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.printToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("printToolStripMenuItem.Image")));
            this.printToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.White;
            this.printToolStripMenuItem.Name = "printToolStripMenuItem";
            this.printToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.printToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.printToolStripMenuItem.Text = "Print";
            this.printToolStripMenuItem.Click += new System.EventHandler(this.printToolStripMenuItem_Click);
            // 
            // printToFileToolStripMenuItem
            // 
            this.printToFileToolStripMenuItem.BackColor = System.Drawing.SystemColors.Control;
            this.printToFileToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.printToFileToolStripMenuItem.Name = "printToFileToolStripMenuItem";
            this.printToFileToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.printToFileToolStripMenuItem.Text = "Print to File";
            this.printToFileToolStripMenuItem.Click += new System.EventHandler(this.printToFileToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.BackColor = System.Drawing.SystemColors.Control;
            this.exitToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.exitToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("exitToolStripMenuItem.Image")));
            this.exitToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Fuchsia;
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Q)));
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem1});
            this.aboutToolStripMenuItem.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.aboutToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.aboutToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem1
            // 
            this.aboutToolStripMenuItem1.BackColor = System.Drawing.SystemColors.Control;
            this.aboutToolStripMenuItem1.ForeColor = System.Drawing.Color.Black;
            this.aboutToolStripMenuItem1.Name = "aboutToolStripMenuItem1";
            this.aboutToolStripMenuItem1.Size = new System.Drawing.Size(108, 22);
            this.aboutToolStripMenuItem1.Text = "About";
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            this.openFileDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog_FileOk);
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.saveFileDialog_FileOk);
            // 
            // btnGenerateRound
            // 
            this.btnGenerateRound.Location = new System.Drawing.Point(37, 331);
            this.btnGenerateRound.Name = "btnGenerateRound";
            this.btnGenerateRound.Size = new System.Drawing.Size(107, 28);
            this.btnGenerateRound.TabIndex = 3;
            this.btnGenerateRound.Text = "Start Round";
            this.btnGenerateRound.UseVisualStyleBackColor = true;
            this.btnGenerateRound.Click += new System.EventHandler(this.btnGenerateRound_Click);
            // 
            // ckRandom
            // 
            this.ckRandom.AutoSize = true;
            this.ckRandom.Location = new System.Drawing.Point(37, 375);
            this.ckRandom.Name = "ckRandom";
            this.ckRandom.Size = new System.Drawing.Size(116, 17);
            this.ckRandom.TabIndex = 4;
            this.ckRandom.Text = "Random Matchups";
            this.ckRandom.UseVisualStyleBackColor = true;
            // 
            // playerPointsBindingSource
            // 
            this.playerPointsBindingSource.DataMember = "PlayerPoints";
            this.playerPointsBindingSource.DataSource = this.playerInfoDataSet;
            // 
            // playerInfoDataSet
            // 
            this.playerInfoDataSet.DataSetName = "PlayerInfoDataSet";
            this.playerInfoDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // playerInfoDataSetBindingSource
            // 
            this.playerInfoDataSetBindingSource.DataSource = this.playerInfoDataSet;
            this.playerInfoDataSetBindingSource.Position = 0;
            // 
            // iDDataGridViewTextBoxColumn
            // 
            this.iDDataGridViewTextBoxColumn.DataPropertyName = "ID";
            this.iDDataGridViewTextBoxColumn.HeaderText = "ID";
            this.iDDataGridViewTextBoxColumn.Name = "iDDataGridViewTextBoxColumn";
            this.iDDataGridViewTextBoxColumn.Visible = false;
            // 
            // playerNameDataGridViewTextBoxColumn
            // 
            this.playerNameDataGridViewTextBoxColumn.DataPropertyName = "PlayerName";
            this.playerNameDataGridViewTextBoxColumn.HeaderText = "PlayerName";
            this.playerNameDataGridViewTextBoxColumn.Name = "playerNameDataGridViewTextBoxColumn";
            // 
            // round1DataGridViewTextBoxColumn
            // 
            this.round1DataGridViewTextBoxColumn.DataPropertyName = "Round1";
            this.round1DataGridViewTextBoxColumn.HeaderText = "Round1";
            this.round1DataGridViewTextBoxColumn.Name = "round1DataGridViewTextBoxColumn";
            // 
            // round2DataGridViewTextBoxColumn
            // 
            this.round2DataGridViewTextBoxColumn.DataPropertyName = "Round2";
            this.round2DataGridViewTextBoxColumn.HeaderText = "Round2";
            this.round2DataGridViewTextBoxColumn.Name = "round2DataGridViewTextBoxColumn";
            // 
            // round3DataGridViewTextBoxColumn
            // 
            this.round3DataGridViewTextBoxColumn.DataPropertyName = "Round3";
            this.round3DataGridViewTextBoxColumn.HeaderText = "Round3";
            this.round3DataGridViewTextBoxColumn.Name = "round3DataGridViewTextBoxColumn";
            // 
            // round4DataGridViewTextBoxColumn
            // 
            this.round4DataGridViewTextBoxColumn.DataPropertyName = "Round4";
            this.round4DataGridViewTextBoxColumn.HeaderText = "Round4";
            this.round4DataGridViewTextBoxColumn.Name = "round4DataGridViewTextBoxColumn";
            // 
            // round5DataGridViewTextBoxColumn
            // 
            this.round5DataGridViewTextBoxColumn.DataPropertyName = "Round5";
            this.round5DataGridViewTextBoxColumn.HeaderText = "Round5";
            this.round5DataGridViewTextBoxColumn.Name = "round5DataGridViewTextBoxColumn";
            // 
            // sportsmanshipDataGridViewTextBoxColumn
            // 
            this.sportsmanshipDataGridViewTextBoxColumn.DataPropertyName = "Sportsmanship";
            this.sportsmanshipDataGridViewTextBoxColumn.HeaderText = "Sportsmanship";
            this.sportsmanshipDataGridViewTextBoxColumn.Name = "sportsmanshipDataGridViewTextBoxColumn";
            // 
            // paintingDataGridViewTextBoxColumn
            // 
            this.paintingDataGridViewTextBoxColumn.DataPropertyName = "Painting";
            this.paintingDataGridViewTextBoxColumn.HeaderText = "Painting";
            this.paintingDataGridViewTextBoxColumn.Name = "paintingDataGridViewTextBoxColumn";
            // 
            // compDataGridViewTextBoxColumn
            // 
            this.compDataGridViewTextBoxColumn.DataPropertyName = "Comp";
            this.compDataGridViewTextBoxColumn.HeaderText = "Comp";
            this.compDataGridViewTextBoxColumn.Name = "compDataGridViewTextBoxColumn";
            // 
            // OnTime
            // 
            this.OnTime.DataPropertyName = "OnTime";
            this.OnTime.HeaderText = "OnTime";
            this.OnTime.Name = "OnTime";
            // 
            // Total
            // 
            this.Total.DataPropertyName = "Total";
            this.Total.HeaderText = "Total";
            this.Total.Name = "Total";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1194, 521);
            this.Controls.Add(this.ckRandom);
            this.Controls.Add(this.btnGenerateRound);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.playerStatsView);
            this.Name = "Main";
            this.Text = "Tournamator Version 1.0";
            ((System.ComponentModel.ISupportInitialize)(this.playerStatsView)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.playerPointsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.playerInfoDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.playerInfoDataSetBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView playerStatsView;
        private System.Windows.Forms.BindingSource playerInfoDataSetBindingSource;
        private PlayerInfoDataSet playerInfoDataSet;
        private System.Windows.Forms.BindingSource playerPointsBindingSource;
        //private Tournamator.PlayerInfoDataSetTableAdapters.PlayerPointsTableAdapter playerPointsTableAdapter;
        private System.Windows.Forms.PrintDialog printDialog;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem printToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem printToFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem1;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.Button btnGenerateRound;
        private System.Windows.Forms.CheckBox ckRandom;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn playerNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn round1DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn round2DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn round3DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn round4DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn round5DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sportsmanshipDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn paintingDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn compDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn OnTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn Total;




    }
}

