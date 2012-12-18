namespace Evilch.AntSim.WinApp
{
    partial class WorldForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.picSimAntWorld = new System.Windows.Forms.PictureBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btnPauseResume = new System.Windows.Forms.Button();
            this.btnCreate = new System.Windows.Forms.Button();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.dgvAntData = new System.Windows.Forms.DataGridView();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDirectionFactor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPosition = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHiveSmell = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFoodSmell = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLoaded = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colDistanceHive = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDecision = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.worldTimer = new System.Windows.Forms.Timer(this.components);
            this.btnStep = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picSimAntWorld)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAntData)).BeginInit();
            this.SuspendLayout();
            // 
            // picSimAntWorld
            // 
            this.picSimAntWorld.Location = new System.Drawing.Point(0, 0);
            this.picSimAntWorld.Name = "picSimAntWorld";
            this.picSimAntWorld.Size = new System.Drawing.Size(219, 65);
            this.picSimAntWorld.TabIndex = 0;
            this.picSimAntWorld.TabStop = false;
            this.picSimAntWorld.Paint += new System.Windows.Forms.PaintEventHandler(this.picSimAntWorld_Paint);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.btnStep);
            this.splitContainer1.Panel1.Controls.Add(this.btnPauseResume);
            this.splitContainer1.Panel1.Controls.Add(this.btnCreate);
            this.splitContainer1.Panel1MinSize = 100;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Panel2MinSize = 305;
            this.splitContainer1.Size = new System.Drawing.Size(840, 426);
            this.splitContainer1.SplitterDistance = 100;
            this.splitContainer1.TabIndex = 1;
            // 
            // btnPauseResume
            // 
            this.btnPauseResume.Location = new System.Drawing.Point(12, 42);
            this.btnPauseResume.Name = "btnPauseResume";
            this.btnPauseResume.Size = new System.Drawing.Size(75, 23);
            this.btnPauseResume.TabIndex = 1;
            this.btnPauseResume.Text = "Pause";
            this.btnPauseResume.UseVisualStyleBackColor = true;
            this.btnPauseResume.Click += new System.EventHandler(this.btnPauseResume_Click);
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(12, 12);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(75, 23);
            this.btnCreate.TabIndex = 0;
            this.btnCreate.Text = "Create";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.picSimAntWorld);
            this.splitContainer2.Panel1MinSize = 205;
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.dgvAntData);
            this.splitContainer2.Panel2MinSize = 50;
            this.splitContainer2.Size = new System.Drawing.Size(736, 426);
            this.splitContainer2.SplitterDistance = 205;
            this.splitContainer2.TabIndex = 1;
            // 
            // dgvAntData
            // 
            this.dgvAntData.AllowUserToAddRows = false;
            this.dgvAntData.AllowUserToDeleteRows = false;
            this.dgvAntData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAntData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colName,
            this.colDirectionFactor,
            this.colPosition,
            this.colHiveSmell,
            this.colFoodSmell,
            this.colLoaded,
            this.colDistanceHive,
            this.colDecision});
            this.dgvAntData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAntData.Location = new System.Drawing.Point(0, 0);
            this.dgvAntData.Name = "dgvAntData";
            this.dgvAntData.ReadOnly = true;
            this.dgvAntData.Size = new System.Drawing.Size(736, 217);
            this.dgvAntData.TabIndex = 0;
            // 
            // colName
            // 
            this.colName.HeaderText = "Name";
            this.colName.Name = "colName";
            this.colName.ReadOnly = true;
            this.colName.Width = 60;
            // 
            // colDirectionFactor
            // 
            this.colDirectionFactor.HeaderText = "Dir Factor";
            this.colDirectionFactor.Name = "colDirectionFactor";
            this.colDirectionFactor.ReadOnly = true;
            this.colDirectionFactor.Width = 80;
            // 
            // colPosition
            // 
            this.colPosition.HeaderText = "Position";
            this.colPosition.Name = "colPosition";
            this.colPosition.ReadOnly = true;
            this.colPosition.Width = 80;
            // 
            // colHiveSmell
            // 
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.colHiveSmell.DefaultCellStyle = dataGridViewCellStyle1;
            this.colHiveSmell.HeaderText = "Hive Smell";
            this.colHiveSmell.Name = "colHiveSmell";
            this.colHiveSmell.ReadOnly = true;
            this.colHiveSmell.Width = 85;
            // 
            // colFoodSmell
            // 
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.colFoodSmell.DefaultCellStyle = dataGridViewCellStyle2;
            this.colFoodSmell.HeaderText = "Food Smell";
            this.colFoodSmell.Name = "colFoodSmell";
            this.colFoodSmell.ReadOnly = true;
            this.colFoodSmell.Width = 85;
            // 
            // colLoaded
            // 
            this.colLoaded.HeaderText = "Loaded";
            this.colLoaded.Name = "colLoaded";
            this.colLoaded.ReadOnly = true;
            this.colLoaded.Width = 50;
            // 
            // colDistanceHive
            // 
            this.colDistanceHive.HeaderText = "To Hive";
            this.colDistanceHive.Name = "colDistanceHive";
            this.colDistanceHive.ReadOnly = true;
            // 
            // colDecision
            // 
            this.colDecision.HeaderText = "Decision";
            this.colDecision.Name = "colDecision";
            this.colDecision.ReadOnly = true;
            // 
            // worldTimer
            // 
            this.worldTimer.Interval = 10;
            this.worldTimer.Tick += new System.EventHandler(this.worldTimer_Tick);
            // 
            // btnStep
            // 
            this.btnStep.Location = new System.Drawing.Point(12, 71);
            this.btnStep.Name = "btnStep";
            this.btnStep.Size = new System.Drawing.Size(75, 23);
            this.btnStep.TabIndex = 2;
            this.btnStep.Text = "Step";
            this.btnStep.UseVisualStyleBackColor = true;
            this.btnStep.Click += new System.EventHandler(this.btnStep_Click);
            // 
            // WorldForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(840, 426);
            this.Controls.Add(this.splitContainer1);
            this.Name = "WorldForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.WorldForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picSimAntWorld)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAntData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picSimAntWorld;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button btnPauseResume;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Timer worldTimer;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.DataGridView dgvAntData;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDirectionFactor;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPosition;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHiveSmell;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFoodSmell;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colLoaded;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDistanceHive;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDecision;
        private System.Windows.Forms.Button btnStep;
    }
}

