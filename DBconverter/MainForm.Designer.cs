namespace DBconverter
{
    partial class MainForm
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.btnstart = new System.Windows.Forms.Button();
            this.listViewresult = new System.Windows.Forms.ListView();
            this.comboBoxmonth = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxYear = new System.Windows.Forms.ComboBox();
            this.textBoxdbpath = new System.Windows.Forms.TextBox();
            this.textBoxcsvpath = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.numericUpDownFields = new System.Windows.Forms.NumericUpDown();
            this.groupBoxFields = new System.Windows.Forms.GroupBox();
            this.groupBoxDate = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFields)).BeginInit();
            this.groupBoxFields.SuspendLayout();
            this.groupBoxDate.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnstart
            // 
            this.btnstart.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnstart.Location = new System.Drawing.Point(497, 271);
            this.btnstart.Name = "btnstart";
            this.btnstart.Size = new System.Drawing.Size(90, 40);
            this.btnstart.TabIndex = 0;
            this.btnstart.Text = "Start";
            this.btnstart.UseVisualStyleBackColor = true;
            this.btnstart.Click += new System.EventHandler(this.Button1_Click);
            // 
            // listViewresult
            // 
            this.listViewresult.HideSelection = false;
            this.listViewresult.Location = new System.Drawing.Point(45, 115);
            this.listViewresult.Name = "listViewresult";
            this.listViewresult.Size = new System.Drawing.Size(405, 250);
            this.listViewresult.TabIndex = 1;
            this.listViewresult.UseCompatibleStateImageBehavior = false;
            // 
            // comboBoxmonth
            // 
            this.comboBoxmonth.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxmonth.FormattingEnabled = true;
            this.comboBoxmonth.Location = new System.Drawing.Point(17, 33);
            this.comboBoxmonth.Name = "comboBoxmonth";
            this.comboBoxmonth.Size = new System.Drawing.Size(88, 21);
            this.comboBoxmonth.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(494, 170);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "Month:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(494, 217);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "Year:";
            // 
            // comboBoxYear
            // 
            this.comboBoxYear.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxYear.FormattingEnabled = true;
            this.comboBoxYear.Location = new System.Drawing.Point(18, 66);
            this.comboBoxYear.Name = "comboBoxYear";
            this.comboBoxYear.Size = new System.Drawing.Size(88, 21);
            this.comboBoxYear.TabIndex = 4;
            // 
            // textBoxdbpath
            // 
            this.textBoxdbpath.Font = new System.Drawing.Font("Calibri Light", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxdbpath.Location = new System.Drawing.Point(45, 37);
            this.textBoxdbpath.Name = "textBoxdbpath";
            this.textBoxdbpath.ReadOnly = true;
            this.textBoxdbpath.Size = new System.Drawing.Size(405, 21);
            this.textBoxdbpath.TabIndex = 6;
            // 
            // textBoxcsvpath
            // 
            this.textBoxcsvpath.Font = new System.Drawing.Font("Calibri Light", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxcsvpath.Location = new System.Drawing.Point(45, 87);
            this.textBoxcsvpath.Name = "textBoxcsvpath";
            this.textBoxcsvpath.ReadOnly = true;
            this.textBoxcsvpath.Size = new System.Drawing.Size(405, 21);
            this.textBoxcsvpath.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(44, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 15);
            this.label3.TabIndex = 8;
            this.label3.Text = "database path:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(44, 71);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 15);
            this.label4.TabIndex = 9;
            this.label4.Text = "csv path:";
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BackgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BackgroundWorker1_RunWorkerCompleted);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Location = new System.Drawing.Point(4, 24);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(114, 17);
            this.checkBox1.TabIndex = 10;
            this.checkBox1.Text = "Max fields enabled";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.CheckBox1_CheckedChanged);
            // 
            // numericUpDownFields
            // 
            this.numericUpDownFields.Location = new System.Drawing.Point(33, 52);
            this.numericUpDownFields.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDownFields.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericUpDownFields.Name = "numericUpDownFields";
            this.numericUpDownFields.Size = new System.Drawing.Size(34, 20);
            this.numericUpDownFields.TabIndex = 12;
            this.numericUpDownFields.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // groupBoxFields
            // 
            this.groupBoxFields.Controls.Add(this.numericUpDownFields);
            this.groupBoxFields.Controls.Add(this.checkBox1);
            this.groupBoxFields.Location = new System.Drawing.Point(478, 63);
            this.groupBoxFields.Name = "groupBoxFields";
            this.groupBoxFields.Size = new System.Drawing.Size(115, 81);
            this.groupBoxFields.TabIndex = 13;
            this.groupBoxFields.TabStop = false;
            this.groupBoxFields.Text = "Fields";
            // 
            // groupBoxDate
            // 
            this.groupBoxDate.Controls.Add(this.comboBoxYear);
            this.groupBoxDate.Controls.Add(this.comboBoxmonth);
            this.groupBoxDate.Location = new System.Drawing.Point(478, 150);
            this.groupBoxDate.Name = "groupBoxDate";
            this.groupBoxDate.Size = new System.Drawing.Size(114, 115);
            this.groupBoxDate.TabIndex = 14;
            this.groupBoxDate.TabStop = false;
            this.groupBoxDate.Text = "Date";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(627, 389);
            this.Controls.Add(this.groupBoxDate);
            this.Controls.Add(this.groupBoxFields);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxcsvpath);
            this.Controls.Add(this.textBoxdbpath);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listViewresult);
            this.Controls.Add(this.btnstart);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "Database converter";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFields)).EndInit();
            this.groupBoxFields.ResumeLayout(false);
            this.groupBoxFields.PerformLayout();
            this.groupBoxDate.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnstart;
        private System.Windows.Forms.ListView listViewresult;
        private System.Windows.Forms.ComboBox comboBoxmonth;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxYear;
        private System.Windows.Forms.TextBox textBoxdbpath;
        private System.Windows.Forms.TextBox textBoxcsvpath;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.NumericUpDown numericUpDownFields;
        private System.Windows.Forms.GroupBox groupBoxFields;
        private System.Windows.Forms.GroupBox groupBoxDate;
    }
}

