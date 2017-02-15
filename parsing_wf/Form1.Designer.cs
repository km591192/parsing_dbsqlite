namespace parsing_wf
{
    partial class Form1
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btnparsing = new System.Windows.Forms.Button();
            this.tburl = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbtime = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.rtbans = new System.Windows.Forms.RichTextBox();
            this.btnclear = new System.Windows.Forms.Button();
            this.rtbdb = new System.Windows.Forms.RichTextBox();
            this.btnfinddburl = new System.Windows.Forms.Button();
            this.btnalldb = new System.Windows.Forms.Button();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.tbid = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnfdbid = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnparsing
            // 
            this.btnparsing.Location = new System.Drawing.Point(15, 31);
            this.btnparsing.Name = "btnparsing";
            this.btnparsing.Size = new System.Drawing.Size(75, 23);
            this.btnparsing.TabIndex = 0;
            this.btnparsing.Text = "Parsing";
            this.btnparsing.UseVisualStyleBackColor = true;
            this.btnparsing.Click += new System.EventHandler(this.btnparsing_Click);
            // 
            // tburl
            // 
            this.tburl.Location = new System.Drawing.Point(50, 5);
            this.tburl.Name = "tburl";
            this.tburl.Size = new System.Drawing.Size(307, 20);
            this.tburl.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "URL:";
            // 
            // tbtime
            // 
            this.tbtime.Location = new System.Drawing.Point(184, 31);
            this.tbtime.Name = "tbtime";
            this.tbtime.Size = new System.Drawing.Size(105, 20);
            this.tbtime.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(96, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Responce Time";
            // 
            // rtbans
            // 
            this.rtbans.Location = new System.Drawing.Point(15, 75);
            this.rtbans.Name = "rtbans";
            this.rtbans.Size = new System.Drawing.Size(316, 294);
            this.rtbans.TabIndex = 6;
            this.rtbans.Text = "";
            // 
            // btnclear
            // 
            this.btnclear.Location = new System.Drawing.Point(576, 5);
            this.btnclear.Name = "btnclear";
            this.btnclear.Size = new System.Drawing.Size(75, 23);
            this.btnclear.TabIndex = 7;
            this.btnclear.Text = "Clear";
            this.btnclear.UseVisualStyleBackColor = true;
            this.btnclear.Click += new System.EventHandler(this.btnclear_Click);
            // 
            // rtbdb
            // 
            this.rtbdb.Location = new System.Drawing.Point(337, 75);
            this.rtbdb.Name = "rtbdb";
            this.rtbdb.Size = new System.Drawing.Size(317, 294);
            this.rtbdb.TabIndex = 8;
            this.rtbdb.Text = "";
            // 
            // btnfinddburl
            // 
            this.btnfinddburl.Location = new System.Drawing.Point(417, 33);
            this.btnfinddburl.Name = "btnfinddburl";
            this.btnfinddburl.Size = new System.Drawing.Size(50, 23);
            this.btnfinddburl.TabIndex = 9;
            this.btnfinddburl.Text = "URL";
            this.btnfinddburl.UseVisualStyleBackColor = true;
            this.btnfinddburl.Click += new System.EventHandler(this.btnfinddburl_Click);
            // 
            // btnalldb
            // 
            this.btnalldb.Location = new System.Drawing.Point(576, 36);
            this.btnalldb.Name = "btnalldb";
            this.btnalldb.Size = new System.Drawing.Size(75, 23);
            this.btnalldb.TabIndex = 13;
            this.btnalldb.Text = "All info";
            this.btnalldb.UseVisualStyleBackColor = true;
            this.btnalldb.Click += new System.EventHandler(this.btnalldb_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(374, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(21, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "ID:";
            // 
            // tbid
            // 
            this.tbid.Location = new System.Drawing.Point(401, 5);
            this.tbid.Name = "tbid";
            this.tbid.Size = new System.Drawing.Size(54, 20);
            this.tbid.TabIndex = 14;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(312, 38);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "Find in database by";
            // 
            // btnfdbid
            // 
            this.btnfdbid.Location = new System.Drawing.Point(473, 33);
            this.btnfdbid.Name = "btnfdbid";
            this.btnfdbid.Size = new System.Drawing.Size(50, 23);
            this.btnfdbid.TabIndex = 17;
            this.btnfdbid.Text = "ID";
            this.btnfdbid.UseVisualStyleBackColor = true;
            this.btnfdbid.Click += new System.EventHandler(this.btnfdbid_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(663, 381);
            this.Controls.Add(this.btnfdbid);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbid);
            this.Controls.Add(this.btnalldb);
            this.Controls.Add(this.btnfinddburl);
            this.Controls.Add(this.rtbdb);
            this.Controls.Add(this.btnclear);
            this.Controls.Add(this.rtbans);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbtime);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tburl);
            this.Controls.Add(this.btnparsing);
            this.Name = "Form1";
            this.Text = "Parsing";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnparsing;
        private System.Windows.Forms.TextBox tburl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbtime;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox rtbans;
        private System.Windows.Forms.Button btnclear;
        private System.Windows.Forms.RichTextBox rtbdb;
        private System.Windows.Forms.Button btnfinddburl;
        private System.Windows.Forms.Button btnalldb;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbid;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnfdbid;
    }
}

