namespace ProgramaSiprosaNeurociencia
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.pbcbzArr = new System.Windows.Forms.PictureBox();
            this.pbpieArr = new System.Windows.Forms.PictureBox();
            this.pbcmArr = new System.Windows.Forms.PictureBox();
            this.pbcbzAba = new System.Windows.Forms.PictureBox();
            this.pbpieAba = new System.Windows.Forms.PictureBox();
            this.pbcmAba = new System.Windows.Forms.PictureBox();
            this.pbpenAd = new System.Windows.Forms.PictureBox();
            this.pbpenAt = new System.Windows.Forms.PictureBox();
            this.pbreposo = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menúToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.seleccionarPuertoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.desbloquearCamaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ArduinoPort = new System.IO.Ports.SerialPort(this.components);
            this.portTimer = new System.Windows.Forms.Timer(this.components);
            this.MoveTimer = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.timerPen = new System.Windows.Forms.Timer(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.button3 = new System.Windows.Forms.Button();
            this.unlockTimer = new System.Windows.Forms.Timer(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pbcbzArr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbpieArr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbcmArr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbcbzAba)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbpieAba)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbcmAba)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbpenAd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbpenAt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbreposo)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pbcbzArr
            // 
            this.pbcbzArr.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbcbzArr.Image = global::ProgramaSiprosaNeurociencia.Properties.Resources.az_cbz_arr;
            this.pbcbzArr.Location = new System.Drawing.Point(3, 3);
            this.pbcbzArr.Name = "pbcbzArr";
            this.pbcbzArr.Size = new System.Drawing.Size(145, 90);
            this.pbcbzArr.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbcbzArr.TabIndex = 0;
            this.pbcbzArr.TabStop = false;
            this.pbcbzArr.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // pbpieArr
            // 
            this.pbpieArr.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbpieArr.Image = ((System.Drawing.Image)(resources.GetObject("pbpieArr.Image")));
            this.pbpieArr.Location = new System.Drawing.Point(154, 3);
            this.pbpieArr.Name = "pbpieArr";
            this.pbpieArr.Size = new System.Drawing.Size(145, 90);
            this.pbpieArr.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbpieArr.TabIndex = 1;
            this.pbpieArr.TabStop = false;
            this.pbpieArr.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // pbcmArr
            // 
            this.pbcmArr.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbcmArr.Image = ((System.Drawing.Image)(resources.GetObject("pbcmArr.Image")));
            this.pbcmArr.Location = new System.Drawing.Point(305, 3);
            this.pbcmArr.Name = "pbcmArr";
            this.pbcmArr.Size = new System.Drawing.Size(145, 90);
            this.pbcmArr.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbcmArr.TabIndex = 2;
            this.pbcmArr.TabStop = false;
            this.pbcmArr.Click += new System.EventHandler(this.pictureBox3_Click);
            // 
            // pbcbzAba
            // 
            this.pbcbzAba.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbcbzAba.Image = global::ProgramaSiprosaNeurociencia.Properties.Resources.az_cbz_aba;
            this.pbcbzAba.Location = new System.Drawing.Point(3, 99);
            this.pbcbzAba.Name = "pbcbzAba";
            this.pbcbzAba.Size = new System.Drawing.Size(145, 90);
            this.pbcbzAba.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbcbzAba.TabIndex = 5;
            this.pbcbzAba.TabStop = false;
            this.pbcbzAba.Click += new System.EventHandler(this.pictureBox4_Click);
            // 
            // pbpieAba
            // 
            this.pbpieAba.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbpieAba.Image = ((System.Drawing.Image)(resources.GetObject("pbpieAba.Image")));
            this.pbpieAba.Location = new System.Drawing.Point(154, 99);
            this.pbpieAba.Name = "pbpieAba";
            this.pbpieAba.Size = new System.Drawing.Size(145, 90);
            this.pbpieAba.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbpieAba.TabIndex = 4;
            this.pbpieAba.TabStop = false;
            this.pbpieAba.Click += new System.EventHandler(this.pictureBox5_Click);
            // 
            // pbcmAba
            // 
            this.pbcmAba.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbcmAba.Image = global::ProgramaSiprosaNeurociencia.Properties.Resources.az_cm_aba;
            this.pbcmAba.Location = new System.Drawing.Point(305, 99);
            this.pbcmAba.Name = "pbcmAba";
            this.pbcmAba.Size = new System.Drawing.Size(145, 90);
            this.pbcmAba.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbcmAba.TabIndex = 3;
            this.pbcmAba.TabStop = false;
            this.pbcmAba.Click += new System.EventHandler(this.pictureBox6_Click);
            // 
            // pbpenAd
            // 
            this.pbpenAd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbpenAd.Image = global::ProgramaSiprosaNeurociencia.Properties.Resources.az_pen_ad;
            this.pbpenAd.Location = new System.Drawing.Point(3, 195);
            this.pbpenAd.Name = "pbpenAd";
            this.pbpenAd.Size = new System.Drawing.Size(145, 90);
            this.pbpenAd.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbpenAd.TabIndex = 8;
            this.pbpenAd.TabStop = false;
            this.pbpenAd.Click += new System.EventHandler(this.pictureBox7_Click);
            // 
            // pbpenAt
            // 
            this.pbpenAt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbpenAt.Image = ((System.Drawing.Image)(resources.GetObject("pbpenAt.Image")));
            this.pbpenAt.Location = new System.Drawing.Point(154, 195);
            this.pbpenAt.Name = "pbpenAt";
            this.pbpenAt.Size = new System.Drawing.Size(145, 90);
            this.pbpenAt.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbpenAt.TabIndex = 7;
            this.pbpenAt.TabStop = false;
            this.pbpenAt.Click += new System.EventHandler(this.pictureBox8_Click);
            // 
            // pbreposo
            // 
            this.pbreposo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbreposo.Image = global::ProgramaSiprosaNeurociencia.Properties.Resources.az_desbloq;
            this.pbreposo.Location = new System.Drawing.Point(305, 195);
            this.pbreposo.Name = "pbreposo";
            this.pbreposo.Size = new System.Drawing.Size(145, 90);
            this.pbreposo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbreposo.TabIndex = 6;
            this.pbreposo.TabStop = false;
            this.pbreposo.Click += new System.EventHandler(this.pictureBox9_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menúToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(608, 24);
            this.menuStrip1.TabIndex = 9;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menúToolStripMenuItem
            // 
            this.menúToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.seleccionarPuertoToolStripMenuItem,
            this.desbloquearCamaToolStripMenuItem,
            this.toolStripSeparator1,
            this.salirToolStripMenuItem});
            this.menúToolStripMenuItem.Name = "menúToolStripMenuItem";
            this.menúToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.menúToolStripMenuItem.Text = "Menú";
            // 
            // seleccionarPuertoToolStripMenuItem
            // 
            this.seleccionarPuertoToolStripMenuItem.Name = "seleccionarPuertoToolStripMenuItem";
            this.seleccionarPuertoToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.seleccionarPuertoToolStripMenuItem.Text = "Posicion Ventana";
            this.seleccionarPuertoToolStripMenuItem.Click += new System.EventHandler(this.seleccionarPuertoToolStripMenuItem_Click);
            // 
            // desbloquearCamaToolStripMenuItem
            // 
            this.desbloquearCamaToolStripMenuItem.Name = "desbloquearCamaToolStripMenuItem";
            this.desbloquearCamaToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.desbloquearCamaToolStripMenuItem.Text = "Desbloquear Cama";
            this.desbloquearCamaToolStripMenuItem.Click += new System.EventHandler(this.desbloquearCamaToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(171, 6);
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.salirToolStripMenuItem.Text = "Salir";
            this.salirToolStripMenuItem.Click += new System.EventHandler(this.salirToolStripMenuItem_Click);
            // 
            // ArduinoPort
            // 
            this.ArduinoPort.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.ArduinoPort_DataReceived);
            // 
            // portTimer
            // 
            this.portTimer.Enabled = true;
            this.portTimer.Interval = 3000;
            this.portTimer.Tick += new System.EventHandler(this.portTimer_Tick);
            // 
            // MoveTimer
            // 
            this.MoveTimer.Interval = 1000;
            this.MoveTimer.Tick += new System.EventHandler(this.MoveTimer_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(510, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 10;
            // 
            // timerPen
            // 
            this.timerPen.Interval = 1000;
            this.timerPen.Tick += new System.EventHandler(this.timerPen_Tick);
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(513, 213);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(61, 54);
            this.button1.TabIndex = 11;
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Controls.Add(this.pbcbzArr, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.pbpieArr, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.pbcmArr, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.pbreposo, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.pbpenAt, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.pbpenAd, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.pbcmAba, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.pbpieAba, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.pbcbzAba, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.button1, 4, 2);
            this.tableLayoutPanel1.Controls.Add(this.button3, 4, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 24);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(604, 288);
            this.tableLayoutPanel1.TabIndex = 12;
            // 
            // button3
            // 
            this.button3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button3.BackgroundImage")));
            this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button3.Location = new System.Drawing.Point(513, 117);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(61, 54);
            this.button3.TabIndex = 13;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // unlockTimer
            // 
            this.unlockTimer.Interval = 1000;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(608, 318);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximumSize = new System.Drawing.Size(624, 357);
            this.Name = "Form1";
            this.Text = "Software Cama";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbcbzArr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbpieArr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbcmArr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbcbzAba)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbpieAba)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbcmAba)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbpenAd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbpenAt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbreposo)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbcbzArr;
        private System.Windows.Forms.PictureBox pbpieArr;
        private System.Windows.Forms.PictureBox pbcmArr;
        private System.Windows.Forms.PictureBox pbcbzAba;
        private System.Windows.Forms.PictureBox pbpieAba;
        private System.Windows.Forms.PictureBox pbcmAba;
        private System.Windows.Forms.PictureBox pbpenAd;
        private System.Windows.Forms.PictureBox pbpenAt;
        private System.Windows.Forms.PictureBox pbreposo;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menúToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem seleccionarPuertoToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
        public System.IO.Ports.SerialPort ArduinoPort;
        private System.Windows.Forms.Timer portTimer;
        private System.Windows.Forms.Timer MoveTimer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timerPen;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ToolStripMenuItem desbloquearCamaToolStripMenuItem;
        private System.Windows.Forms.Timer unlockTimer;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}

