namespace TextBoxClipboardEvents.Demo
{
    partial class Form1
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
            this.extTextBox1 = new WinformPasteEvents.ExtTextBox();
            this.cancelledLabel = new System.Windows.Forms.Label();
            this.completedLabel = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // extTextBox1
            // 
            this.extTextBox1.Location = new System.Drawing.Point(12, 79);
            this.extTextBox1.Multiline = true;
            this.extTextBox1.Name = "extTextBox1";
            this.extTextBox1.Size = new System.Drawing.Size(366, 119);
            this.extTextBox1.TabIndex = 0;
            // 
            // cancelledLabel
            // 
            this.cancelledLabel.AutoSize = true;
            this.cancelledLabel.BackColor = System.Drawing.Color.Red;
            this.cancelledLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cancelledLabel.ForeColor = System.Drawing.Color.White;
            this.cancelledLabel.Location = new System.Drawing.Point(12, 50);
            this.cancelledLabel.Name = "cancelledLabel";
            this.cancelledLabel.Size = new System.Drawing.Size(153, 20);
            this.cancelledLabel.TabIndex = 1;
            this.cancelledLabel.Text = "Operation Cancelled";
            // 
            // completedLabel
            // 
            this.completedLabel.AutoSize = true;
            this.completedLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.completedLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.completedLabel.ForeColor = System.Drawing.Color.White;
            this.completedLabel.Location = new System.Drawing.Point(12, 50);
            this.completedLabel.Name = "completedLabel";
            this.completedLabel.Size = new System.Drawing.Size(160, 20);
            this.completedLabel.TabIndex = 2;
            this.completedLabel.Text = "Operation Completed";
            // 
            // timer1
            // 
            this.timer1.Interval = 3000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(123, 209);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(40, 13);
            this.linkLabel1.TabIndex = 3;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "GitHub";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 209);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Get the source code at";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(358, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Try different clipboard operations (Cut, Copy or Paste) in the textbox below.";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(390, 234);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.completedLabel);
            this.Controls.Add(this.cancelledLabel);
            this.Controls.Add(this.extTextBox1);
            this.Name = "Form1";
            this.Text = "TextBoxClipboardEvents.Demo";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private WinformPasteEvents.ExtTextBox extTextBox1;
        private System.Windows.Forms.Label cancelledLabel;
        private System.Windows.Forms.Label completedLabel;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

