using System;

namespace WpfCsSample.CodeSampleControls.Communications
{
    public class MessageViewModel
    {
        private readonly String _from;
        private readonly String _to;
        private readonly String _text;

        public MessageViewModel(string from, string to, string text)
        {
            _from = from;
            _to = to;
            _text = text;
        }

        public string From
        {
            get { return _from; }
        }

        public string To
        {
            get { return _to; }
        }

        public string Text
        {
            get { return _text; }
        }

        public override string ToString()
        {
            return string.Format("{0} to {1}: \"{2}\"", From, To, Text);
        }
    }
}
