using System.Collections.ObjectModel;

namespace WpfCsSample.CodeSampleControls.Classification
{
    internal class ClassificationTag
    {
        private readonly Collection<ClassificationTag> _children=new Collection<ClassificationTag>();
        private string _tags;
        public Collection<ClassificationTag> Children
        {
            get
            {
                return _children;
            }
        }

        public string Tags
        {
            get
            {
                return _tags;
            }
            set
            {
                _tags = value;
            }
        }
    }
}
