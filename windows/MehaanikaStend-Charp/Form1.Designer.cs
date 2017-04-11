namespace MehaanikaStend_Charp
{
    partial class mainWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainWindow));
            this.graphUpdateRate = new System.Windows.Forms.Timer(this.components);
            this.portList = new System.Windows.Forms.ComboBox();
            this.portConnect = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.zed = new ZedGraph.ZedGraphControl();
            this.label1 = new System.Windows.Forms.Label();
            this.updateRateChanger = new System.Windows.Forms.NumericUpDown();
            this.clearGraph = new System.Windows.Forms.Button();
            this.stopCapture = new System.Windows.Forms.Button();
            this.startCapture = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.rpmValue = new System.Windows.Forms.TextBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.tempValue = new System.Windows.Forms.TextBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.torqueValue = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.pollValue = new System.Windows.Forms.TextBox();
            this.calSettings = new System.Windows.Forms.Button();
            this.updateDisplays = new System.Windows.Forms.Timer(this.components);
            this.About = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.updateRateChanger)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // graphUpdateRate
            // 
            this.graphUpdateRate.Interval = 500;
            this.graphUpdateRate.Tick += new System.EventHandler(this.graphUpdateRate_Tick);
            // 
            // portList
            // 
            this.portList.FormattingEnabled = true;
            this.portList.Location = new System.Drawing.Point(6, 19);
            this.portList.Name = "portList";
            this.portList.Size = new System.Drawing.Size(64, 21);
            this.portList.TabIndex = 0;
            // 
            // portConnect
            // 
            this.portConnect.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.portConnect.Location = new System.Drawing.Point(76, 18);
            this.portConnect.Name = "portConnect";
            this.portConnect.Size = new System.Drawing.Size(103, 21);
            this.portConnect.TabIndex = 1;
            this.portConnect.Text = "Ühenda";
            this.portConnect.UseVisualStyleBackColor = true;
            this.portConnect.Click += new System.EventHandler(this.portConnect_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.portList);
            this.groupBox1.Controls.Add(this.portConnect);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(190, 53);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Arduino ühendus";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.zed);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.updateRateChanger);
            this.groupBox2.Controls.Add(this.clearGraph);
            this.groupBox2.Controls.Add(this.stopCapture);
            this.groupBox2.Controls.Add(this.startCapture);
            this.groupBox2.Location = new System.Drawing.Point(18, 127);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1173, 588);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Ajadomeen";
            // 
            // zed
            // 
            this.zed.EditModifierKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.E)));
            this.zed.IsAntiAlias = true;
            this.zed.IsEnableSelection = true;
            this.zed.Location = new System.Drawing.Point(6, 76);
            this.zed.Name = "zed";
            this.zed.ScrollGrace = 0D;
            this.zed.ScrollMaxX = 0D;
            this.zed.ScrollMaxY = 0D;
            this.zed.ScrollMaxY2 = 0D;
            this.zed.ScrollMinX = 0D;
            this.zed.ScrollMinY = 0D;
            this.zed.ScrollMinY2 = 0D;
            this.zed.Size = new System.Drawing.Size(1161, 506);
            this.zed.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.label1.Location = new System.Drawing.Point(617, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 32);
            this.label1.TabIndex = 12;
            this.label1.Text = "Proovivõtu \r\nkiirus [ ms ]";
            // 
            // updateRateChanger
            // 
            this.updateRateChanger.Font = new System.Drawing.Font("Trebuchet MS", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.updateRateChanger.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.updateRateChanger.Location = new System.Drawing.Point(698, 37);
            this.updateRateChanger.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.updateRateChanger.Minimum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.updateRateChanger.Name = "updateRateChanger";
            this.updateRateChanger.Size = new System.Drawing.Size(78, 32);
            this.updateRateChanger.TabIndex = 11;
            this.updateRateChanger.Value = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.updateRateChanger.ValueChanged += new System.EventHandler(this.updateRateChanger_ValueChanged);
            // 
            // clearGraph
            // 
            this.clearGraph.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.clearGraph.Font = new System.Drawing.Font("Trebuchet MS", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.clearGraph.Location = new System.Drawing.Point(782, 33);
            this.clearGraph.Name = "clearGraph";
            this.clearGraph.Size = new System.Drawing.Size(89, 38);
            this.clearGraph.TabIndex = 10;
            this.clearGraph.Text = "Puhasta";
            this.clearGraph.UseVisualStyleBackColor = false;
            this.clearGraph.Click += new System.EventHandler(this.clearGraph_Click);
            // 
            // stopCapture
            // 
            this.stopCapture.BackColor = System.Drawing.Color.Red;
            this.stopCapture.Font = new System.Drawing.Font("Trebuchet MS", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.stopCapture.ForeColor = System.Drawing.Color.White;
            this.stopCapture.Location = new System.Drawing.Point(877, 34);
            this.stopCapture.Name = "stopCapture";
            this.stopCapture.Size = new System.Drawing.Size(142, 38);
            this.stopCapture.TabIndex = 8;
            this.stopCapture.Text = "PEATA";
            this.stopCapture.UseVisualStyleBackColor = false;
            this.stopCapture.Click += new System.EventHandler(this.stopCapture_Click);
            // 
            // startCapture
            // 
            this.startCapture.BackColor = System.Drawing.Color.Lime;
            this.startCapture.Font = new System.Drawing.Font("Trebuchet MS", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.startCapture.ForeColor = System.Drawing.SystemColors.ControlText;
            this.startCapture.Location = new System.Drawing.Point(1020, 34);
            this.startCapture.Name = "startCapture";
            this.startCapture.Size = new System.Drawing.Size(142, 38);
            this.startCapture.TabIndex = 7;
            this.startCapture.Text = "KÄIVITA";
            this.startCapture.UseVisualStyleBackColor = false;
            this.startCapture.Click += new System.EventHandler(this.startCapture_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.groupBox7);
            this.groupBox3.Controls.Add(this.groupBox6);
            this.groupBox3.Controls.Add(this.groupBox5);
            this.groupBox3.Controls.Add(this.groupBox4);
            this.groupBox3.Location = new System.Drawing.Point(320, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(871, 109);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Hetketulemused";
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.rpmValue);
            this.groupBox7.Location = new System.Drawing.Point(651, 19);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(209, 78);
            this.groupBox7.TabIndex = 2;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "RPM";
            // 
            // rpmValue
            // 
            this.rpmValue.BackColor = System.Drawing.Color.WhiteSmoke;
            this.rpmValue.Font = new System.Drawing.Font("Trebuchet MS", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.rpmValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.rpmValue.Location = new System.Drawing.Point(17, 19);
            this.rpmValue.Name = "rpmValue";
            this.rpmValue.ReadOnly = true;
            this.rpmValue.Size = new System.Drawing.Size(177, 45);
            this.rpmValue.TabIndex = 0;
            this.rpmValue.Text = "n/a";
            this.rpmValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.tempValue);
            this.groupBox6.Location = new System.Drawing.Point(436, 19);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(209, 78);
            this.groupBox6.TabIndex = 1;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Temperatuuri andur";
            // 
            // tempValue
            // 
            this.tempValue.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tempValue.Font = new System.Drawing.Font("Trebuchet MS", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.tempValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.tempValue.Location = new System.Drawing.Point(17, 19);
            this.tempValue.Name = "tempValue";
            this.tempValue.ReadOnly = true;
            this.tempValue.Size = new System.Drawing.Size(177, 45);
            this.tempValue.TabIndex = 0;
            this.tempValue.Text = "n/a";
            this.tempValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.torqueValue);
            this.groupBox5.Location = new System.Drawing.Point(221, 19);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(209, 78);
            this.groupBox5.TabIndex = 1;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Väände andur";
            // 
            // torqueValue
            // 
            this.torqueValue.BackColor = System.Drawing.Color.WhiteSmoke;
            this.torqueValue.Font = new System.Drawing.Font("Trebuchet MS", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.torqueValue.ForeColor = System.Drawing.Color.Red;
            this.torqueValue.Location = new System.Drawing.Point(17, 19);
            this.torqueValue.Name = "torqueValue";
            this.torqueValue.ReadOnly = true;
            this.torqueValue.Size = new System.Drawing.Size(177, 45);
            this.torqueValue.TabIndex = 0;
            this.torqueValue.Text = "n/a";
            this.torqueValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.pollValue);
            this.groupBox4.Location = new System.Drawing.Point(6, 19);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(209, 78);
            this.groupBox4.TabIndex = 0;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Tõmbe andur";
            // 
            // pollValue
            // 
            this.pollValue.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pollValue.Font = new System.Drawing.Font("Trebuchet MS", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.pollValue.ForeColor = System.Drawing.Color.Blue;
            this.pollValue.Location = new System.Drawing.Point(17, 19);
            this.pollValue.Name = "pollValue";
            this.pollValue.ReadOnly = true;
            this.pollValue.Size = new System.Drawing.Size(177, 45);
            this.pollValue.TabIndex = 0;
            this.pollValue.Text = "n/a";
            this.pollValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // calSettings
            // 
            this.calSettings.Location = new System.Drawing.Point(12, 69);
            this.calSettings.Name = "calSettings";
            this.calSettings.Size = new System.Drawing.Size(190, 23);
            this.calSettings.TabIndex = 6;
            this.calSettings.Text = "Seaded";
            this.calSettings.UseVisualStyleBackColor = true;
            this.calSettings.Click += new System.EventHandler(this.calSettings_Click);
            // 
            // updateDisplays
            // 
            this.updateDisplays.Enabled = true;
            this.updateDisplays.Interval = 200;
            this.updateDisplays.Tick += new System.EventHandler(this.updateDisplays_Tick);
            // 
            // About
            // 
            this.About.Location = new System.Drawing.Point(12, 97);
            this.About.Name = "About";
            this.About.Size = new System.Drawing.Size(190, 24);
            this.About.TabIndex = 8;
            this.About.Text = "?";
            this.About.UseVisualStyleBackColor = true;
            this.About.Click += new System.EventHandler(this.About_Click);
            // 
            // mainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(1197, 727);
            this.Controls.Add(this.About);
            this.Controls.Add(this.calSettings);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "mainWindow";
            this.Text = "MT TTK © 2017";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.mainWindow_FormClosed);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.updateRateChanger)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer graphUpdateRate;
        public System.Windows.Forms.ComboBox portList;
        private System.Windows.Forms.Button portConnect;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.TextBox tempValue;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox torqueValue;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox pollValue;
        private System.Windows.Forms.Button calSettings;
        private System.Windows.Forms.Button stopCapture;
        private System.Windows.Forms.Button startCapture;
        private System.Windows.Forms.Button clearGraph;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.TextBox rpmValue;
        private System.Windows.Forms.Timer updateDisplays;
        private System.Windows.Forms.NumericUpDown updateRateChanger;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button About;
        private ZedGraph.ZedGraphControl zed;
    }
}

