namespace Editor
{
    partial class StepViewer
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
            this.StepPic = new System.Windows.Forms.PictureBox();
            this.StepsList = new System.Windows.Forms.ListBox();
            this.xPos = new System.Windows.Forms.TextBox();
            this.yPos = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.Open = new System.Windows.Forms.ToolStripMenuItem();
            this.save = new System.Windows.Forms.ToolStripMenuItem();
            this.denom = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.moveLeft = new System.Windows.Forms.Button();
            this.moveRight = new System.Windows.Forms.Button();
            this.num = new System.Windows.Forms.TextBox();
            this.eventText = new System.Windows.Forms.TextBox();
            this.updateEV = new System.Windows.Forms.Button();
            this.remove = new System.Windows.Forms.Button();
            this.redoBut = new System.Windows.Forms.Button();
            this.undoBut = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.StepPic)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // StepPic
            // 
            this.StepPic.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.StepPic.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.StepPic.Enabled = false;
            this.StepPic.ErrorImage = null;
            this.StepPic.Location = new System.Drawing.Point(12, 25);
            this.StepPic.Name = "StepPic";
            this.StepPic.Size = new System.Drawing.Size(268, 227);
            this.StepPic.TabIndex = 0;
            this.StepPic.TabStop = false;
            this.StepPic.SizeChanged += new System.EventHandler(this.StepPic_SizeChanged);
            this.StepPic.MouseClick += new System.Windows.Forms.MouseEventHandler(this.StepPic_MouseClick);
            // 
            // StepsList
            // 
            this.StepsList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.StepsList.Enabled = false;
            this.StepsList.FormattingEnabled = true;
            this.StepsList.Location = new System.Drawing.Point(301, 25);
            this.StepsList.Name = "StepsList";
            this.StepsList.Size = new System.Drawing.Size(136, 160);
            this.StepsList.TabIndex = 1;
            this.StepsList.SelectedIndexChanged += new System.EventHandler(this.StepsList_SelectedIndexChanged);
            // 
            // xPos
            // 
            this.xPos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.xPos.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.xPos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.xPos.Enabled = false;
            this.xPos.Location = new System.Drawing.Point(12, 272);
            this.xPos.Name = "xPos";
            this.xPos.ReadOnly = true;
            this.xPos.Size = new System.Drawing.Size(33, 20);
            this.xPos.TabIndex = 2;
            // 
            // yPos
            // 
            this.yPos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.yPos.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.yPos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.yPos.Enabled = false;
            this.yPos.Location = new System.Drawing.Point(51, 272);
            this.yPos.Name = "yPos";
            this.yPos.ReadOnly = true;
            this.yPos.Size = new System.Drawing.Size(33, 20);
            this.yPos.TabIndex = 3;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Open,
            this.save});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(449, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // Open
            // 
            this.Open.Name = "Open";
            this.Open.Size = new System.Drawing.Size(48, 20);
            this.Open.Text = "Open";
            this.Open.Click += new System.EventHandler(this.Open_Click);
            // 
            // save
            // 
            this.save.Enabled = false;
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(43, 20);
            this.save.Text = "Save";
            this.save.Click += new System.EventHandler(this.save_Click);
            // 
            // denom
            // 
            this.denom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.denom.AutoSize = true;
            this.denom.Location = new System.Drawing.Point(241, 255);
            this.denom.Name = "denom";
            this.denom.Size = new System.Drawing.Size(39, 13);
            this.denom.TabIndex = 6;
            this.denom.Text = "denom";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(227, 255);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(12, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "/";
            // 
            // moveLeft
            // 
            this.moveLeft.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.moveLeft.Enabled = false;
            this.moveLeft.Location = new System.Drawing.Point(348, 269);
            this.moveLeft.Name = "moveLeft";
            this.moveLeft.Size = new System.Drawing.Size(32, 23);
            this.moveLeft.TabIndex = 8;
            this.moveLeft.Text = "<";
            this.moveLeft.UseVisualStyleBackColor = true;
            this.moveLeft.Click += new System.EventHandler(this.moveLeft_Click);
            // 
            // moveRight
            // 
            this.moveRight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.moveRight.Enabled = false;
            this.moveRight.Location = new System.Drawing.Point(405, 269);
            this.moveRight.Name = "moveRight";
            this.moveRight.Size = new System.Drawing.Size(32, 23);
            this.moveRight.TabIndex = 9;
            this.moveRight.Text = ">";
            this.moveRight.UseVisualStyleBackColor = true;
            this.moveRight.Click += new System.EventHandler(this.moveRight_Click);
            // 
            // num
            // 
            this.num.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.num.BackColor = System.Drawing.SystemColors.ControlLight;
            this.num.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.num.Enabled = false;
            this.num.Location = new System.Drawing.Point(188, 255);
            this.num.Name = "num";
            this.num.Size = new System.Drawing.Size(33, 13);
            this.num.TabIndex = 10;
            this.num.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.num.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.num_KeyPress);
            // 
            // eventText
            // 
            this.eventText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.eventText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.eventText.Enabled = false;
            this.eventText.Location = new System.Drawing.Point(301, 192);
            this.eventText.Name = "eventText";
            this.eventText.Size = new System.Drawing.Size(136, 20);
            this.eventText.TabIndex = 11;
            // 
            // updateEV
            // 
            this.updateEV.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.updateEV.Enabled = false;
            this.updateEV.Location = new System.Drawing.Point(374, 218);
            this.updateEV.Name = "updateEV";
            this.updateEV.Size = new System.Drawing.Size(63, 23);
            this.updateEV.TabIndex = 12;
            this.updateEV.Text = "update";
            this.updateEV.UseVisualStyleBackColor = true;
            this.updateEV.Click += new System.EventHandler(this.updateEV_Click);
            // 
            // remove
            // 
            this.remove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.remove.Enabled = false;
            this.remove.Location = new System.Drawing.Point(202, 272);
            this.remove.Name = "remove";
            this.remove.Size = new System.Drawing.Size(63, 23);
            this.remove.TabIndex = 13;
            this.remove.Text = "remove";
            this.remove.UseVisualStyleBackColor = true;
            this.remove.Click += new System.EventHandler(this.remove_Click);
            // 
            // redoBut
            // 
            this.redoBut.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.redoBut.Enabled = false;
            this.redoBut.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.redoBut.Location = new System.Drawing.Point(143, 272);
            this.redoBut.Name = "redoBut";
            this.redoBut.Size = new System.Drawing.Size(26, 23);
            this.redoBut.TabIndex = 15;
            this.redoBut.Text = "r";
            this.redoBut.UseVisualStyleBackColor = true;
            // 
            // undoBut
            // 
            this.undoBut.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.undoBut.Enabled = false;
            this.undoBut.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.undoBut.Location = new System.Drawing.Point(111, 272);
            this.undoBut.Name = "undoBut";
            this.undoBut.Size = new System.Drawing.Size(26, 23);
            this.undoBut.TabIndex = 14;
            this.undoBut.Text = "u";
            this.undoBut.UseVisualStyleBackColor = true;
            this.undoBut.Click += new System.EventHandler(this.undoBut_Click);
            // 
            // StepViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(449, 304);
            this.Controls.Add(this.redoBut);
            this.Controls.Add(this.undoBut);
            this.Controls.Add(this.remove);
            this.Controls.Add(this.updateEV);
            this.Controls.Add(this.eventText);
            this.Controls.Add(this.num);
            this.Controls.Add(this.moveRight);
            this.Controls.Add(this.moveLeft);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.denom);
            this.Controls.Add(this.yPos);
            this.Controls.Add(this.xPos);
            this.Controls.Add(this.StepsList);
            this.Controls.Add(this.StepPic);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(465, 342);
            this.Name = "StepViewer";
            this.Text = "View Steps";
            ((System.ComponentModel.ISupportInitialize)(this.StepPic)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox StepPic;
        private System.Windows.Forms.ListBox StepsList;
        private System.Windows.Forms.TextBox xPos;
        private System.Windows.Forms.TextBox yPos;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem Open;
        private System.Windows.Forms.Label denom;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button moveLeft;
        private System.Windows.Forms.Button moveRight;
        private System.Windows.Forms.TextBox num;
        private System.Windows.Forms.TextBox eventText;
        private System.Windows.Forms.Button updateEV;
        private System.Windows.Forms.ToolStripMenuItem save;
        private System.Windows.Forms.Button remove;
        private System.Windows.Forms.Button redoBut;
        private System.Windows.Forms.Button undoBut;
    }
}

