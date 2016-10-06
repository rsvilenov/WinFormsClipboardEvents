using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace TextBoxClipboardEvents.Demo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            // disable resizing
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MinimizeBox = false;
            MaximizeBox = false;

            cancelledLabel.Visible = false;
            completedLabel.Visible = false;

            // subscribe to the clipboard events
            extTextBox1.ClipboardOperationBegin += extTextBox1_ClipboardOperationBegin;
            extTextBox1.ClipboardOperationComplete += extTextBox1_ClipboardOperationComplete;
        }

        private void extTextBox1_ClipboardOperationBegin(object sender, WinformPasteEvents.ClipboardOperationEventArgs e)
        {
            string mboxText = string.Format("Do you really want to {0} \"{1}{2}\"?", 
                e.Type.ToString(),
                e.Text.Substring(0, Math.Min(e.Text.Length, 10)),
                e.Text.Length > 10 ? "..." : "");

            var answer = MessageBox.Show(this, mboxText, "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (answer == DialogResult.No)
            {
                // if the user says No, cancel the operation
                e.Cancel = true;

                string text = $"{e.Type} operation cancelled.";
                ShowLabel(text, true);
            }
        }

        private void extTextBox1_ClipboardOperationComplete(object sender, WinformPasteEvents.ClipboardOperationCompleteEventArgs e)
        {
            string text = $"{e.Type} operation completed.";
            ShowLabel(text, false);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(e.Link.LinkData as string);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LinkLabel.Link link = new LinkLabel.Link();
            link.LinkData = "http://github.com/rsvilenov/WinformsClipboardEvents";
            linkLabel1.Links.Add(link);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            completedLabel.Visible = false;
            cancelledLabel.Visible = false;
            timer1.Stop();
        }

        private void ShowLabel(string text, bool isCancelled)
        {
            if (isCancelled)
            {
                cancelledLabel.Text = text;
            }
            else
            {
                completedLabel.Text = text;
            }

            completedLabel.Visible = !isCancelled;
            cancelledLabel.Visible = isCancelled;
            timer1.Stop();
            timer1.Start();
        }
    }
}
