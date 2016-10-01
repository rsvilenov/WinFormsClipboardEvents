using System.ComponentModel;

/// <summary>
/// This is not a good hierarchy of Event Args classes, but it is interesting nevertheless,
/// because it uses the attribute EditorBrowsable, which allows us to control what to be shown
/// in the intellisence's "suggestion" dropdowns.
/// </summary>
namespace WinformPasteEvents
{
    public enum ClipboardEventTypes
    {
        Cut,
        Copy,
        Paste
    }

    public class ClipboardOperationEventArgs : CancelEventArgs
    {
        public ClipboardOperationEventArgs(string text, ClipboardEventTypes type)
        {
            Text = text;
            Type = type;
        }

        public ClipboardEventTypes Type { get; set; }
        public string Text { get; set; }
    }

    public class ClipboardOperationCompleteEventArgs : ClipboardOperationEventArgs
    {
        public ClipboardOperationCompleteEventArgs(string text, ClipboardEventTypes type)
            : base(text, type)
        { }

        /// <summary>
        /// Hide the Cancel member from the Intellisence and, for any case, make it read-only
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        new bool Cancel { get; }
    }
}
