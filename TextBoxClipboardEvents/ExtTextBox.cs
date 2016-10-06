using System;
using System.Windows.Forms;

namespace WinformPasteEvents
{
    /// <summary>
    /// A TextBox control with clipboard events
    /// </summary>
    public class ExtTextBox : TextBox
    {
        /// <summary>
        /// Occurs when a clipboard operation begins and provides a way to cancel the operation
        /// </summary>
        public event EventHandler<ClipboardOperationEventArgs> ClipboardOperationBegin;

        /// <summary>
        /// Occurs at the end of the clipboard operation.
        /// </summary>
        public event EventHandler<ClipboardOperationCompleteEventArgs> ClipboardOperationComplete;

        // WM constants
        private const int WM_CUT = 0x0300;
        private const int WM_COPY = 0x0301;
        private const int WM_PASTE = 0x0302;
        private const int WM_KEYDOWN = 0x0100;

        /// <summary>
        /// true when the CUT operation is ongoing - see HandleClipboardEvent
        /// </summary>
        private bool isCutExecuting = false;
        
        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case WM_PASTE:
                    if (!Clipboard.ContainsText())
                        return;

                    string clipboardText = Clipboard.GetText();
                    HandleClipboardEvent(clipboardText, ClipboardEventTypes.Paste, ref m);
                    break;

                case WM_CUT:
                    isCutExecuting = true;
                    HandleClipboardEvent(this.SelectedText, ClipboardEventTypes.Cut, ref m);
                    isCutExecuting = false;
                    break;

                case WM_COPY:
                    HandleClipboardEvent(this.SelectedText, ClipboardEventTypes.Copy, ref m);
                    break;

                case WM_KEYDOWN:
                    // enable Ctrl+A for the textbox. This keyboard shortcut gets disabled
                    // when you set Multiline to true. So, using the code below Ctrl+A will
                    // work regardless of the current value of the Multiline property.
                    var keyCode = (Keys)(m.WParam.ToInt32() & Convert.ToInt32(Keys.KeyCode));
                    if (keyCode == Keys.A && ModifierKeys == Keys.Control && this.Focused)
                    {
                        SelectAll();
                    }
                    break;

                default:
                    base.WndProc(ref m);
                    break;
            }
        }

        private void HandleClipboardEvent(string text, ClipboardEventTypes type, ref Message m)
        {
            // the Cut operation is performed by sending two window messages in succession: WM_CUT and WM_COPY
            // We are interesting in triggering the event only once (for WM_CUT), thogh.
            if (isCutExecuting && type == ClipboardEventTypes.Copy)
            {
                base.WndProc(ref m);
            }
            else
            {
                var args = new ClipboardOperationEventArgs(text, type);

                ClipboardOperationBegin?.Invoke(this, args);

                if (!args.Cancel)
                {

                    // allow the clipboard operation to execute
                    base.WndProc(ref m);

                    // raise the ClipboardOperationComplete event
                    ClipboardOperationComplete?.Invoke(this, new ClipboardOperationCompleteEventArgs(text, type));
                }
            }
        }
    }
}
