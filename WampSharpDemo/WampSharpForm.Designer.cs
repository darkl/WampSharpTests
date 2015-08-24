namespace WampSharpDemo
{
    partial class WampSharpForm
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
            this.loadTestButton = new System.Windows.Forms.Button();
            this.descriptionTb = new System.Windows.Forms.TextBox();
            this.producedTxtBx = new System.Windows.Forms.TextBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.subscriptionsTb = new System.Windows.Forms.TextBox();
            this.topicsTb = new System.Windows.Forms.TextBox();
            this.sessionsTb = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.consumedTb = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.numClientsTb = new System.Windows.Forms.TextBox();
            this.eventToTestTb = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.rateTb = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.eventProcessTimeTb = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.case1 = new System.Windows.Forms.RadioButton();
            this.case2 = new System.Windows.Forms.RadioButton();
            this.case3 = new System.Windows.Forms.RadioButton();
            this.case4 = new System.Windows.Forms.RadioButton();
            this.case5 = new System.Windows.Forms.RadioButton();
            this.case6 = new System.Windows.Forms.RadioButton();
            this.label10 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // loadTestButton
            // 
            this.loadTestButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loadTestButton.Location = new System.Drawing.Point(394, 35);
            this.loadTestButton.Name = "loadTestButton";
            this.loadTestButton.Size = new System.Drawing.Size(100, 91);
            this.loadTestButton.TabIndex = 0;
            this.loadTestButton.Text = "Run Load Test";
            this.loadTestButton.UseVisualStyleBackColor = true;
            this.loadTestButton.Click += new System.EventHandler(this.loadTestButton_Click);
            // 
            // descriptionTb
            // 
            this.descriptionTb.Enabled = false;
            this.descriptionTb.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.descriptionTb.Location = new System.Drawing.Point(22, 70);
            this.descriptionTb.Multiline = true;
            this.descriptionTb.Name = "descriptionTb";
            this.descriptionTb.Size = new System.Drawing.Size(366, 55);
            this.descriptionTb.TabIndex = 1;
            this.descriptionTb.Text = "Runs 10 clients subscribing to 1000  topics. Server makes publications at 1000 ev" +
    "ents per second rate. Check WampSharpDemo.log for details.";
            // 
            // producedTxtBx
            // 
            this.producedTxtBx.Enabled = false;
            this.producedTxtBx.Location = new System.Drawing.Point(149, 15);
            this.producedTxtBx.Name = "producedTxtBx";
            this.producedTxtBx.Size = new System.Drawing.Size(100, 22);
            this.producedTxtBx.TabIndex = 3;
            this.producedTxtBx.Text = "0";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.label10);
            this.splitContainer1.Panel1.Controls.Add(this.case6);
            this.splitContainer1.Panel1.Controls.Add(this.case5);
            this.splitContainer1.Panel1.Controls.Add(this.case4);
            this.splitContainer1.Panel1.Controls.Add(this.case3);
            this.splitContainer1.Panel1.Controls.Add(this.case2);
            this.splitContainer1.Panel1.Controls.Add(this.case1);
            this.splitContainer1.Panel1.Controls.Add(this.label9);
            this.splitContainer1.Panel1.Controls.Add(this.eventProcessTimeTb);
            this.splitContainer1.Panel1.Controls.Add(this.label6);
            this.splitContainer1.Panel1.Controls.Add(this.rateTb);
            this.splitContainer1.Panel1.Controls.Add(this.label7);
            this.splitContainer1.Panel1.Controls.Add(this.eventToTestTb);
            this.splitContainer1.Panel1.Controls.Add(this.numClientsTb);
            this.splitContainer1.Panel1.Controls.Add(this.comboBox1);
            this.splitContainer1.Panel1.Controls.Add(this.loadTestButton);
            this.splitContainer1.Panel1.Controls.Add(this.descriptionTb);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.consumedTb);
            this.splitContainer1.Panel2.Controls.Add(this.label5);
            this.splitContainer1.Panel2.Controls.Add(this.sessionsTb);
            this.splitContainer1.Panel2.Controls.Add(this.topicsTb);
            this.splitContainer1.Panel2.Controls.Add(this.subscriptionsTb);
            this.splitContainer1.Panel2.Controls.Add(this.label4);
            this.splitContainer1.Panel2.Controls.Add(this.label3);
            this.splitContainer1.Panel2.Controls.Add(this.label2);
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Panel2.Controls.Add(this.producedTxtBx);
            this.splitContainer1.Size = new System.Drawing.Size(517, 310);
            this.splitContainer1.SplitterDistance = 194;
            this.splitContainer1.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "Events Produced:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(291, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "Sessions:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(291, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 17);
            this.label3.TabIndex = 7;
            this.label3.Text = "Topics:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(291, 68);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 17);
            this.label4.TabIndex = 8;
            this.label4.Text = "Subscriptions:";
            // 
            // subscriptionsTb
            // 
            this.subscriptionsTb.Enabled = false;
            this.subscriptionsTb.Location = new System.Drawing.Point(394, 66);
            this.subscriptionsTb.Name = "subscriptionsTb";
            this.subscriptionsTb.Size = new System.Drawing.Size(100, 22);
            this.subscriptionsTb.TabIndex = 9;
            this.subscriptionsTb.Text = "0";
            // 
            // topicsTb
            // 
            this.topicsTb.Enabled = false;
            this.topicsTb.Location = new System.Drawing.Point(394, 39);
            this.topicsTb.Name = "topicsTb";
            this.topicsTb.Size = new System.Drawing.Size(100, 22);
            this.topicsTb.TabIndex = 10;
            this.topicsTb.Text = "0";
            // 
            // sessionsTb
            // 
            this.sessionsTb.Enabled = false;
            this.sessionsTb.Location = new System.Drawing.Point(394, 12);
            this.sessionsTb.Name = "sessionsTb";
            this.sessionsTb.Size = new System.Drawing.Size(100, 22);
            this.sessionsTb.TabIndex = 11;
            this.sessionsTb.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(19, 43);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(126, 17);
            this.label5.TabIndex = 12;
            this.label5.Text = "Events Consumed:";
            // 
            // consumedTb
            // 
            this.consumedTb.Enabled = false;
            this.consumedTb.Location = new System.Drawing.Point(149, 42);
            this.consumedTb.Name = "consumedTb";
            this.consumedTb.Size = new System.Drawing.Size(100, 22);
            this.consumedTb.TabIndex = 13;
            this.consumedTb.Text = "0";
            // 
            // comboBox1
            // 
            this.comboBox1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "In-process subscribers",
            "Subscribers as external processes"});
            this.comboBox1.Location = new System.Drawing.Point(22, 36);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(366, 24);
            this.comboBox1.TabIndex = 2;
            this.comboBox1.Text = "In-process subscribers";
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // numClientsTb
            // 
            this.numClientsTb.Location = new System.Drawing.Point(149, 132);
            this.numClientsTb.Name = "numClientsTb";
            this.numClientsTb.Size = new System.Drawing.Size(100, 22);
            this.numClientsTb.TabIndex = 3;
            this.numClientsTb.Tag = "";
            this.numClientsTb.Text = "2";
            this.numClientsTb.TextChanged += new System.EventHandler(this.numClientsTb_TextChanged);
            // 
            // eventToTestTb
            // 
            this.eventToTestTb.Location = new System.Drawing.Point(149, 160);
            this.eventToTestTb.Name = "eventToTestTb";
            this.eventToTestTb.Size = new System.Drawing.Size(100, 22);
            this.eventToTestTb.TabIndex = 14;
            this.eventToTestTb.Tag = "";
            this.eventToTestTb.Text = "25000";
            this.eventToTestTb.TextChanged += new System.EventHandler(this.eventToTestTb_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(19, 162);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(108, 17);
            this.label7.TabIndex = 15;
            this.label7.Text = "Events To Test:";
            // 
            // rateTb
            // 
            this.rateTb.Location = new System.Drawing.Point(394, 132);
            this.rateTb.Name = "rateTb";
            this.rateTb.Size = new System.Drawing.Size(100, 22);
            this.rateTb.TabIndex = 17;
            this.rateTb.Tag = "";
            this.rateTb.Text = "1000";
            this.rateTb.TextChanged += new System.EventHandler(this.rateTb_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(264, 135);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(39, 17);
            this.label6.TabIndex = 18;
            this.label6.Text = "TPS:";
            // 
            // eventProcessTimeTb
            // 
            this.eventProcessTimeTb.Location = new System.Drawing.Point(394, 160);
            this.eventProcessTimeTb.Name = "eventProcessTimeTb";
            this.eventProcessTimeTb.Size = new System.Drawing.Size(100, 22);
            this.eventProcessTimeTb.TabIndex = 19;
            this.eventProcessTimeTb.Tag = "";
            this.eventProcessTimeTb.Text = "85";
            this.eventProcessTimeTb.TextChanged += new System.EventHandler(this.eventProcessTimeTb_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(264, 163);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(127, 17);
            this.label9.TabIndex = 20;
            this.label9.Text = "Evt done in (millis):";
            // 
            // case1
            // 
            this.case1.AutoSize = true;
            this.case1.Checked = true;
            this.case1.Location = new System.Drawing.Point(22, 9);
            this.case1.Name = "case1";
            this.case1.Size = new System.Drawing.Size(67, 21);
            this.case1.TabIndex = 21;
            this.case1.TabStop = true;
            this.case1.Text = "case1";
            this.case1.UseVisualStyleBackColor = true;
            this.case1.CheckedChanged += new System.EventHandler(this.case1_CheckedChanged);
            // 
            // case2
            // 
            this.case2.AutoSize = true;
            this.case2.Location = new System.Drawing.Point(95, 9);
            this.case2.Name = "case2";
            this.case2.Size = new System.Drawing.Size(67, 21);
            this.case2.TabIndex = 22;
            this.case2.Text = "case2";
            this.case2.UseVisualStyleBackColor = true;
            this.case2.CheckedChanged += new System.EventHandler(this.case2_CheckedChanged);
            // 
            // case3
            // 
            this.case3.AutoSize = true;
            this.case3.Location = new System.Drawing.Point(168, 9);
            this.case3.Name = "case3";
            this.case3.Size = new System.Drawing.Size(67, 21);
            this.case3.TabIndex = 23;
            this.case3.Text = "case3";
            this.case3.UseVisualStyleBackColor = true;
            this.case3.CheckedChanged += new System.EventHandler(this.case3_CheckedChanged);
            // 
            // case4
            // 
            this.case4.AutoSize = true;
            this.case4.Location = new System.Drawing.Point(235, 9);
            this.case4.Name = "case4";
            this.case4.Size = new System.Drawing.Size(67, 21);
            this.case4.TabIndex = 24;
            this.case4.Text = "case4";
            this.case4.UseVisualStyleBackColor = true;
            this.case4.CheckedChanged += new System.EventHandler(this.case4_CheckedChanged);
            // 
            // case5
            // 
            this.case5.AutoSize = true;
            this.case5.Location = new System.Drawing.Point(308, 9);
            this.case5.Name = "case5";
            this.case5.Size = new System.Drawing.Size(67, 21);
            this.case5.TabIndex = 25;
            this.case5.Text = "case5";
            this.case5.UseVisualStyleBackColor = true;
            // 
            // case6
            // 
            this.case6.AutoSize = true;
            this.case6.Location = new System.Drawing.Point(381, 9);
            this.case6.Name = "case6";
            this.case6.Size = new System.Drawing.Size(67, 21);
            this.case6.TabIndex = 26;
            this.case6.Text = "case6";
            this.case6.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(20, 133);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(122, 17);
            this.label10.TabIndex = 28;
            this.label10.Text = "Number of clients:";
            // 
            // WampSharpForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(517, 310);
            this.Controls.Add(this.splitContainer1);
            this.Name = "WampSharpForm";
            this.Text = "See also WampSharpDemo.log";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button loadTestButton;
        private System.Windows.Forms.TextBox descriptionTb;
        private System.Windows.Forms.TextBox producedTxtBx;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox consumedTb;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox sessionsTb;
        private System.Windows.Forms.TextBox topicsTb;
        private System.Windows.Forms.TextBox subscriptionsTb;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox numClientsTb;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox eventToTestTb;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox rateTb;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox eventProcessTimeTb;
        private System.Windows.Forms.RadioButton case4;
        private System.Windows.Forms.RadioButton case3;
        private System.Windows.Forms.RadioButton case2;
        private System.Windows.Forms.RadioButton case1;
        private System.Windows.Forms.RadioButton case6;
        private System.Windows.Forms.RadioButton case5;
        private System.Windows.Forms.Label label10;
    }
}

